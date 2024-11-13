using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Volcanion.Core.Common;
using Volcanion.Core.Common.Models.Redis;
using Volcanion.Core.Common.Providers;
using Volcanion.Core.Models.Response;
using Volcanion.Core.Presentation.Middlewares;
using Volcanion.Identity.Infrastructure;
using Volcanion.Identity.Handlers;
using Volcanion.Identity.Models.Context;
using Volcanion.Identity.Models.MappingProfiles;
using Volcanion.Identity.Services;
using Serilog;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterProviders();
builder.Services.RegisterIdentityInfrastructure();
builder.Services.RegisterIdentityService();
builder.Services.RegisterIdentityHandler();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(DtoMappingProfile));

// Add Redis
builder.Services.Configure<RedisOptions>(builder.Configuration.GetSection("Redis"));
builder.Services.AddRedisCacheService(builder.Configuration.GetSection("Redis"));

// Configure CORS
var corsOptions = builder.Configuration.GetSection("Cors");
var origins = corsOptions.GetSection("Origins").Get<string[]>() ?? ["*"];
var headers = corsOptions.GetSection("Headers").Get<string[]>() ?? ["*"];
var methods = corsOptions.GetSection("Methods").Get<string[]>() ?? ["*"];
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins", policy =>
    {
        policy.WithOrigins(origins).WithHeaders(headers).WithMethods(methods);
    });
});

// API Versioning
builder.Services.AddApiVersioning(x =>
{
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.ReportApiVersions = true;
    x.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver")
    );
});

// Add Entity Framework DBContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

// Use serilog
configureLogging();
builder.Host.UseSerilog();

// Configure the global error handling middleware
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // Configure the global error handling middleware
    options.InvalidModelStateResponseFactory = context =>
    {
        // Get the errors
        var errors = context.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .Select(e => new
            {
                Field = e.Key,
                ErrorMessages = e.Value.Errors.Select(x => x.ErrorMessage).ToArray()
            });

        var response = new ResponseResult
        {
            Data = errors,
            ErrorCode = -1,
            Message = "Invalid model state",
            StatusCodes = HttpStatusCode.BadRequest,
            Succeeded = false,
            Detail = "Invalid model state"
        };

        return new BadRequestObjectResult(response);
    };
});

var app = builder.Build();

// Use the CORS policy
app.UseCors("AllowOrigins");

app.UseGlobalErrorHandlingMiddleware();
app.UseVolcanionAuthMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void configureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    environment ??= "Development";

    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment}.json", optional: true)
        .AddEnvironmentVariables()
    .Build();

    if (configuration == null)
    {
        Console.WriteLine("configuration is null");
    }

    LogProvider.LoggerSetting(configuration, environment);
}
# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /source

# Copy the csproj file and restore the packages
COPY src/presentation/Volcanion.Identity.Handlers/Volcanion.Identity.Handlers.csproj /Volcanion.Identity.Handlers/Volcanion.Identity.Handlers.csproj
COPY src/presentation/Volcanion.Identity.Infrastructure/Volcanion.Identity.Handlers.csproj /Volcanion.Identity.Infrastructure/Volcanion.Identity.Infrastructure.csproj
COPY src/presentation/Volcanion.Identity.Models/Volcanion.Identity.Models.csproj /Volcanion.Identity.Models/Volcanion.Identity.Models.csproj
COPY src/presentation/Volcanion.Identity.Services/Volcanion.Identity.Services.csproj /Volcanion.Identity.Services/Volcanion.Identity.Services.csproj
COPY src/presentation/Volcanion.Identity.Presentation/Volcanion.Identity.Presentation.csproj /Volcanion.Identity.Presentation/Volcanion.Identity.Presentation.csproj
RUN dotnet restore ./Volcanion.Identity.Presentation/Volcanion.Identity.Presentation.csproj

# Copy the source code and build the application
COPY . .
RUN dotnet publish ./Volcanion.Identity.Presentation/Volcanion.Identity.Presentation.csproj -c Release -o /publish

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy the build output from the build image to the container
COPY --from=build /app .

# Run the application
ENTRYPOINT ["dotnet", "Volcanion.Identity.Presentation.dll"]

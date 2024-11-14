ARG NUGET_SOURCE="http://10.99.81.15:5000/v3/index.json"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY volcanion-identity.sln ./
COPY src/Volcanion.Identity.Handlers/Volcanion.Identity.Handlers.csproj src/Volcanion.Identity.Handlers/
COPY src/Volcanion.Identity.Infrastructure/Volcanion.Identity.Infrastructure.csproj src/Volcanion.Identity.Infrastructure/
COPY src/Volcanion.Identity.Models/Volcanion.Identity.Models.csproj src/Volcanion.Identity.Models/
COPY src/Volcanion.Identity.Services/Volcanion.Identity.Services.csproj src/Volcanion.Identity.Services/
COPY src/Volcanion.Identity.Presentation/Volcanion.Identity.Presentation.csproj src/Volcanion.Identity.Presentation/

RUN dotnet restore --source "https://api.nuget.org/v3/index.json" --source "$NUGET_SOURCE"

COPY . .

WORKDIR /app/src/Volcanion.Identity.Presentation
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build /out .

ENTRYPOINT ["dotnet", "Volcanion.Identity.Presentation.dll"]

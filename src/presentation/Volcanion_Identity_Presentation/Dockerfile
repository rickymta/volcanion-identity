FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /source

COPY src/presentation/Volcanion_Identity_Handlers/*.csproj ./Volcanion_Identity_Handlers/
COPY src/presentation/Volcanion_Identity_Infrastructure/*.csproj ./Volcanion_Identity_Infrastructure/
COPY src/presentation/Volcanion_Identity_Models/*.csproj ./Volcanion_Identity_Models/
COPY src/presentation/Volcanion_Identity_Services/*.csproj ./Volcanion_Identity_Services/
COPY src/presentation/Volcanion_Identity_Presentation/*.csproj ./Volcanion_Identity_Presentation/

RUN dotnet restore ./Volcanion_Identity_Presentation/Volcanion_Identity_Presentation.csproj

COPY src/presentation/ ./src/presentation/

RUN dotnet publish ./Volcanion_Identity_Presentation/Volcanion_Identity_Presentation.csproj -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY --from=build /publish .

ENTRYPOINT ["dotnet", "Volcanion_Identity_Presentation.dll"]

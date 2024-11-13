# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /source

# Copy the csproj file and restore the packages
COPY /src/presentation/Volcanion.Identity.Handlers/*.csproj ./Volcanion.Identity.Handlers/
COPY /src/presentation/Volcanion.Identity.Infrastructure/*.csproj ./Volcanion.Identity.Infrastructure/
COPY /src/presentation/Volcanion.Identity.Models/*.csproj ./Volcanion.Identity.Models/
COPY /src/presentation/Volcanion.Identity.Services/*.csproj ./Volcanion.Identity.Services/
COPY /src/presentation/Volcanion.Identity.Presentation/*.csproj ./Volcanion.Identity.Presentation
RUN dotnet restore

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

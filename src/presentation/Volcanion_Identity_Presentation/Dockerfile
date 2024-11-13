# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /source

# Copy the csproj file and restore the packages
COPY src/presentation/Volcanion_Identity_Handlers/Volcanion_Identity_Handlers.csproj /Volcanion_Identity_Handlers/Volcanion_Identity_Handlers.csproj
COPY src/presentation/Volcanion_Identity_Infrastructure/Volcanion_Identity_Infrastructure.csproj /Volcanion_Identity_Infrastructure/Volcanion_Identity_Infrastructure.csproj
COPY src/presentation/Volcanion_Identity_Models/Volcanion_Identity_Models.csproj /Volcanion_Identity_Models/Volcanion_Identity_Models.csproj
COPY src/presentation/Volcanion_Identity_Services/Volcanion_Identity_Services.csproj /Volcanion_Identity_Services/Volcanion_Identity_Services.csproj
COPY src/presentation/Volcanion_Identity_Presentation/Volcanion_Identity_Presentation.csproj /Volcanion_Identity_Presentation/Volcanion_Identity_Presentation.csproj
RUN dotnet restore "./Volcanion_Identity_Presentation/Volcanion_Identity_Presentation.csproj"

# Copy the source code and build the application
COPY src/ .
RUN dotnet publish "./Volcanion_Identity_Presentation/Volcanion_Identity_Presentation.csproj" -c Release -o /publish

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy the build output from the build image to the container
COPY --from=build /app .

# Run the application
ENTRYPOINT dotnet Volcanion_Identity_Presentation.dll

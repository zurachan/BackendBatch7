# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackendBatch7.API/BackendBatch7.API.csproj", "BackendBatch7.API/"]
COPY ["BackendBatch7.Domain/BackendBatch7.Domain.csproj", "BackendBatch7.Domain/"]
COPY ["BackendBatch7.Infrastructure/BackendBatch7.Infrastructure.csproj", "BackendBatch7.Infrastructure/"]
RUN dotnet restore "./BackendBatch7.API/BackendBatch7.API.csproj"
COPY . .
WORKDIR "/src/BackendBatch7.API"
RUN dotnet build "./BackendBatch7.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BackendBatch7.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendBatch7.API.dll"]
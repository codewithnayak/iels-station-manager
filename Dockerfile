# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files individually (ensures restore works)
COPY src/StationManager.Api/StationManager.Api.csproj StationManager.Api/
COPY src/StationManager.Domain/StationManager.Domain.csproj StationManager.Domain/
COPY src/StationManager.Infrastructure/StationManager.Infrastructure.csproj StationManager.Infrastructure/
COPY src/StationManager.Application/StationManager.Application.csproj StationManager.Application/

# Restore using the API project (it references the others)
RUN dotnet restore StationManager.Api/StationManager.Api.csproj

# Copy the rest of the source code
COPY src/ .

# Publish
RUN dotnet publish StationManager.Api/StationManager.Api.csproj -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "StationManager.Api.dll"]

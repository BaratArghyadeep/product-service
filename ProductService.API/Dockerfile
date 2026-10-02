# =========================
# Build Stage
# =========================

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy project files first (better Docker caching)

COPY ProductService.API/ProductService.API.csproj ProductService.API/
COPY ProductService.Application/ProductService.Application.csproj ProductService.Application/
COPY ProductService.Domain/ProductService.Domain.csproj ProductService.Domain/
COPY ProductService.Infrastructure/ProductService.Infrastructure.csproj ProductService.Infrastructure/

RUN dotnet restore ProductService.API/ProductService.API.csproj

# Copy everything else

COPY . .

RUN dotnet publish ProductService.API/ProductService.API.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# =========================
# Runtime Stage
# =========================

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 8080

ENTRYPOINT ["dotnet", "ProductService.API.dll"]
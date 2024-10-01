#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PersonCatalog.API/PersonCatalog.API.csproj", "PersonCatalog.API/"]
COPY ["PersonCatalog.Application/PersonCatalog.Application.csproj", "PersonCatalog.Application/"]
COPY ["PersonCatalog.Core/PersonCatalog.Core.csproj", "PersonCatalog.Core/"]
COPY ["PersonCatalog.Infrastructure/PersonCatalog.Infrastructure.csproj", "PersonCatalog.Infrastructure/"]
COPY ["PersonCatalog.ServiceDefaults/PersonCatalog.ServiceDefaults.csproj", "PersonCatalog.ServiceDefaults/"]
RUN dotnet restore "./PersonCatalog.API/PersonCatalog.API.csproj"
COPY . .
WORKDIR "/src/PersonCatalog.API"
RUN dotnet build "./PersonCatalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PersonCatalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["sh", "-c", "dotnet ef database update && dotnet PersonCatalog.API.dll"]

ENTRYPOINT ["dotnet", "PersonCatalog.API.dll"]
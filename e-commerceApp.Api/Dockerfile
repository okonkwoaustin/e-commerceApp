#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["e-commerceApp.Api/e-commerceApp.Api.csproj", "e-commerceApp.Api/"]
COPY ["e-commerceApp.Application/e-commerceApp.Application.csproj", "e-commerceApp.Application/"]
COPY ["e-commerceApp.Shared/e-commerceApp.Shared.csproj", "e-commerceApp.Shared/"]
RUN dotnet restore "./e-commerceApp.Api/./e-commerceApp.Api.csproj"
COPY . .
WORKDIR "/src/e-commerceApp.Api"
RUN dotnet build "./e-commerceApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./e-commerceApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "e-commerceApp.Api.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Onyx.Products.Web.Api/Onyx.Products.Web.Api.csproj", "Onyx.Products.Web.Api/"]
RUN dotnet restore "./Onyx.Products.Web.Api/./Onyx.Products.Web.Api.csproj"
COPY . .
WORKDIR "/src/Onyx.Products.Web.Api"
RUN dotnet build "./Onyx.Products.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Onyx.Products.Web.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onyx.Products.Web.Api.dll"]
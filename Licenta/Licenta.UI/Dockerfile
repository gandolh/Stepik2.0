#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Licenta.UI/Licenta.UI.csproj", "Licenta.UI/"]
COPY ["Components.UI/Components.UI.csproj", "Components.UI/"]
COPY ["Licenta.SDK/Licenta.SDK.csproj", "Licenta.SDK/"]
RUN dotnet restore "./Licenta.UI/./Licenta.UI.csproj"
COPY . .
WORKDIR "/src/Licenta.UI"
RUN dotnet build "./Licenta.UI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Licenta.UI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Licenta.UI.dll"]
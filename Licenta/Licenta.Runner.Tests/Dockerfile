#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Licenta.Runner.Tests/Licenta.Runner.Tests.csproj", "Licenta.Runner.Tests/"]
COPY ["Licenta.Runner/Licenta.Runner.csproj", "Licenta.Runner/"]
COPY ["Licenta.SDK/Licenta.Sdk.Config/Licenta.Sdk.Config.csproj", "Licenta.SDK/Licenta.Sdk.Config/"]
COPY ["Licenta.SDK/Licenta.Sdk.Models/Licenta.Sdk.Models.csproj", "Licenta.SDK/Licenta.Sdk.Models/"]
RUN dotnet restore "Licenta.Runner.Tests/Licenta.Runner.Tests.csproj"
COPY . .
WORKDIR "/src/Licenta.Runner.Tests"
RUN dotnet build "Licenta.Runner.Tests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Licenta.Runner.Tests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Licenta.Runner.Tests.dll"]
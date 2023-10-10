#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Licenta.Db/Licenta.Db.csproj", "Licenta.Db/"]
RUN dotnet restore "Licenta.Db/Licenta.Db.csproj"
COPY . .
WORKDIR "/src/Licenta.Db"
RUN dotnet build "Licenta.Db.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Licenta.Db.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Licenta.Db.dll"]
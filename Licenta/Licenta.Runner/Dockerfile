#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
#USER app
WORKDIR /app

# install python
RUN apt-get update -y && \ 
apt-get install python3 python3-pip python3.11-venv -y

# create venv
RUN python3 -m venv .venv
SHELL ["/bin/bash", "-c", "source .venv/bin/activate"]
RUN pip install --upgrade pip && \ 
	python3 -m pip install -r requirements.txt
# end env

COPY . .
# end install python


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Licenta.Runner/Licenta.Runner.csproj", "Licenta.Runner/"]
RUN dotnet restore "Licenta.Runner/Licenta.Runner.csproj"
COPY . .
WORKDIR "/src/Licenta.Runner"
RUN dotnet build "Licenta.Runner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Licenta.Runner.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Licenta.Runner.dll"]


#python3 -m venv .venv && \
#source .venv/bin/activate && \
#python3 -m pip install -r requirements.txt
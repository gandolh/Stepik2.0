#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#USER app


# install python
RUN apt-get update -y && \ 
apt-get install python3 python3-pip python3.11-venv -y
#
## create venv
RUN python3 -m venv .venv
SHELL ["/bin/bash", "-c", "source .venv/bin/activate"]
RUN pip install --upgrade pip && \ 
	python3 -m pip install -r requirements.txt
# end env

# end install python
# install cpp

RUN apt-get install build-essential manpages-dev -y

# end install cpp
COPY . .
WORKDIR /app
ENTRYPOINT ["dotnet", "test"]
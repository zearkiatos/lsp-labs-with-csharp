FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app

RUN apt-get update && \
    apt-get upgrade -y && \
    apt-get install -y nodejs
COPY . /app

CMD dotnet restore && \
    dotnet clean && \
    dotnet build && \
    dotnet test
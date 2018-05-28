FROM microsoft/aspnetcore-build:2.0 AS build-env
WORKDIR /app
COPY . ./
EXPOSE 80
ENTRYPOINT dotnet run


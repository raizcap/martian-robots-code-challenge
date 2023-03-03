# Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore ./API/API.csproj --disable-parallel
RUN dotnet publish ./API/API.csproj --disable-parallel -c release -o /CodeChallengeApi --no-restore

# Serve
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /CodeChallengeApi
COPY --from=build /CodeChallengeApi ./

EXPOSE 5005

ENTRYPOINT ["dotnet", "./API.dll", "--urls", "http://*:5005"]
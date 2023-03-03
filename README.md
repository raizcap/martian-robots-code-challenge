# Martian robots code challenge

## Prerequisites
- Docker
- .NET 7.0
- Internet connection (Docker images are downloaded from the Internet in case they haven't been downloaded previously)

## Preparing the environment
1. Run the next command in Terminal (Mac/Linux) or Powershell (Windows) in order to create and run the database Docker container:
   
    docker run --name codechallengeDB --network codechallenge-network -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Cod3.Challeng3' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

2. 
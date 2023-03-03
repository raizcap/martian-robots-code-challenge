docker network create codechallenge-network

docker run --name CodeChallengeDB --network codechallenge-network -p 1433:1433 -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Cod3.Challeng3' -d mcr.microsoft.com/mssql/server:2022-latest

docker build -t code-challenge:v1 .

docker run --name CodeChallengeAPI --network codechallenge-network -p 5005:5005 -e 'ASPNETCORE_URLS=http://*:5005' -d code-challenge:v1
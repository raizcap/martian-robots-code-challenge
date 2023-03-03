# Martian robots code challenge

## Prerequisites
- MacOS (currently the only one OS where the solution has been tested is MacOS. Tests on Windows are pending.)
- Docker
- .NET 7.0
- Internet connection (Docker images are downloaded from the Internet in case they haven't been downloaded previously)

## Preparing the environment

There are two ways to prepare the environment: execute the OS dependant setup script or execute the docker commands in the correct order.

- Executing the setup script: run the MacSetup.sh script in the folder where it's located. If there is no error, you should see two Docker containers running: CodeChallengeDB and CodeChallengeAPI.

- Running the next commands in Terminal (Mac) or Powershell (Windows) for creating and running the Docker containters:

  1. Create a custom Docker network for allowing containers to communicate to each other with the next command: 

            docker network create codechallenge-network

  2. Create and run the database Docker container:
   
            docker run --name CodeChallengeDB --network codechallenge-network -p 1433:1433 -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Cod3.Challeng3' -d mcr.microsoft.com/mssql/server:2022-latest

  3. Build the Docker image for the API (this one must be executed in the API solution root folder): 

            docker build -t code-challenge:v1 .

  4. Run the previously created Docker image for executing the API: 

            docker run -d --name CodeChallengeAPI --network codechallenge-network -p 5005:5005 -e 'ASPNETCORE_URLS=http://*:5005' code-challenge:v1
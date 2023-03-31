# Martian robots code challenge

## Prerequisites
- MacOS (currently the only one OS where the solution has been tested is MacOS. Tests on Windows are pending.)
- Docker
- .NET 7.0
- Internet connection (Docker images are downloaded from the Internet in case they haven't been downloaded previously)

## Project explanation
The application consists of three parts: database, API and core application. The core application loads data from an input file (this is explained in "[Running the application](#running-the-application)" section), does several checks, processes the robots instructions and gives the final result in the console.

In that process, the application accesses to the API to retrieve and store data about the loaded surfaces and the robots lost previously in a concrete Mars surface. For example, if a robot was lost previously in x=2, y=3 and orientation=E with instruction=F as the last processed instruction, that instruction will be omited and the application will continue with the next one. This database is created by the API using Entity Framework code-first.

The database and the API are hosted in separated Docker containers as microservices, and both are in the same docker network in order to communicate easier between them.

## Preparing the environment

There are two ways to prepare the environment: execute the OS dependant setup script or execute the docker commands in the correct order.

- Executing the setup script: run the <u>**MacSetup.sh**</u> script in the folder where it's located.

- Running the next commands in Terminal (Mac) or Powershell (Windows) for creating and running the Docker containters:

  1. Create a custom Docker network for allowing containers to communicate to each other with the next command: 

            docker network create codechallenge-network

  2. Create and run the database Docker container:
   
            docker run --name CodeChallengeDB --network codechallenge-network -p 1433:1433 -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Cod3.Challeng3' -d mcr.microsoft.com/mssql/server:2022-latest

  3. Build the Docker image for the API (this one must be executed in the API solution root folder): 

            docker build -t code-challenge:v1 .

  4. Run the previously created Docker image for executing the API: 

            docker run --name CodeChallengeAPI --network codechallenge-network -p 5005:5005 -e 'ASPNETCORE_URLS=http://*:5005' -d code-challenge:v1

If there is no error, you should see two Docker containers running: CodeChallengeDB and CodeChallengeAPI. Both have to be running before executing the application. In case you want to run them manually:
  1. First run CodeChallengeDB container.
   
  2. Once it's running, run CodeChallengeAPI container.
   
  3. If the API stops due to an error, try againg some seconds later. It could be that the DB was still not ready.

## Running the application
The application dll is located in a folder named "TARGET", in the application root folder. The command to execute the application is this one:
      
        dotnet MartianRobotsApp.dll <path to file>

The file must be a plain text file and it must contain the input data explained in the provided code challenge PDF. The path to the file can be specified with relative or absolute paths, and in MacOS/Linux also with the user folder character (~).

This is the example file content:

      5 3
      1 1 E
      RFRFRFRF
      3 2 N
      FRRFLLFFRRFLL
      0 3 W
      LLFFFRFLFL

When the application is started it writes to the console the processed robots and the final result. If a robot is lost, the word "LOST" will appear next to the final coordinates and orientation. If the robot continues being reachable, nothing will be shown in the results next to the final data.

## Microservices
The database is a SQL Server 2022 Docker container, and it's accesible with the next credentials:

      Host: localhost,1433
      Username: sa
      Password: Cod3.Challeng3
      Ecrypt: Optional (false)
      Trust server certificate: false

If you want to reset the database data, for example in order the database to forget the lost robots, you have to delete the desired rows manually and after that reboot the API Docker container.

The API is accesible vía Swagger here: [http://localhost:5005/swagger](http://localhost:5005/swagger)
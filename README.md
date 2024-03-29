# Martian robots code challenge

## Prerequisites
- MacOS, Linux or Windows, this application works on all of them
- Docker
- .NET >=7.0 SDK (the application modules are compiled in the setup process)
- Internet connection (Docker images are downloaded from the Internet in case they haven't been downloaded previously)

## Project explanation
The application consists of three parts: database, API and core application. The core application has to be executed in a console and loads data from an input file (this is explained in "[Running the application](#running-the-application)" section), does several checks, processes the robots instructions and shows the final result in the console.

In that process, the application accesses to the API to retrieve and store data in the database about the loaded surfaces and the previously lost robots in a concrete Mars surface. For example, if a robot was lost previously in x = 2, y = 3 and orientation = E with instruction = F as the last processed instruction, that instruction will be omitted and the application will continue with the next one. This database is created by the API using Entity Framework code-first approach.

The database and the API are hosted in separated Docker containers as microservices, and both are in the same docker network, named "codechallenge-network", to make it easier for them to communicate with each other.

## Preparing the environment

There are two ways to prepare the environment: **execute the OS dependant setup script** or **execute the docker and the application build commands** manually in the <u>correct order</u>.

- Executing the setup script: run <u>**MacLinuxSetup.sh**</u> or <u>**WindowsSetup.sh**</u> script, depending on the host OS, in the folder where it's located (martian-robots-code-challenge).

- Running the next commands in Terminal (Mac) or Powershell (Windows) for creating and running the Docker containters and for building the application in release mode:

  1. Create a custom Docker network for allowing containers to communicate to each other with the next command: 

            docker network create codechallenge-network

  2. Create and run the database Docker container:
   
            docker run --name CodeChallengeDB --network codechallenge-network -p 1433:1433 -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Cod3.Challeng3' -d mcr.microsoft.com/mssql/server:2022-latest

  3. Build the Docker image for the API (this one must be executed in the API solution root folder, where "Dockerfile" is located): 

            docker build -t code-challenge:v1 .

  4. Run the previously created Docker image for executing the API: 

            docker run --name CodeChallengeAPI --network codechallenge-network -p 5005:5005 -e 'ASPNETCORE_URLS=http://*:5005' -d code-challenge:v1

  5. Execute the next two commands in order to build the application (it seems weird, but sometimes dotnet build command doesn't restore the packages properly and the solution is to execute a restore and later execute a build with --no-restore):

            dotnet restore ./MartianRobotsApp/MartianRobotsApp/MartianRobotsApp.csproj --disable-parallel
            dotnet build ./MartianRobotsApp/MartianRobotsApp/MartianRobotsApp.csproj --disable-parallel -c release --no-restore

If there is no error, you should see two Docker containers running: CodeChallengeDB and CodeChallengeAPI. Both have to be running before executing the application. In case you want to run them manually:
  1. First run CodeChallengeDB container.
   
  2. Once it's running, run CodeChallengeAPI container.
   
  3. If the API stops due to an error, try againg some seconds later. It could be that the DB was still not ready to receive connections.

## Running the application
The application dll is located in a folder named "TARGET", in the application root folder (martian-robots-code-challenge). The command to execute the application is the next one:
      
        dotnet MartianRobotsApp.dll <path to file>

The file must be a plain text file (or .txt) and it must contain the input data explained in the provided code challenge PDF. The path to the file can be specified with relative or absolute paths, and also with the MacOS/Linux user folder "~" (yes, even in Windows).

This is the example file content:

      5 3
      1 1 E
      RFRFRFRF
      3 2 N
      FRRFLLFFRRFLL
      0 3 W
      LLFFFRFLFL

When the application is started it writes to the console any error related with the path, file format or an instruction, and if all checks are successful the processed robots and the final result are written. If a robot has been lost, the word "LOST" will appear next to the final coordinates and orientation. If the robot is still reachable after all its instructions have been processed, nothing will be shown in the results next to the final data.

## Microservices
The database is a SQL Server 2022 Docker container, and it's accesible with the next credentials:

      Host: localhost,1433
      Username: sa
      Password: Cod3.Challeng3
      Ecrypt: Optional (false)
      Trust server certificate: false

If you want to reset the database data, for example in order the database to forget the lost robots, you have to delete the desired rows manually and after that reboot the API Docker container (or you can also stop the API Docker container, delete the rows and finally start the container, but it's one step more).

The API is accesible vía Swagger here: [http://localhost:5005/swagger](http://localhost:5005/swagger)

## Tests
I have written only unit tests in the core application, MartianRobotsApp, because the DB project doesn't contain code that needs to be tested and the API project only contains models without logic, controllers that only use the services and services that use the Entity Framework functions. Tests here wouldn't be interesting because there are no E2E nor integration tests, and the most important part to test is the core application.

For these tests I have used MSTest along with NSubstitute for mocking the dependencies.

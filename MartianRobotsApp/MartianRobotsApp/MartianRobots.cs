using System;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services;

namespace MartianRobotsApp
{
    public class MartianRobots
    {
        private string filePath = "";
        private readonly IFileCheckerService mFileCheckerService;
        private readonly IArgumentsCheckerService mArgumentsCheckerService;
        private readonly IMarsSurfaceService mMarsSurfaceService;
        private readonly IFileContentManagerService mFileContentManagerService;

        public MartianRobots(
            IFileCheckerService fileCheckerService,
            IArgumentsCheckerService argumentsCheckerService,
            IMarsSurfaceService marsSurfaceService,
            IFileContentManagerService fileContentManagerService)
        {
            if (fileCheckerService == null) throw new ArgumentException(nameof(fileCheckerService));
            if (argumentsCheckerService == null) throw new ArgumentException(nameof(argumentsCheckerService));
            if (marsSurfaceService == null) throw new ArgumentException(nameof(marsSurfaceService));
            if (fileContentManagerService == null) throw new ArgumentException(nameof(fileContentManagerService));

            mFileCheckerService = fileCheckerService;
            mArgumentsCheckerService = argumentsCheckerService;
            mMarsSurfaceService = marsSurfaceService;
            mFileContentManagerService = fileContentManagerService;
        }

        public void Run(string[] args)
        {
            // Firstly check if the given path is valid
            filePath = mFileCheckerService.GetValidPath(args[0]);

            // Later check that the command has only one argument and the file exists
            var result = InitialChecks(args);

            // Afterwards read the content of the file: Mars surface and robots instructions
            if (!result.Exit)
            {
                result = mFileContentManagerService.LoadFileContent(filePath);
            }

            // Start process

            // Communicate results

            if (result.Exit)
            {
                Console.WriteLine(result.Message);
                Environment.Exit(1);
            }

            Console.WriteLine("It's all right");
        }

        private IFunctionResult InitialChecks(string[] args)
        {
            var result = mArgumentsCheckerService.CheckCommandArguments(args);

            if (!result.Exit)
            {
                result = mFileCheckerService.CheckFileName(filePath);
            }

            return result;
        }
    }
}


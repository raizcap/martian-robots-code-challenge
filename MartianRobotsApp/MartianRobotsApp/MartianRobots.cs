using System;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services;

namespace MartianRobotsApp
{
    public class MartianRobots
    {
        private string mFilePath = "";
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
            if (fileCheckerService == null) throw new ArgumentNullException(nameof(fileCheckerService));
            if (argumentsCheckerService == null) throw new ArgumentNullException(nameof(argumentsCheckerService));
            if (marsSurfaceService == null) throw new ArgumentNullException(nameof(marsSurfaceService));
            if (fileContentManagerService == null) throw new ArgumentNullException(nameof(fileContentManagerService));

            mFileCheckerService = fileCheckerService;
            mArgumentsCheckerService = argumentsCheckerService;
            mMarsSurfaceService = marsSurfaceService;
            mFileContentManagerService = fileContentManagerService;
        }

        public void Run(string[] args)
        {
            // Firstly check that the command has only one argument and the file exists
            var result = InitialChecks(args);

            // Afterwards read the content of the file: Mars surface and robots instructions
            if (!result.Exit)
            {
                result = mFileContentManagerService.LoadFileContent(mFilePath);
            }

            // Start process
            if (!result.Exit)
            {
                mMarsSurfaceService.ProcessRobotsInstructions();
            }

            // Communicate results
            if (!result.Exit)
            {
                Console.WriteLine("===== RESULTS =====");
                Console.WriteLine(mMarsSurfaceService.GetResults());
                Console.WriteLine("===================");
            }

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
                // Get a valid path in case that it starts with ~ or it contains double slashes
                mFilePath = mFileCheckerService.GetValidPath(args[0]);

                result = mFileCheckerService.CheckFileName(mFilePath);
            }

            return result;
        }
    }
}


using System;
using MartianRobotsApp.Services;

namespace MartianRobotsApp
{
    public class MartianRobots
    {
        private readonly IFileCheckerService mFileCheckerService;
        private readonly IArgumentsCheckerService mArgumentsCheckerService;

        public MartianRobots(
            IFileCheckerService fileCheckerService,
            IArgumentsCheckerService argumentsCheckerService)
        {
            if (fileCheckerService == null) throw new ArgumentException(nameof(fileCheckerService));
            if (argumentsCheckerService == null) throw new ArgumentException(nameof(argumentsCheckerService));

            mFileCheckerService = fileCheckerService;
            mArgumentsCheckerService = argumentsCheckerService;
        }

        public void Run(string[] args)
        {
            InitialChecks(args);
        }

        private void InitialChecks(string[] args)
        {
            var path = "";
            (bool exit, string message) = mArgumentsCheckerService.CheckCommandArguments(args);

            if (!exit)
            {
                path = mFileCheckerService.GetValidPath(args[0]);
                (exit, message) = mFileCheckerService.CheckFileName(path);
            }

            if (!exit)
            {
                (exit, message) = mFileCheckerService.CheckFileFormat(path);
            }

            if (exit)
            {
                Console.WriteLine(message);
                Environment.Exit(1);
            }

            Console.WriteLine("All OK");
        }
    }
}


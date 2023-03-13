using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
	public class ArgumentsCheckerService : IArgumentsCheckerService
	{
		public (bool, string) CheckCommandArguments(string[] args)
        {
            if (args.Length == 0)
            {
                return (true, ErrorMessages.NO_FILE_PROVIDED);
            }
            else if(args.Length > 1)
            {
                return (true, String.Format(ErrorMessages.INVALID_ARGUMENT, args[1]));
            }

            return (false, ErrorMessages.NO_ERROR);
        }
    }
}


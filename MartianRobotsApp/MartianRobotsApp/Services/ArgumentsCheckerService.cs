using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public class ArgumentsCheckerService : IArgumentsCheckerService
    {
        public FunctionResult CheckCommandArguments(string[] args)
        {
            if (args.Length == 0)
            {
                return new ErrorFunctionResult(ErrorMessages.NO_FILE_PROVIDED);
            }
            else if (args.Length > 1)
            {
                return new ErrorFunctionResult(String.Format(ErrorMessages.INVALID_ARGUMENT, args[1]));
            }

            return new OkFunctionResult();
        }
    }
}


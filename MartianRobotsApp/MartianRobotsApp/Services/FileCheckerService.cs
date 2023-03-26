using System;
using System.Text.RegularExpressions;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public class FileCheckerService : IFileCheckerService
    {
        public IFunctionResult CheckFileName(string path)
        {
            if (Path.Exists(path) && Directory.Exists(path))
            {
                return new ErrorFunctionResult(ErrorMessages.INVALID_HOME_PATH);
            }

            var fileExists = File.Exists(path);

            if (!fileExists)
            {
                return new ErrorFunctionResult(ErrorMessages.FILE_DOESNT_EXIST);
            }

            return new OkFunctionResult();
        }

        public string GetValidPath(string givenPath)
        {
            return givenPath
                .Replace("~" + Environment.UserName, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
                .Replace("~", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
                .Replace("//", "/")
                .Replace("\\\\", "\\");
        }
    }
}


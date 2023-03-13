using System;
using System.Text.RegularExpressions;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public class FileCheckerService : IFileCheckerService
    {
        public (bool exit, string message) CheckFileName(string path)
        {
            if (Path.Exists(path) && Directory.Exists(path))
            {
                return (true, ErrorMessages.INVALID_HOME_PATH);
            }

            var fileExists = File.Exists(path);

            if (!fileExists)
            {
                return (true, ErrorMessages.FILE_DOESNT_EXIST);
            }

            return (false, ErrorMessages.NO_ERROR);
        }

        public (bool exit, string message) CheckFileFormat(string path)
        {
            var fileStream = new StreamReader(path);

            var surfaceSize = fileStream.ReadLine();

            if (surfaceSize == null || !SurfaceSizeIsCorrect(surfaceSize))
            {
                return (true, ErrorMessages.INVALID_SURFACE_SIZE);
            }

            return (false, ErrorMessages.NO_ERROR);
        }

        public string GetValidPath(string givenPath)
        {
            return givenPath
                .Replace("~" + Environment.UserName, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
                .Replace("~", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile))
                .Replace("//", "/")
                .Replace("\\\\", "\\");
        }

        private bool SurfaceSizeIsCorrect(string surfaceSize)
        {
            var pattern = @"\d{1,2}\s\d{1,2}$";
            var regexp = new Regex(pattern);

            return regexp.IsMatch(surfaceSize);
        }
    }
}


using System;
using System.Text.RegularExpressions;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
	public class FileContentManagerService : IFileContentManagerService
	{
        // Surface pattern: 1 or 2 digits, a blank space and 1 or 2 digits
        // in the same line, followed by a line change
        private const string SURFACE_REGEX_PATTERN = @"\d{1,2}\s\d{1,2}$";

        private readonly IMarsSurfaceService mMarsSurfaceService;
        private readonly IRobotsService mRobotsService;

		public FileContentManagerService(
            IMarsSurfaceService marsSurfaceService,
            IRobotsService robotsService)
		{
            if (marsSurfaceService == null) throw new ArgumentException(nameof(marsSurfaceService));
            if (robotsService == null) throw new ArgumentException(nameof(robotsService));

            mMarsSurfaceService = marsSurfaceService;
            mRobotsService = robotsService;
		}

        public FunctionResult LoadFileContent(string filePath)
		{
            var fileContentLines = new List<string>();
            try
            {
                fileContentLines = File.ReadAllLines(filePath).ToList();
            }
            catch (Exception ex)
            {
                return new ErrorFunctionResult(string.Format(
                        ErrorMessages.ERROR_LOADING_CONTENT,
                        ex.GetType(), ex.Message));
            }

            var result = LoadMarsSurface(fileContentLines[0]);

            if (!result.Exit)
            {
                result = LoadRobots(File.ReadAllText(filePath));
            }

            return result;
        }

        private FunctionResult LoadMarsSurface(string surface)
        {
            if (surface == null || !SurfaceSizeIsCorrect(surface))
            {
                return new ErrorFunctionResult(ErrorMessages.INVALID_SURFACE_SIZE_LINE);
            }

            var surfaceParts = surface.Split(" ");

            // The surface parts are integers because it has been ensured previously by the regex
            return mMarsSurfaceService.CreateMarsSurface(
                int.Parse(surfaceParts[0]),
                int.Parse(surfaceParts[1])
            );
        }

        private FunctionResult LoadRobots(string fileContent)
        {
            // File content isn't null or empty because it contains
            // the surface (checked in the previous step)
            return mRobotsService.LoadRobots(fileContent);
        }

        private bool SurfaceSizeIsCorrect(string surface)
        {
            var regexp = new Regex(SURFACE_REGEX_PATTERN);

            return surface != null
                && surface.Length > 0
                && regexp.IsMatch(surface);
        }
    }
}


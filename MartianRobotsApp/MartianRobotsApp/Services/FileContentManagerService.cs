using System;
using System.Text.RegularExpressions;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
	public partial class FileContentManagerService : IFileContentManagerService
	{
        private readonly IMarsSurfaceService mMarsSurfaceService;
        private readonly IRobotsService mRobotsService;
        private readonly IFileReaderService mFileReaderService;

        public FileContentManagerService(
            IMarsSurfaceService marsSurfaceService,
            IRobotsService robotsService,
            IFileReaderService fileReaderService)
		{
            if (marsSurfaceService == null) throw new ArgumentNullException(nameof(marsSurfaceService));
            if (robotsService == null) throw new ArgumentNullException(nameof(robotsService));
            if (fileReaderService == null) throw new ArgumentNullException(nameof(fileReaderService));

            mMarsSurfaceService = marsSurfaceService;
            mRobotsService = robotsService;
            mFileReaderService = fileReaderService;
        }

        public IFunctionResult LoadFileContent(string filePath)
		{
            var fileContentLines = Enumerable.Empty<string>();
            try
            {
                fileContentLines = mFileReaderService.ReadAllLines(filePath).ToList();
            }
            catch (Exception ex)
            {
                return new ErrorFunctionResult(string.Format(
                        ErrorMessages.ERROR_LOADING_CONTENT,
                        ex.GetType(), ex.Message));
            }

            var result = LoadMarsSurface(fileContentLines.ToList()[0]);

            if (!result.Exit)
            {
                fileContentLines = fileContentLines.Where(line => line.Length > 0).ToList();
                var desiredLines = new Range(1, fileContentLines.ToList().Count);
                result = LoadRobots(fileContentLines.Take(desiredLines).ToList());
            }

            return result;
        }

        private IFunctionResult LoadMarsSurface(string surface)
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

        private IFunctionResult LoadRobots(ICollection<string> robotsLines)
        {
            // File content isn't null or empty because it contains
            // the surface (checked in the previous step)
            return mRobotsService.LoadRobots(robotsLines);
        }

        private bool SurfaceSizeIsCorrect(string surface)
        {
            var regexp = SurfaceSizeRegex();

            return surface != null
                && surface.Length > 0
                && regexp.IsMatch(surface);
        }

        // Surface pattern: 1 or 2 digits, a blank space and 1 or 2 digits
        // in the same line, followed by a line change
        [GeneratedRegex("\\d{1,2}\\s\\d{1,2}$")]
        private static partial Regex SurfaceSizeRegex();
    }
}


using System;
using System.Text.RegularExpressions;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services.Instructions;

namespace MartianRobotsApp.Services
{
    public partial class RobotsService : IRobotsService
    {
        private readonly IEnumerable<string> mOrientationsList = Enum.GetNames<Orientation>();

        private readonly IMarsSurfaceService mMarsSurfaceService;
        private readonly IInstructionsService mInstructionsService;

        public RobotsService(
            IMarsSurfaceService marsSurfaceService,
            IInstructionsService instructionsService)
        {
            if (marsSurfaceService == null) throw new ArgumentNullException(nameof(marsSurfaceService));
            if (instructionsService == null) throw new ArgumentNullException(nameof(instructionsService));

            mMarsSurfaceService = marsSurfaceService;
            mInstructionsService = instructionsService;
        }

        public IFunctionResult LoadRobots(ICollection<string> fileContent)
        {
            IFunctionResult result = new OkFunctionResult(); ;

            for (int positionLineIndex = 0, instructionsLineIndex = 1, robotNumber = 1;
                 instructionsLineIndex < fileContent.Count && result.Exit == false;
                 positionLineIndex += 2, instructionsLineIndex += 2, robotNumber++)
            {
                var positionLine = fileContent.ElementAt(positionLineIndex);
                var instructionsLine = fileContent.ElementAt(instructionsLineIndex);

                var parts = positionLine.Split(" ");
                var x = int.Parse(parts[0]);
                var y = int.Parse(parts[1]);
                var orientation = parts[2];

                result = CheckInitialPositionFormat(robotNumber, positionLine);

                if (!result.Exit)
                {
                    result = InitialPositionValuesAreCorrect(robotNumber, x, y, orientation);
                }

                if (!result.Exit)
                {
                    result = InstructionsAreCorrect(robotNumber, instructionsLine);
                }

                if (!result.Exit)
                {
                    var newRobot = new Robot(x, y, Enum.Parse<Orientation>(orientation), instructionsLine);
                    mMarsSurfaceService.AddRobot(newRobot);
                }
            }

            return result;
        }

        private IFunctionResult CheckInitialPositionFormat(int robotNumber, string positionLine)
        {
            var regexp = InitialPositionRegex();

            if (positionLine != null
                && positionLine.Length > 0
                && regexp.IsMatch(positionLine))
            {
                return new OkFunctionResult();
            }

            return new ErrorFunctionResult(
                        string.Format(
                            ErrorMessages.INVALID_ROBOT_COORDINATES_FORMAT,
                            robotNumber,
                            positionLine)
                        );
        }

        private IFunctionResult InitialPositionValuesAreCorrect(int robotNumber, int x, int y, string orientation)
        {
            if (x < 0 || x > 50 || y < 0 || y > 50)
            {
                return new ErrorFunctionResult(string.Format(
                    ErrorMessages.INVALID_ROBOT_COORDINATES, robotNumber, x, y
                    ));
            }

            (int xSize, int ySize) = mMarsSurfaceService.GetSurfaceSize();
            if (x > xSize || y > ySize)
            {
                return new ErrorFunctionResult(string.Format(
                    ErrorMessages.ROBOT_COORDINATES_OUT_OF_BOUNDS, robotNumber, x, y
                    ));
            }

            if (!mOrientationsList.Contains(orientation.ToUpper()))
            {
                return new ErrorFunctionResult(string.Format(
                    ErrorMessages.INVALID_ROBOT_ORIENTATION, robotNumber, orientation
                    ));
            }

            return new OkFunctionResult();
        }

        private IFunctionResult InstructionsAreCorrect(int robotNumber, string instructionsLine)
        {
            IFunctionResult result = new OkFunctionResult();

            if(instructionsLine.Length >= 100)
            {
                return new ErrorFunctionResult(string.Format(
                        ErrorMessages.TOO_MUCH_LONG_INSTRUCTIONS, robotNumber, instructionsLine
                        )
                    );
            }

            foreach (char letter in instructionsLine)
            {
                if (!Enum.GetNames<EInstruction>().Contains(char.ToString(letter))
                    || !mInstructionsService.InstructionExists(letter))
                {
                    result = new ErrorFunctionResult(string.Format(
                        ErrorMessages.INVALID_ROBOT_INSTRUCTIONS, robotNumber, instructionsLine
                        )
                    );

                    break;
                }
            }

            return result;
        }

        // Position pattern: 1 or 2 digits, a blank space, 1 or 2 digits, a blank space
        // and one letter (capital or not) in the same line, followed by a line change
        [GeneratedRegex("\\d{1,2}\\s\\d{1,2}\\s([a-z]{1}|[A-Z]{1})$")]
        private static partial Regex InitialPositionRegex();
    }
}


using System;
using System.Text;
using MartianRobotsApp.Communication;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public class MarsSurfaceService : IMarsSurfaceService
    {
        private const int MAX_X = 50;
        private const int MAX_Y = 50;
        private readonly ISurfacesConnector mSurfacesConnector;
        private readonly IRobotInstructionsManagerService mRobotInstructionsManagerService;
        private readonly ICollection<Robot> mRobotsList = new List<Robot>();
        private Surface? mSurface;

        public MarsSurfaceService(
            ISurfacesConnector surfacesConnector,
            IRobotInstructionsManagerService robotInstructionsManagerService)
        {
            if (surfacesConnector is null) throw new ArgumentNullException(nameof(surfacesConnector));
            if (robotInstructionsManagerService is null) throw new ArgumentNullException(nameof(robotInstructionsManagerService));

            mSurfacesConnector = surfacesConnector;
            mRobotInstructionsManagerService = robotInstructionsManagerService;
        }

        public IFunctionResult CreateMarsSurface(int xSize, int ySize)
        {
            var result = CheckMaxAndMinSizes(xSize, ySize);

            if (result.Exit)
            {
                return result;
            }

            LoadSurfaceData(xSize, ySize);

            return new OkFunctionResult();
        }

        public void AddRobot(Robot newRobot)
        {
            mRobotsList.Add(newRobot);
        }

        public void ProcessRobotsInstructions()
        {
            for (int i = 0; i < mRobotsList.Count; i++)
            {
                Console.WriteLine($"Processing robot {i + 1}...");

                var robot = mRobotsList.ElementAt(i);
                mRobotInstructionsManagerService.ProcessRobotInstructions(robot, mSurface);

                Console.WriteLine($"Done, robot {robot.status.ToString()}");
            }
        }

        public (int, int) GetSurfaceSize()
        {
            return (mSurface.xSize, mSurface.ySize);
        }

        public string GetResults()
        {
            var result = new StringWriter(new StringBuilder());

            foreach (var robot in mRobotsList)
            {
                result.WriteLine(robot.ToString());
                result.Flush();
            }

            return result.ToString();
        }

        private IFunctionResult CheckMaxAndMinSizes(int xSize, int ySize)
        {
            if (xSize < 0 || xSize > 50)
            {
                return new ErrorFunctionResult(string.Format(ErrorMessages.INVALID_SURFACE_SIZE, "x"));
            }

            if (ySize < 0 || ySize > 50)
            {
                return new ErrorFunctionResult(string.Format(ErrorMessages.INVALID_SURFACE_SIZE, "y"));
            }

            return new OkFunctionResult();
        }

        private void LoadSurfaceData(int xSize, int ySize)
        {
            mSurface = mSurfacesConnector.GetSurfaceBySize(xSize, ySize).Result;

            if (mSurface == null)
            {
                mSurface = CreateNewSurface(xSize, ySize);
            }
        }

        private Surface? CreateNewSurface(int xSize, int ySize)
        {
            var newSurface = mSurfacesConnector.AddSurface(xSize, ySize).Result;

            return newSurface;
        }
    }
}


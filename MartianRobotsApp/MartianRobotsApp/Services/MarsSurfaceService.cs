using System;
using MartianRobotsApp.Communication;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
	public class MarsSurfaceService : IMarsSurfaceService
	{
        private const int MAX_X = 50;
        private const int MAX_Y = 50;
        private readonly ISurfacesConnector mSurfacesConnector;
        private readonly ICollection<Robot> mRobotsList = new List<Robot>();
        private Surface? surface;

		public MarsSurfaceService(ISurfacesConnector surfacesConnector)
		{
            if (surfacesConnector is null) throw new ArgumentNullException(nameof(surfacesConnector));

            this.mSurfacesConnector = surfacesConnector;
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
            surface = mSurfacesConnector.GetSurfaceBySize(xSize, ySize).Result;

            if (surface == null)
            {
                surface = CreateNewSurface(xSize, ySize);
            }
        }

        private Surface? CreateNewSurface(int xSize, int ySize)
        {
            var newSurface = mSurfacesConnector.AddSurface(xSize, ySize).Result;

            return newSurface;
        }
    }
}


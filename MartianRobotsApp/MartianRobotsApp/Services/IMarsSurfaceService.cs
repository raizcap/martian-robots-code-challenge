using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
	public interface IMarsSurfaceService
	{
		IFunctionResult CreateMarsSurface(int xSize, int ySize);

		void AddRobot(Robot newRobot);

    }
}


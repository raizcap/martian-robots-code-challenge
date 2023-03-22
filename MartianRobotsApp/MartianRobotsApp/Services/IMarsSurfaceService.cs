using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
	public interface IMarsSurfaceService
	{
		FunctionResult CreateMarsSurface(int xSize, int ySize);
	}
}


using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Communication
{
	public interface IRobotsConnector
    {
        Task AddLostRobotToSurface(LostRobot lostRobot);
    }
}


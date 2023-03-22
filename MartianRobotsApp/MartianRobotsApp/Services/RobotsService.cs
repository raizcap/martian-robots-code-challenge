using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public class RobotsService : IRobotsService
    {
        public RobotsService()
        {
        }

        public FunctionResult LoadRobots(string fileContent)
        {
            return new OkFunctionResult();
        }
    }
}


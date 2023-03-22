using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public interface IRobotsService
    {
        FunctionResult LoadRobots(string fileContent);
    }
}
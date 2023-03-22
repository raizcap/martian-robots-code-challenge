using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public interface IRobotsService
    {
        IFunctionResult LoadRobots(ICollection<string> fileContent);
    }
}
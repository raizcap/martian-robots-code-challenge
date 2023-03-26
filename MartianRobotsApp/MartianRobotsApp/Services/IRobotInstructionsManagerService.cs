using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public interface IRobotInstructionsManagerService
    {
        void ProcessRobotInstructions(Robot robot, Surface surface);
    }
}
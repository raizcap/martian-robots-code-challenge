using DB;

namespace API.Services
{
    public interface ILostRobotsService
    {
        IEnumerable<LostRobot> GetAllLostRobots();

        IEnumerable<LostRobot> GetLostRobotsOfSurface(int surfaceId);

        (bool, string) AddLostRobot(LostRobot lostRobot);
    }
}
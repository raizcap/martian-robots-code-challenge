using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public interface IFileCheckerService
    {
        IFunctionResult CheckFileName(string path);

        string GetValidPath(string givenPath);
    }
}
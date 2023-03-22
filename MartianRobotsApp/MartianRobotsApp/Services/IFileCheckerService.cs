using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public interface IFileCheckerService
    {
        FunctionResult CheckFileName(string path);

        string GetValidPath(string givenPath);
    }
}
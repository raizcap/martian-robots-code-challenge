using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public interface IFileContentManagerService
    {
        FunctionResult LoadFileContent(string filePath);
    }
}
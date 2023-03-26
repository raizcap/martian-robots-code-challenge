using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public interface IFileContentManagerService
    {
        IFunctionResult LoadFileContent(string filePath);
    }
}
namespace MartianRobotsApp.Services
{
    public interface IFileCheckerService
    {
        (bool exit, string message) CheckFileName(string path);

        (bool exit, string message) CheckFileFormat(string path);

        string GetValidPath(string givenPath);
    }
}
namespace MartianRobotsApp.Models
{
    public interface IFunctionResult
    {
        bool Exit { get; set; }
        string Message { get; set; }
    }
}
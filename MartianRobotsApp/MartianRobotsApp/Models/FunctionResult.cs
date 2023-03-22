using System;
namespace MartianRobotsApp.Models
{
    public abstract class FunctionResult : IFunctionResult
    {
        public bool Exit { get; set; }

        public string Message { get; set; } = "";

        public FunctionResult(bool exit = false, string message = "")
        {
            Exit = exit;
            Message = message;
        }
    }
}


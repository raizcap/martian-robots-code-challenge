using System;
namespace MartianRobotsApp.Models
{
	public class ErrorFunctionResult : FunctionResult
	{
		public ErrorFunctionResult(string message) : base(true, message)
		{
		}
	}
}


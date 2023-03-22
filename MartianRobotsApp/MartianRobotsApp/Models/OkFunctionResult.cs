using System;
namespace MartianRobotsApp.Models
{
	public class OkFunctionResult : FunctionResult
	{
		public OkFunctionResult() : base(false, ErrorMessages.NO_ERROR)
		{
		}
	}
}


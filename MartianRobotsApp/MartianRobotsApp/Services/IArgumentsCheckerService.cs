using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
	public interface IArgumentsCheckerService
	{
		FunctionResult CheckCommandArguments(string[] args);
	}
}


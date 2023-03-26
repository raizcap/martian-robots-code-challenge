using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
	public interface IArgumentsCheckerService
	{
		IFunctionResult CheckCommandArguments(string[] args);
	}
}


using System;
namespace MartianRobotsApp.Services
{
	public interface IArgumentsCheckerService
	{
		(bool, string) CheckCommandArguments(string[] args);
	}
}


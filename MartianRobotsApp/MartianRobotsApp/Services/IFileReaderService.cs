using System;
namespace MartianRobotsApp.Services
{
	// Wrapper for testing purposes
	public interface IFileReaderService
	{
		IEnumerable<string> ReadAllLines(string path);
	}
}


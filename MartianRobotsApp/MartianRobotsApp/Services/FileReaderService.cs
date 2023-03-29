using System;

namespace MartianRobotsApp.Services
{
    // Wrapper for testing purposes
	public class FileReaderService : IFileReaderService
	{
		public IEnumerable<string> ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}


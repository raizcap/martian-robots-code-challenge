using System;
using MartianRobotsApp.Services;

namespace MartianRobotsApp.Tests.Services.FileCheckerServiceTests
{
	[TestClass]
	public abstract class TestBase
	{
		protected FileCheckerService TestObject;

		public TestBase()
		{
			TestObject = new FileCheckerService();
		}
	}
}


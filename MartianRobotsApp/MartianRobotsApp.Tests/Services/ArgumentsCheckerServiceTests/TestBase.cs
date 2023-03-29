using System;
using MartianRobotsApp.Services;

namespace MartianRobotsApp.Tests.Services.ArgumentsCheckerServiceTests
{
	[TestClass]
	public class TestBase
	{
		protected ArgumentsCheckerService TestObject;

		public TestBase()
		{
			TestObject = new ArgumentsCheckerService();
		}
	}
}


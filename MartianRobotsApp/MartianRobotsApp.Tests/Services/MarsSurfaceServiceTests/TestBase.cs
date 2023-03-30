using System;
using MartianRobotsApp.Communication;
using MartianRobotsApp.Services;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.MarsSurfaceServiceTests
{
	[TestClass]
	public class TestBase
	{
		protected IMarsSurfaceService TestObject;
        protected ISurfacesConnector mSurfacesConnector;
        protected IRobotInstructionsManagerService mRobotInstructionsManagerService;

		public TestBase()
		{
			mSurfacesConnector = Substitute.For<ISurfacesConnector>();
			mRobotInstructionsManagerService = Substitute.For<IRobotInstructionsManagerService>();

			TestObject = new MarsSurfaceService(mSurfacesConnector, mRobotInstructionsManagerService);
		}

		protected void ResetTestObject()
		{
            TestObject = new MarsSurfaceService(mSurfacesConnector, mRobotInstructionsManagerService);
        }
	}
}


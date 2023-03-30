using System;
using MartianRobotsApp.Services;
using MartianRobotsApp.Services.Instructions;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.RobotsServiceTests
{
	[TestClass]
	public abstract class TestBase
	{
		protected IRobotsService TestObject;
		protected IMarsSurfaceService mMarsSurfaceService;
		protected IInstructionsService mInstructionsService;

        public TestBase()
		{
			mMarsSurfaceService = Substitute.For<IMarsSurfaceService>();
			mInstructionsService = Substitute.For<IInstructionsService>();

			OnInit();

			TestObject = new RobotsService(mMarsSurfaceService, mInstructionsService);
		}

		[TestInitialize]
		protected abstract void OnInit();
	}
}


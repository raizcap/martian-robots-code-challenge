using System;
using MartianRobotsApp.Services;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.FileContentManagerServiceTests
{
	[TestClass]
	public abstract class TestBase
	{
		protected FileContentManagerService TestObject;
		protected IMarsSurfaceService mMarsSurfaceService;
		protected IRobotsService mRobotsService;
		protected IFileReaderService mFileReaderService;

        public TestBase()
		{
			mMarsSurfaceService = Substitute.For<IMarsSurfaceService>();
			mRobotsService = Substitute.For<IRobotsService>();
			mFileReaderService = Substitute.For<IFileReaderService>();

			OnInit();

			TestObject = new FileContentManagerService(mMarsSurfaceService, mRobotsService, mFileReaderService);
		}

		public abstract void OnInit();
	}
}


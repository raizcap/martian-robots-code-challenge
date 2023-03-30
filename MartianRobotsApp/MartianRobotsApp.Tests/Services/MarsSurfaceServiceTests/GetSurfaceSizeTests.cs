using System;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.MarsSurfaceServiceTests
{
	[TestClass]
	public class GetSurfaceSizeTests : TestBase
	{
		[TestMethod]
		public void WhenGetSurfaceSizeIsCalled_CorrectDataIsReturned()
		{
			var xSize = 5;
			var ySize = 7;

			mSurfacesConnector.GetSurfaceBySize(Arg.Any<int>(), Arg.Any<int>())
				.Returns<Task<Surface>>(
					callInfo =>
						Task.FromResult<Surface>(GetSurface(callInfo.ArgAt<int>(0), callInfo.ArgAt<int>(1))));

            TestObject.CreateMarsSurface(xSize, ySize);

			(int surfaceXSize, int surfaceYSize) = TestObject.GetSurfaceSize();

			Assert.AreEqual(xSize, surfaceXSize);
			Assert.AreEqual(ySize, surfaceYSize);
		}

		private Surface GetSurface(int xSize, int ySize)
		{
			return new Surface(1, xSize, ySize);
		}
	}
}


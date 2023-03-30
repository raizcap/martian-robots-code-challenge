using System;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.MarsSurfaceServiceTests
{
	[TestClass]
	public class CreateMarsSurfaceTests : TestBase
	{
		[TestMethod]
        public void WhenCreateMarsSurfaceIsCalledWithNegativeXSize_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var result = TestObject.CreateMarsSurface(-1, 1);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(string.Format(ErrorMessages.INVALID_SURFACE_SIZE, "x"), result.Message);
        }

		[TestMethod]
        public void WhenCreateMarsSurfaceIsCalledWithNegativeYSize_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var result = TestObject.CreateMarsSurface(1, -1);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(string.Format(ErrorMessages.INVALID_SURFACE_SIZE, "y"), result.Message);
        }

		[TestMethod]
        public void WhenCreateMarsSurfaceIsCalledWithXSizeGreaterThan50_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var result = TestObject.CreateMarsSurface(51, 1);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(string.Format(ErrorMessages.INVALID_SURFACE_SIZE, "x"), result.Message);
        }

        [TestMethod]
        public void WhenCreateMarsSurfaceIsCalledWithYSizeGreaterThan50_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var result = TestObject.CreateMarsSurface(1, 51);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(string.Format(ErrorMessages.INVALID_SURFACE_SIZE, "y"), result.Message);
        }

        [TestMethod]
        public void WhenCreateMarsSurfaceIsCalledWithValidSizes_SurfacesConnectorGetSurfaceBySizeIsCalled()
        {
            TestObject.CreateMarsSurface(1, 1);

            mSurfacesConnector.Received().GetSurfaceBySize(1, 1);
        }

        [TestMethod]
        public void WhenCreateMarsSurfaceIsCalledWithValidSizesAndSurfaceExists_SurfacesConnectorAddSurfaceIsNotCalled()
        {
            mSurfacesConnector.GetSurfaceBySize(Arg.Any<int>(), Arg.Any<int>()).Returns<Task<Surface>>(Task.FromResult(GetSurface()));

            TestObject.CreateMarsSurface(1, 1);

            mSurfacesConnector.DidNotReceive().AddSurface(1, 1);
        }

        [TestMethod]
        public void WhenCreateMarsSurfaceIsCalledWithValidSizesAndSurfaceDoesNotExist_SurfacesConnectorAddSurfaceIsCalled()
        {
            mSurfacesConnector.GetSurfaceBySize(Arg.Any<int>(), Arg.Any<int>()).Returns<Task<Surface>>(Task.FromResult<Surface>(null));

            TestObject.CreateMarsSurface(1, 1);

            mSurfacesConnector.Received().AddSurface(1, 1);
        }

        [TestMethod]
        public void WhenCreateMarsSurfaceIsCalledWithValidSizes_ExitIsFalseAndNoErrorMessageIsReturned()
        {
            mSurfacesConnector.GetSurfaceBySize(Arg.Any<int>(), Arg.Any<int>()).Returns<Task<Surface>>(Task.FromResult(GetSurface()));

            var result = TestObject.CreateMarsSurface(1, 1);

            Assert.IsFalse(result.Exit);
            Assert.AreEqual(ErrorMessages.NO_ERROR, result.Message);
        }

        public Surface GetSurface()
        {
            return new Surface(1, 1, 1);
        }
    }
}


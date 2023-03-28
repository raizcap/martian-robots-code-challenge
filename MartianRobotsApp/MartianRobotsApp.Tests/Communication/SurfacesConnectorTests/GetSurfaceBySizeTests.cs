using System;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Communication.SurfacesConnectorTests
{
	[TestClass]
	public class GetSurfaceBySizeTests : TestBase
	{
        [TestMethod]
        public void WhenGetSurfaceBySizeIsCalled_UrlIsCorrect()
        {
            var x = 1;
            var y = 1;

            TestObject.GetSurfaceBySize(x, y).Wait();

            var url = BASE_URL + string.Format(GET_BY_SIZE, x, y);

            mHttpClient.Received().GetAsync<Surface>(url);
        }

        [TestMethod]
        public void WhenGetSurfaceBySizeIsCalled_ASurfaceIsReturned()
        {
            var x = 1;
            var y = 1;

            var surface = TestObject.GetSurfaceBySize(x, y).Result;

            Assert.IsNotNull(surface);
        }

        public override void OnInit()
        {
            var surface = new Surface()
            {
                lostRobots = new List<LostRobot>(),
                surfaceId = 1,
                xSize = 1,
                ySize = 1
            };
            mHttpClient.GetAsync<Surface>(Arg.Any<string>()).Returns<Surface>(surface);
        }
    }
}


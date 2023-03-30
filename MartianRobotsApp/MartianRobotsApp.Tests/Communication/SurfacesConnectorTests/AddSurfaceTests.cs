using System;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Communication.SurfacesConnectorTests
{
    [TestClass]
	public class AddSurfaceTests : TestBase
	{
        [TestMethod]
        public void WhenAddSurfaceIsCalled_UrlIsCorrect()
        {
            var x = 1;
            var y = 1;

            TestObject.AddSurface(x, y).Wait();

            var url = BASE_URL + string.Format(ADD, x, y);

            mHttpClient.Received().PostAsync<Surface>(url);
        }

        [TestMethod]
        public void WhenGetSurfaceBySizeIsCalled_ASurfaceIsReturned()
        {
            var x = 1;
            var y = 1;

            var surface = TestObject.AddSurface(x, y).Result;

            Assert.IsNotNull(surface);
        }

        public override void OnInit()
        {
            var surface = new Surface(1, 1, 1);

            mHttpClient.PostAsync<Surface>(Arg.Any<string>()).Returns<Surface>(surface);
        }
    }
}


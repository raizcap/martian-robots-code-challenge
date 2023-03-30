using System;
using System.Text.Json;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Communication.RobotsConnectorTests
{
	[TestClass]
	public class AddLostRobotToSurfaceTests : TestBase
	{
		private LostRobot mLostRobot;
		private string mLostRobotString;

		[TestMethod]
		public void WhenAddLostRobotToSurfaceIsCalled_UrlIsCorrect()
		{
			var url = BASE_URL + ADD;

			TestObject.AddLostRobotToSurface(mLostRobot).Wait();

			mHttpClient.Received().PostAsync(
				url,
				Arg.Is<HttpContent>(
					param => param.ReadAsStringAsync().Result.Equals(mLostRobotString)
				)
			);
		}

		[TestMethod]
		public void WhenAddLostRobotToSurface_ContentMediaTypeHeaderValueIsJson()
		{
			TestObject.AddLostRobotToSurface(mLostRobot).Wait();

			mHttpClient.Received().PostAsync(
				Arg.Any<string>(),
				Arg.Is<HttpContent>(
					param => param.Headers.ContentType.MediaType == "application/json"
				)
			);
        }

        public override void OnInit()
        {
            mLostRobot = GetLostRobot();
            mLostRobotString = GetSerializedLostRobot();
        }

		private LostRobot GetLostRobot()
		{
			return new LostRobot()
			{

                id = 1,
				xCoordinate = 1,
				yCoordinate = 1,
				orientation = "N",
				failedInstruction = "F",
				surfaceId = 1
			};
		}

		private string GetSerializedLostRobot()
		{
			return JsonSerializer.Serialize(GetLostRobot());
        }
    }
}


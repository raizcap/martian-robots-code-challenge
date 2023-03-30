using System;
using MartianRobotsApp.Communication;
using MartianRobotsApp.Services;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NSubstitute;

namespace MartianRobotsApp.Tests.Communication.RobotsConnectorTests
{
    [TestClass]
	public abstract class TestBase
	{
        protected IRobotsConnector TestObject;
        protected const string BASE_URL = "http://localhost:5005/LostRobots/";
        protected const string ADD = "AddLostRobot";
        protected readonly IHttpClientService mHttpClient;

        public TestBase()
        {
            mHttpClient = Substitute.For<IHttpClientService>();

            OnInit();

            TestObject = new RobotsConnector(mHttpClient);
        }

        [TestInitialize]
        public abstract void OnInit();
    }
}


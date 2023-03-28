using System;
using MartianRobotsApp.Communication;
using MartianRobotsApp.Services;
using NSubstitute;

namespace MartianRobotsApp.Tests.Communication.SurfacesConnectorTests
{
	[TestClass]
	public abstract class TestBase
	{
        protected ISurfacesConnector TestObject;
        protected const string BASE_URL = "http://localhost:5005/Surfaces/";
        protected const string GET_BY_SIZE = "GetSurfaceBySize?XSize={0}&YSize={1}";
        protected const string ADD = "AddSurface?XSize={0}&YSize={1}";
        protected readonly IHttpClientService mHttpClient;

        public TestBase()
        {
            mHttpClient = Substitute.For<IHttpClientService>();

            OnInit();

            TestObject = new SurfacesConnector(mHttpClient);
        }

        [TestInitialize]
        public abstract void OnInit();
    }
}


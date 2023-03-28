using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text.Json;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services;

namespace MartianRobotsApp.Communication
{
	public class RobotsConnector : IRobotsConnector
	{
        private const string BASE_URL = "http://localhost:5005/LostRobots/";
        private const string ADD = "AddLostRobot";
        private readonly IHttpClientService mHttpClient;

		public RobotsConnector(IHttpClientService httpClientService)
		{
            if (httpClientService == null) throw new ArgumentException(nameof(httpClientService));
            mHttpClient = httpClientService;
        }

        public async Task AddLostRobotToSurface(LostRobot lostRobot)
        {
            var url = BASE_URL + ADD;

            string contentString = JsonSerializer.Serialize(lostRobot);
            await mHttpClient.PostAsync(
                url,
                new StringContent(contentString, new MediaTypeHeaderValue("application/json")));
        }
    }
}


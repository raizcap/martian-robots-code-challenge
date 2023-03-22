using System;
using System.Text.Json.Serialization;

namespace MartianRobotsApp.Models
{
	public class LostRobot
	{
        public int id { get; set; }

        public int xCoordinate { get; set; }

        public int yCoordinate { get; set; }

        public string orientation { get; set; } = "";

        public int surfaceId { get; set; }

        public LostRobot()
		{
		}
	}
}


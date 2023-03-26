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

        public string failedInstruction { get; set; } = "";

        public int surfaceId { get; set; }

        public LostRobot()
		{
		}

        public static LostRobot CreateLostRobot(Robot robot, char failedInstruction, int surfaceId)
        {
            return new LostRobot()
            {
                id = 0,
                xCoordinate = robot.xCoordinate,
                yCoordinate = robot.yCoordinate,
                orientation = Enum.GetName(typeof(Orientation), robot.orientation),
                failedInstruction = char.ToString(failedInstruction),
                surfaceId = surfaceId
            };
        }
	}
}


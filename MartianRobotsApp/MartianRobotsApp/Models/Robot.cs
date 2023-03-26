using System;
namespace MartianRobotsApp.Models
{
	public class Robot
	{
		public int xCoordinate;
		public int yCoordinate;
		public Orientation orientation;
		public RobotStatus status;
		public readonly string instructions;

		public Robot(int x, int y, Orientation orientation, string instructions)
		{
			xCoordinate = x;
			yCoordinate = y;
			this.orientation = orientation;
			status = RobotStatus.REACHABLE;
			this.instructions = instructions;
		}
	}
}


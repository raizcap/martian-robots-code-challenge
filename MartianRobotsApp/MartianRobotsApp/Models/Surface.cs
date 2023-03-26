using System;
namespace MartianRobotsApp.Models
{
	public class Surface
	{
        public int surfaceId { get; set; }

        public int xSize { get; set; }

        public int ySize { get; set; }

        public ICollection<LostRobot> lostRobots { get; set; }

        public Surface()
		{
		}
	}
}


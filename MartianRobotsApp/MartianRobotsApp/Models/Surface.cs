using System;
namespace MartianRobotsApp.Models
{
	public class Surface
	{
        public int surfaceId { get; set; }

        public int xSize { get; set; }

        public int ySize { get; set; }

        public ICollection<LostRobot> lostRobots { get; set; }

        public Surface(int surfaceId, int xSize, int ySize, ICollection<LostRobot> lostRobots)
		{
			this.surfaceId = surfaceId;
			this.xSize = xSize;
			this.ySize = ySize;
			this.lostRobots = lostRobots;
		}

		public Surface(int surfaceId, int xSize, int ySize)
			: this(surfaceId, xSize, ySize, new List<LostRobot>())
		{
		}
	}
}


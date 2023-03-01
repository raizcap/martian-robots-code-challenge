using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB
{
    [Table("LostRobots")]
    public class LostRobot
	{
		public LostRobot()
		{
		}

        [Required]
        public int surfaceId { get; set; }

        [Required]
        public int xCoordinate { get; set; }

        [Required]
        public int yCoordinate { get; set; }

        [Required]
        [MaxLength(1)]
        public string Orientation { get; set; }

        [ForeignKey("surfaceId")]
        public Surface SurfaceId { get; set; }
    }
}


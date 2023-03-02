using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB
{
    [Table("Surfaces")]
    public class Surface
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int surfaceId { get; set; }

		public int xSize { get; set; }

		public int ySize { get; set; }

		public ICollection<LostRobot> LostRobots { get; set; } = new List<LostRobot>();
    }
}


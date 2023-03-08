using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB
{
    [Table("Surfaces")]
    public class Surface
	{
		public Surface()
		{
			LostRobots = new HashSet<LostRobot>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int surfaceId { get; set; }

		public int xSize { get; set; }

		public int ySize { get; set; }

		public virtual ICollection<LostRobot> LostRobots { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB
{
    [Table("LostRobots")]
    public class LostRobot
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int xCoordinate { get; set; }

        public int yCoordinate { get; set; }

        [MaxLength(1)]
        public string orientation { get; set; } = "";

        public int surfaceId { get; set; }

        public Surface surface { get; set; } = new Surface();
    }
}


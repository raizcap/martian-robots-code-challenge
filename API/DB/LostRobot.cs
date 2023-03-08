using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DB
{
    [Table("LostRobots")]
    public class LostRobot
	{
        public LostRobot()
        {
            orientation = "";
            surface = new Surface();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int xCoordinate { get; set; }

        public int yCoordinate { get; set; }

        [MaxLength(1)]
        public string orientation { get; set; } = "";

        public int surfaceId { get; set; }

        [JsonIgnore]
        public Surface surface { get; set; }
    }
}


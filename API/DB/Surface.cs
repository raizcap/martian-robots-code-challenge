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
		public int id { get; set; }

		[Required]
		public int xSize { get; set; }

		[Required]
		public int ySize { get; set; }
	}
}


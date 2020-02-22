using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_ASP.Models
{
	public class Product
	{
		public int Id { get; set; }
		
		[Required]
		[MaxLength(50)]
		public string Title { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]

		public int CategoryId { get; set; }

		public Category Category { get; set; }

	}
}

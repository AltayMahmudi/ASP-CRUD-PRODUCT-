using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product_ASP.Models;

namespace Product_ASP.Data
{
	public class ProductDBContext:DbContext
	{
		
		public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) 
		{
		
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}

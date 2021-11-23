using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;


namespace DevSearch.Models
{
	public class FavoriteContext : DbContext
	{
		public FavoriteContext():base("Favorites")
		{

		}

		public DbSet<Favorite> Favorites { get; set; }
	}
}

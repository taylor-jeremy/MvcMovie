using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new MvcMovieContext(
				serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
			{
				// Look for any movies.
				if (context.Movie.Any())
				{
					return;   // DB has been seeded
				}

				context.Movie.AddRange(
					 new Movie
					 {
						 Title = "Suits on the Loose",
						 ReleaseDate = DateTime.Parse("2005-10-14"),
						 Genre = "Comedy",
						 Price = 7.99M,
						 Rating = "PG"
					 },

					 new Movie
					 {
						 Title = "The Home Teachers",
						 ReleaseDate = DateTime.Parse("2004-1-9"),
						 Genre = "Comedy",
						 Price = 8.99M,
						 Rating = "PG"
					 },

					 new Movie
					 {
						 Title = "The Book of Mormon Volume 1: The Journey",
						 ReleaseDate = DateTime.Parse("2004-1-12"),
						 Genre = "Adventure",
						 Price = 9.99M,
						 Rating = "PG"
					 },

				   new Movie
				   {
					   Title = "17 Miracles",
					   ReleaseDate = DateTime.Parse("2011-6-3"),
					   Genre = "History",
					   Price = 3.99M,
					   Rating = "PG"
				   }
				);
				context.SaveChanges();
			}
		}
	}
}
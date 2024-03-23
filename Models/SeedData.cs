using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCApp.Data;
using System;
using System.Linq;

namespace MVCApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCAppContext(serviceProvider.GetRequiredService<DbContextOptions<MVCAppContext>>()))
            {
                //Look for any movies
                if (context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title="Toy Story",
                        ReleaseDate=DateTime.Parse("1995-02-18"),
                        Genre="Comedy/Fantasy",
                        Price=3.5M,
                        Rating="R"
                    },
                    new Movie
                    {
                        Title = "Tears of the sun",
                        ReleaseDate = DateTime.Parse("2003-03-03"),
                        Genre = "Action/Warlike",
                        Price = 2M,
                        Rating = "PG"
                    },
                    new Movie
                    {
                        Title = "Indecent Proposal",
                        ReleaseDate = DateTime.Parse("1993-02-19"),
                        Genre = "Romantic/Drama",
                        Price = 2M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "In time",
                        ReleaseDate = DateTime.Parse("2011-02-25"),
                        Genre = "Action",
                        Price = 2M,
                        Rating = "PG"
                    },
                    new Movie
                    {
                        Title = "Coco",
                        ReleaseDate = DateTime.Parse("2017-11-01"),
                        Genre = "Fantasy",
                        Price = 2M,
                        Rating = "NA"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

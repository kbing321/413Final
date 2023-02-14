using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_kbing321.Models
{
    public class MovieContext : DbContext 
    {
        //  constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base (options)
        {
            
        }

        public DbSet<MovieEntryForm> Movies { get; set; }

        // seed first three movies to db
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieEntryForm>().HasData(
                new MovieEntryForm
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieEntryForm
                {
                    MovieId = 2,
                    Category = "Drama",
                    Title = "The Prestige",
                    Year = 2006,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieEntryForm
                {
                    MovieId = 3,
                    Category = "Action/Adventure",
                    Title = "Spider-man: No Way Home",
                    Year = 2021,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
            );
        }
    }
}

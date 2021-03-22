using System;
using Microsoft.EntityFrameworkCore;

namespace TrevorSchmidtAssignment3.Models
{
    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options) : base(options)
        {

        }

        public DbSet<Movie> movies { get; set; }
    }
}

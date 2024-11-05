using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<App.Models.Movie> Movie { get; set; } = default!;
    }
}

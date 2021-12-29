using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ls.Models
{
    public class BoxesContext : DbContext
    {
        public DbSet<Box> Boxes { get; set; }
        public BoxesContext(DbContextOptions<BoxesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

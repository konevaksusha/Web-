using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LegoStore.Models
{
    public class BoxContext : DbContext
    {
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Basket> Baskets { get; set; }
    }
}
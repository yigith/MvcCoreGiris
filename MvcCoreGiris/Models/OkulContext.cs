using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Models
{
    public class OkulContext : DbContext
    {
        public OkulContext(DbContextOptions<OkulContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.; database=OkulContext; uid=sa; pwd=123");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>().HasData(
                new Kisi { Id = 1, KisiAd = "Ali" },
                new Kisi { Id = 2, KisiAd = "Cem" }
                );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Kisi> Kisiler { get; set; }
    }
}

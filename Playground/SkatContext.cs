using System;
using Microsoft.EntityFrameworkCore;
using SkatLib;
namespace Playground

{
    public class SkatContext : DbContext
    {
        public DbSet<Abend> abende { get; set; }
        public DbSet<Spiel> spiele { get; set; }
        public DbSet<Spieler> spieler { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }
    }
}
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DnD.Entities;

namespace DnD
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterItem>().HasKey(x => new { x.CharacterId, x.ItemId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
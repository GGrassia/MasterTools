using Microsoft.EntityFrameworkCore;
using DnD.Entities;

namespace DnD
{
    public class ApplicationDbContext : DbContext
    {
        // Qui dichiariamo i set (cioè le table)
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CharacterItem> CharactersItems { get; set; }
        public DbSet<CharacterUser> CharactersUsers { get; set; }

        // Questo è il constructor, che chiama il constructor base in automatico senza aggiungere nulla
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Questo metodo viene chiamato in automatico durante la creazione del model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Qui stiamo dichiarando che la table CharacterItem ha due chiavi
            // per il resto delle table la chiave è unica ed è il campo Id di tipo int, non bisogna
            // mapparla perchè lo fa EF in automatico.
            modelBuilder.Entity<CharacterItem>().HasKey(x => new { x.CharacterId, x.ItemId });
            modelBuilder.Entity<CharacterUser>().HasKey(x => new { x.CharacterId, x.UserId });

            // Chiamiamo di nuovo le funzionalità del metodo base di cui abbiamo fatto l'override
            base.OnModelCreating(modelBuilder);
        }
    }
}
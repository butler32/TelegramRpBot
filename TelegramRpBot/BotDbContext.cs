using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramRpBot.Entites;
using Microsoft.EntityFrameworkCore;
using TelegramRpBot.Configurations;

namespace TelegramRpBot
{
    public class BotDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Active> Actives { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Potion> Potions { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<Disadvantage> Disadvantages { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        public BotDbContext(DbContextOptions<BotDbContext> options)
            : base(options)
        {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new MonsterConfiguration().Configure(modelBuilder.Entity<Monster>());
            new PlayerConfiguration().Configure(modelBuilder.Entity<Player>());
            new ActiveConfiguration().Configure(modelBuilder.Entity<Active>());
            new ArmorConfiguration().Configure(modelBuilder.Entity<Armor>());
            new InventoryConfiguration().Configure(modelBuilder.Entity<Inventory>());
            new ItemConfiguration().Configure(modelBuilder.Entity<Item>());
            new PotionConfiguration().Configure(modelBuilder.Entity<Potion>());
            new WeaponConfiguration().Configure(modelBuilder.Entity<Weapon>());
            new AdvantageConfiguration().Configure(modelBuilder.Entity<Advantage>());
            new DisadvantageConfiguration().Configure(modelBuilder.Entity<Disadvantage>());
            new AbilityConfiguration().Configure(modelBuilder.Entity<Ability>());
        }
    }
}

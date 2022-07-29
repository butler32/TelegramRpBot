using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramRpBot.Entites;

namespace TelegramRpBot.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.UserId)
                .IsRequired();

            builder
                .Property(p => p.Strength)
                .IsRequired();

            builder
                .Property(p => p.Dexterity)
                .IsRequired();

            builder
                .Property(p => p.Inteligence)
                .IsRequired();

            builder
                .Property(p => p.Health)
                .IsRequired();

            builder
                .Property(p => p.HealthPoints)
                .IsRequired();

            builder
                .Property(p => p.Fatigue)
                .IsRequired();

            builder
                .Property(p => p.Points)
                .IsRequired();
            /*
            builder
                .HasOne(p => p.Inventory)
                .WithOne(p => p.Player)
                .HasForeignKey<Inventory>(p => p.PlayerId);

            builder
                .HasOne(p => p.Active)
                .WithOne(p => p.Player)
                .HasForeignKey<Active>(p => p.PlayerId);*/
        }
    }
}

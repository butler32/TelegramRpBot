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
    public class ArmorConfiguration : IEntityTypeConfiguration<Armor>
    {
        public void Configure(EntityTypeBuilder<Armor> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired();
        }
    }
}

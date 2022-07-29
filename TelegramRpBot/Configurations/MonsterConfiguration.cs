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
    class MonsterConfiguration : IEntityTypeConfiguration<Monster>
    {
        public void Configure(EntityTypeBuilder<Monster> builder)
        {
            builder
                .HasKey(i => i.Id);

            builder
                .Property(n => n.Name)
                .IsRequired();
        }
    }
}

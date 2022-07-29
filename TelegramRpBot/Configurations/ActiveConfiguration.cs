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
    public class ActiveConfiguration : IEntityTypeConfiguration<Active>
    {
        public void Configure(EntityTypeBuilder<Active> builder)
        {
            builder
                .HasKey(p => p.Id);

            /*builder
                .HasOne(p => p.Player)
                .WithOne(p => p.Active)
                .HasForeignKey<Player>(p => p.ActiveId);*/
        }
    }
}

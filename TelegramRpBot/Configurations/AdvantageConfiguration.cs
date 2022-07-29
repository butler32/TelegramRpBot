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
    class AdvantageConfiguration : IEntityTypeConfiguration<Advantage>
    {
        public void Configure(EntityTypeBuilder<Advantage> builder)
        {
            builder
                .HasKey(i => i.Id);
        }
    }
}

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
    class DisadvantageConfiguration : IEntityTypeConfiguration<Disadvantage>
    {
        public void Configure(EntityTypeBuilder<Disadvantage> builder)
        {
            builder
                .HasKey(i => i.Id);
        }
    }
}

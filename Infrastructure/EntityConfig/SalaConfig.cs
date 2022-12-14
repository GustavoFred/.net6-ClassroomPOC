using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfig
{
    internal class SalaConfig : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.Property(x => x.NumberOfSeats).IsRequired();
            builder.Property(x => x.Subject).HasMaxLength(255).IsRequired().HasDefaultValue("No Subject purpose room");
            
        }
    }
}

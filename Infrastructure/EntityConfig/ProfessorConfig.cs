using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfig
{
    public class ProfessorConfig : IEntityTypeConfiguration<Professor>
    {

        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Subject).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PIN).HasMaxLength(10).IsRequired();

        }
    }
}

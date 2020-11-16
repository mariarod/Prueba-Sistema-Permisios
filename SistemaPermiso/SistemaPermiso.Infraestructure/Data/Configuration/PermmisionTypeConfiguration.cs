using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPermiso.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Infraestructure.Data.Configuration
{

    //Permmisions type Fluent Api Implementation
    public class PermmisionTypeConfiguration : IEntityTypeConfiguration<PermmisionsType>
    {
        public void Configure(EntityTypeBuilder<PermmisionsType> builder)
        {
            builder.ToTable("TipoPermiso");
            builder.HasKey(pt => pt.Id);

            builder.Property(pt => pt.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            builder.Property(pt => pt.Description)
                .HasColumnName("Descripcion")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
                
        }
    }
}

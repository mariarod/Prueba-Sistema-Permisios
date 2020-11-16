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

    //Permmisions Fluet Api Implementations
    public class PemmisionConfiguration : IEntityTypeConfiguration<Permmisions>
    {
        public void Configure(EntityTypeBuilder<Permmisions> builder)
        {
            builder.ToTable("Permisos")
                 .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("Id");
                   

            builder.Property(p => p.EmployeeName)
                .HasColumnName("NombreEmpleado")
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(p => p.EmployeeLastName)
                .HasColumnName("ApellidosEmpleado")
                .HasMaxLength(60)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(p => p.PermmisionDate)
                .HasColumnName("FechaPermiso")
                .HasColumnType("dateTime")
                .IsRequired();

            builder.Property(p => p.PermmisionTypeId)
                   .HasColumnName("TipoPermisoId")
                   .HasColumnType("int")
                   .IsRequired();

            builder.HasOne(p => p.PermmisionsType)
                   .WithMany(b => b.Permmisions)
                   .HasForeignKey(p => p.PermmisionTypeId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Permisos_TipoPermiso");

        }
    }
}

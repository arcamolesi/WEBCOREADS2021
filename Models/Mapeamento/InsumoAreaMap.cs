using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREADS2021.Models.Dominio;

namespace WEBCOREADS2021.Models.Mapeamento
{
    public class InsumoAreaMap : IEntityTypeConfiguration<InsumoArea>
    {
        public void Configure(EntityTypeBuilder<InsumoArea> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.areaID).IsRequired();
            builder.Property(p => p.insumoID).IsRequired();
            builder.Property(p => p.data).HasColumnType("Date").IsRequired();
            builder.Property(p => p.quantidade).HasColumnType("float").IsRequired();
            builder.Property(p => p.valor).HasColumnType("float").IsRequired();

            builder.HasOne(p => p.area).WithMany(p => p.insumos).HasForeignKey(p => p.areaID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p=>p.insumo).WithMany(p=>p.areasinsumo).HasForeignKey(p=>p.insumoID).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("InsumosArea");

        }
    }
}

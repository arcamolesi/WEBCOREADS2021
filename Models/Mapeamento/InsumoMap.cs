using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREADS2021.Models.Dominio;

namespace WEBCOREADS2021.Models.Mapeamento
{
    public class InsumoMap : IEntityTypeConfiguration<Insumo>

    {
        public void Configure(EntityTypeBuilder<Insumo> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.descricao).HasMaxLength(35).IsRequired();
            builder.Property(p => p.tipoinsumo).IsRequired();
            builder.Property(p => p.quantidade).HasColumnType("float").IsRequired();
            builder.Property(p => p.valor).HasColumnType("float").IsRequired();

            builder.HasMany(p => p.areasinsumo).WithOne(p => p.insumo).HasForeignKey(p => p.insumoID).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Insumos");
        }
    }
}

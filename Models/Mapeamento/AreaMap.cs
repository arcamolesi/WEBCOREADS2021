using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREADS2021.Models.Dominio;

namespace WEBCOREADS2021.Models.Mapeamento
{
    public class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.produtorID).IsRequired(); 
            builder.Property(p => p.hectares).HasColumnType("float").IsRequired(); 
            builder.Property(p => p.bairro).HasMaxLength(25).IsRequired();
            builder.Property(p => p.municipio).HasMaxLength(25).IsRequired();
            builder.Property(p => p.gps).HasColumnType("int");

            builder.HasOne(p => p.produtor).WithMany(p => p.areas).HasForeignKey(p => p.produtorID).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Areas");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREADS2021.Models.Dominio;

namespace WEBCOREADS2021.Models.Mapeamento
{
    public class AgricultorMap : IEntityTypeConfiguration<Agricultor>
    {
        public void Configure(EntityTypeBuilder<Agricultor> builder)
        {
            builder.HasKey(p => p.id);
            builder.Property(p => p.id).ValueGeneratedOnAdd();
            builder.Property(p => p.proprietario).HasMaxLength(35).IsRequired();
            builder.Property(p => p.bairro).HasMaxLength(25).IsRequired();
            builder.Property(p => p.municipio).HasMaxLength(25).IsRequired();
            builder.Property(p => p.idade).HasColumnType("Int").IsRequired();
            builder.Property(p => p.email).HasMaxLength(35).IsRequired();
            builder.Property(p => p.cpf).HasMaxLength(14).IsRequired();
            builder.HasIndex(p => p.cpf).IsUnique();

            builder.HasMany(p => p.areas).WithOne(p => p.produtor).HasForeignKey(p => p.produtorID).OnDelete(DeleteBehavior.NoAction);

            builder.ToTable("Agricultores");
        }

        
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREADS2021.Models.Dominio;
using WEBCOREADS2021.Models.Mapeamento;
using WEBCOREADS2021.Models.Consulta;

namespace WEBCOREADS2021.Models
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Agricultor> Agricultores { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<InsumoArea> InsumosArea { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AgricultorMap());
            builder.ApplyConfiguration(new AreaMap());
            builder.ApplyConfiguration(new InsumoMap());
            builder.ApplyConfiguration(new InsumoAreaMap());
        }


        public DbSet<WEBCOREADS2021.Models.Consulta.Itens> Itens { get; set; }


        public DbSet<WEBCOREADS2021.Models.Consulta.InsumoGrp> InsumoGrp { get; set; }


        public DbSet<WEBCOREADS2021.Models.Consulta.PivotInsumoArea> PivotInsumoArea { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREADS2021.Models.Dominio;

namespace WEBCOREADS2021.Models
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Agricultor> Agricultores { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<InsumoArea> InsumosArea { get; set; }

    }
}

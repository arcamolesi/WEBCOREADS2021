using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WEBCOREADS2021.Models.Dominio
{
   
    public class InsumoArea
    {
        public int id { get; set; }
        public Area area { get; set; }
        public Insumo insumo { get; set; }
        public float quantidade { get; set; }
        public float valor { get; set; }
    }
}

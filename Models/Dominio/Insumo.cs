using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREADS2021.Models.Dominio
{
    public enum TipoInsumo {Defensivo, Adubo, Semente, Herbicida, Lubrificante, Combustível }
   
    public class Insumo
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public float quantidade { get; set; }
        public float valor { get; set; }

        public ICollection<InsumoArea> areas { get; set; }

    }
}

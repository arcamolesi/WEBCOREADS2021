using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREADS2021.Models.Dominio
{
    public class Area
    {
        public int id { get; set; }
        public Agricultor produtor { get; set; }
        public float hectares { get; set; }
        public string municipio { get; set; }
        public string bairro { get; set; }
        public int gps { get; set; }

        public ICollection<InsumoArea> insumos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREADS2021.Models.Consulta
{
    public class Itens
    {
        public int id { get; set; } //insumoarea
        public string agricultor { get; set; } //agricultor
        public string bairroArea { get; set; }//area
        public float hectares { get; set; } //area
        public string insumo { get; set; } //insumo
        public float quantidade { get; set; }//insumoarea
        public float valor { get; set; } //insumoarea
        public float total { get; set; } //calcular
    }
}

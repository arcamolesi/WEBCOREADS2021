using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREADS2021.Models.Dominio
{
    public enum TipoInsumo {Defensivo, Adubo, Semente, Herbicida, Lubrificante, Combustível }
   

    public class Insumo
    {
        public enum TipoInsumo { Adubo, Semente, Combustivel, Lubrificante, Herbicida, Inseticida, Outros }

        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(35, ErrorMessage = "Descrição tem que ter no máximo 35 caracteres")]
        [Required(ErrorMessage = "Campo Descrição é obrigatório")]
        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Tipo Insumo")]
        public TipoInsumo tipoinsumo { get; set; }


        [Display(Name = "Quantidade")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public float quantidade { get; set; }

        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public float valor { get; set; }

        public int teste { get; set; }

        public ICollection<InsumoArea> areasinsumo { get; set; }

    }
}

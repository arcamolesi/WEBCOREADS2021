using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREADS2021.Models.Dominio
{
    [Table("Area")]
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int id { get; set; }

        [Display(Name = "Produtor Rural")]
        public Agricultor produtor { get; set; }
        public int produtorID { get; set; }

        [Display(Name ="Hectares")]
        [DisplayFormat(DataFormatString ="0:F2", ApplyFormatInEditMode =true)]
        public float hectares { get; set; }

        [StringLength(25, ErrorMessage = "Tamanho de nome do bairro inválido - 25")]
        [Required(ErrorMessage = "Campo Bairro é obrigatório")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [StringLength(25, ErrorMessage = "Tamanho de nome do município inválido - 25")]
        [Required(ErrorMessage = "Campo Município é obrigatório")]
        [Display(Name = "Município")]
        public string municipio { get; set; }

        [Display(Name = "GPS")]
        public int gps { get; set; }

        public ICollection<InsumoArea> insumos { get; set; }
        ///teste
        ///
    }
}

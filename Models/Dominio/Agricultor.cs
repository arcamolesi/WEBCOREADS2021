using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCOREADS2021.Models.Dominio
{
    [Table("Agricultor")]
    public class Agricultor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int id { get; set; }

        [StringLength(35)]
        [DisplayName("Proprietario")]
        [Required(ErrorMessage ="Campo nome do proprietário é obrigatório")]
        public string proprietario { get; set; }

        public string municipio { get; set; }

        public string bairro { get; set; }
        public int idade { get; set; }

        public ICollection<Area> areas { get; set; }

    }
}

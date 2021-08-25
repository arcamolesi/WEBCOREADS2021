using Microsoft.AspNetCore.Mvc;
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
        [Key]  //metadados
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [StringLength(35, ErrorMessage = "Tamanho de nome proprietario inválido", MinimumLength = 5)]
        [Required(ErrorMessage = "Campo Nome Proprietário é obrigatório")]
        [Display(Name = "Nome do Proprietário")]
        public string proprietario { get; set; }

        [StringLength(25, ErrorMessage = "Tamanho de nome do bairro inválido - 25")]
        [Required(ErrorMessage = "Campo Bairro é obrigatório")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [StringLength(25, ErrorMessage = "Tamanho de nome do município inválido - 25")]
        [Required(ErrorMessage = "Campo Município é obrigatório")]
        [Display(Name = "Município")]
        public string municipio { get; set; }

        [Range(minimum: 18, maximum: 90, ErrorMessage = "Idade entre 18 e 90 anos...")]
        [Display(Name = "Idade")]
        public int idade { get; set; }

        [Display(Name = "E-Mail")]
        [StringLength(35, ErrorMessage = "E-Mail maior que 35 caracteres")]
        //[DataType(DataType.EmailAddress, ErrorMessage ="E-Mail Inválido....")]
        [RegularExpression("^[a-zA-Z0-9_+-]+[a-zA-Z0-9._+-]*[a-zA-Z0-9_+-]+@[a-zA-Z0-9_+-]+[a-zA-Z0-9._+-]*[.]{1,1}[a-zA-Z]{2,}$", ErrorMessage = "Email invalido")]
        public string email { get; set; }

        [Display(Name ="CPF")]
        [StringLength(14, ErrorMessage ="Não aceita CPF com mais de 14 dígitos")]
        [Remote("ValidarCPF", "Agricultores", ErrorMessage ="CPF Inválido!!!")]
        public string cpf { get; set; }

        public ICollection<Area> areas { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREADS2021.Models;
using WEBCOREADS2021.Models.Dominio;
using ExcelDataReader;
using System.Text;

namespace WEBCOREADS2021.Controllers
{
 
    public class DadosController : Controller
    {
        private readonly Contexto contexto; 

        public DadosController(Contexto context)
        {
            contexto = context; 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GerarAgricultores()
        {
            Random randNum = new Random(); 
           
            string[] vNomes = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vMun = { "Assis", "Candido Mota", "Taruma", "Palmital", "Paraguaçu", "Maracai" }; 
            for (int i=0; i<50; i++)
            {
                Agricultor agricultor = new Agricultor();
                agricultor.proprietario = vNomes[i];
                agricultor.municipio = vMun[randNum.Next()%6]; // randNum.Next(0,5)
                agricultor.bairro = "Bairro " + randNum.Next(1, 15).ToString();
                agricultor.idade = (randNum.Next() % 66 ) + 25; //randNum.Next(25, 90)
                agricultor.email = vNomes[i] + "@.com.br";
                agricultor.cpf = randNum.Next(1, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(10, 99).ToString();
                contexto.Agricultores.Add(agricultor); 
            }
            contexto.SaveChanges(); 
            return View(contexto.Agricultores.ToList()); 
        }

        public IActionResult GerarInsumos()
        {
            Random randNum = new Random();
            Encoding encType = Encoding.GetEncoding("utf-8");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = System.IO.File.Open("Insumos1.xlsx", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);
            reader.Read(); //ler a primeira linha de cabeçalho e ignora
            ///DBCC CHECKIDENT (Agricultores, RESEED, 0)
            int i = 0; 
           
            while (i<4)
            {
               reader.Read(); 
                if (reader[0].ToString() != string.Empty)
                {
                    Insumo insumo = new Insumo();
                    insumo.descricao = reader[0].ToString().Trim();
                    insumo.tipoinsumo = TipoInsumo.Herbicida;
                    insumo.quantidade = randNum.Next(0, 1000);
                    try
                    {
                        insumo.valor = Convert.ToSingle(reader[2].ToString());
                    }
                    catch 
                    {
                        insumo.valor = 100;
                    }
                  
                    contexto.Insumos.Add(insumo);
                    i = i + 1; 
                }
                contexto.SaveChanges(); 
            }


            return View(contexto.Insumos.ToList()); 
        }

    }
}

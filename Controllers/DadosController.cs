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

        public IActionResult gerarAgricultores()
        {
            Random randNum = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Bernardo", "Heitor", "Davi", "Lorenzo", "Théo", "Pedro", "Gabriel", "Enzo", "Matheus", "Lucas", "Benjamin", "Nicolas", "Guilherme", "Rafael", "Joaquim", "Samuel", "Enzo Gabriel", "João Miguel", "Henrique", "Gustavo", "Murilo", "Pedro Henrique", "Pietro", "Lucca", "Felipe", "João Pedro", "Isaac", "Benício", "Daniel", "Anthony", "Leonardo", "Davi Lucca", "Bryan", "Eduardo", "João Lucas", "Victor", "João", "Cauã", "Antônio", "Vicente", "Caleb", "Gael", "Bento", "Caio", "Emanuel", "Vinícius", "João Guilherme", "Davi Lucas", "Noah", "João Gabriel", "João Victor", "Luiz Miguel", "Francisco", "Kaique", "Otávio", "Augusto", "Levi", "Yuri", "Enrico", "Thiago", "Ian", "Victor Hugo", "Thomas", "Henry", "Luiz Felipe", "Ryan", "Arthur Miguel", "Davi Luiz", "Nathan", "Pedro Lucas", "Davi Miguel", "Raul", "Pedro Miguel", "Luiz Henrique", "Luan", "Erick", "Martin", "Bruno", "Rodrigo", "Luiz Gustavo", "Arthur Gabriel", "Breno", "Kauê", "Enzo Miguel", "Fernando", "Arthur Henrique", "Luiz Otávio", "Carlos Eduardo", "Tomás", "Lucas Gabriel", "André", "José", "Yago", "Danilo", "Anthony Gabriel", "Ruan", "Miguel Henrique", "Oliver" };
            string[] vNomeFem = { "Alice", "Sophia", "Helena", "Valentina", "Laura", "Isabella", "Manuela", "Júlia", "Heloísa", "Luiza", "Maria Luiza", "Lorena", "Lívia", "Giovanna", "Maria Eduarda", "Beatriz", "Maria Clara", "Cecília", "Eloá", "Lara", "Maria Júlia", "Isadora", "Mariana", "Emanuelly", "Ana Júlia", "Ana Luiza", "Ana Clara", "Melissa", "Yasmin", "Maria Alice", "Isabelly", "Lavínia", "Esther", "Sarah", "Elisa", "Antonella", "Rafaela", "Maria Cecília", "Liz", "Marina", "Nicole", "Maitê", "Isis", "Alícia", "Luna", "Rebeca", "Agatha", "Letícia", "Maria-", "Gabriela", "Ana Laura", "Catarina", "Clara", "Ana Beatriz", "Vitória", "Olívia", "Maria Fernanda", "Emilly", "Maria Valentina", "Milena", "Maria Helena", "Bianca", "Larissa", "Mirella", "Maria Flor", "Allana", "Ana Sophia", "Clarice", "Pietra", "Maria Vitória", "Maya", "Laís", "Ayla", "Ana Lívia", "Eduarda", "Mariah", "Stella", "Ana", "Gabrielly", "Sophie", "Carolina", "Maria Laura", "Maria Heloísa", "Maria Sophia", "Fernanda", "Malu", "Analu", "Amanda", "Aurora", "Maria Isis", "Louise", "Heloise", "Ana Vitória", "Ana Cecília", "Ana Liz", "Joana", "Luana", "Antônia", "Isabel", "Bruna" };
            string[] vMunicipio = { "Assis", "Candido Mota", "Taruma", "Paraguaçu", "Palmital", "Pedrinhas", "Maracai", "Cruzalia" };
            string[] vDominio = { "UOL", "Globo", "FEMA", "FEMANET", "GMAIL", "yahoo" };
            for (int i = 0; i < 100; i++)
            {
                Agricultor agricultor = new Agricultor();

                agricultor.proprietario = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                agricultor.bairro = "Bairro " + randNum.Next(1, 6).ToString();    //(randNum.Next() % 6)+1; 
                agricultor.municipio = vMunicipio[randNum.Next() % 8];
                agricultor.email = agricultor.proprietario.ToLower() + "@" + vDominio[randNum.Next() % 6].ToLower() + ".com.br";
                agricultor.idade = randNum.Next() % 66 + 25;   //Next(25, 90); 
                agricultor.cpf = randNum.Next(1, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "-" + randNum.Next(1, 99);

                contexto.Agricultores.Add(agricultor);
            }
            contexto.SaveChanges();

            return View(contexto.Agricultores.OrderBy(o => o.proprietario).ToList());
        }

        public IActionResult gerarInsumos()
        {
            Random randNum = new Random();
            Encoding encode = Encoding.GetEncoding("iso-8859-1");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var stream = System.IO.File.Open("Insumos.xlsx", System.IO.FileMode.Open, System.IO.FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);

            string valStr;
            string valDesc;
            int tam;

            reader.Read(); //ler a primeira linha e ignora pois é o cabeçalho 

            do
            {
                while (reader.Read())
                {
                    Insumo insumo = new Insumo();

                    valDesc = reader[0].ToString().Replace("+", "");  /// reader[0] significa a coluna A
                    tam = valDesc.Length;

                    try
                    {
                        if (tam > 0)
                            if (tam < 35)
                                insumo.descricao = valDesc;
                            else insumo.descricao = valDesc.Substring(0, 35);
                        else insumo.descricao = "nulo";
                    }
                    catch
                    {

                        insumo.descricao = "Campo com erro";
                    }


                    if (reader[1].ToString().ToLower().Equals("inseticida") == true)  // reader[1] significa coluna B
                        insumo.tipoinsumo = Insumo.TipoInsumo.Inseticida;
                    else if (reader[1].ToString().ToLower().Equals("herbicida") == true)
                        insumo.tipoinsumo = Insumo.TipoInsumo.Herbicida;
                    else if (reader[1].ToString().ToLower().Equals("semente") == true)
                        insumo.tipoinsumo = Insumo.TipoInsumo.Semente;
                    else if (reader[1].ToString().ToLower().Equals("inoculante") == true)
                        insumo.tipoinsumo = Insumo.TipoInsumo.Inoculante;
                    else if (reader[1].ToString().ToLower().Equals("maquina") == true)
                        insumo.tipoinsumo = Insumo.TipoInsumo.Maquina;
                    else if (reader[1].ToString().ToLower().Equals("implemento") == true)
                        insumo.tipoinsumo = Insumo.TipoInsumo.Implemento;
                    else insumo.tipoinsumo = Insumo.TipoInsumo.Outros;

                    insumo.quantidade = randNum.Next(0, 1000);

                    valStr = reader[2].ToString().Replace(".", "");
                    try
                    {
                        insumo.valor = Convert.ToSingle(valStr);
                    }
                    catch
                    {
                        insumo.valor = 100;
                    }
                    contexto.Insumos.Add(insumo);

                }
                contexto.SaveChanges();

            } while (reader.NextResult());

            return View(contexto.Insumos.ToList());
        }


        public IActionResult gerarAreas()
        {
            Random randNUm = new Random();
            int prod;
            string[] vMunicipio = { "Assis", "Candido Mota", "Taruma", "Paraguaçu", "Palmital", "Pedrinhas", "Maracai", "Cruzalia" };

            for (int i = 0; i < 1000; i++)
            {
                Area area = new Area();
                prod = randNUm.Next(1, 100);
                area.produtorID = prod;
                area.produtor = contexto.Agricultores.Find(prod);
                area.hectares = randNUm.Next(1, 20000);
                area.municipio = vMunicipio[randNUm.Next() % 8];
                area.bairro = "Bairro" + randNUm.Next(1, 10).ToString();
                area.gps = randNUm.Next();

                contexto.Areas.Add(area);
            }

            contexto.SaveChanges();
            return View();
        }

        public IActionResult GerarInsumosAreas()
        {
            Random randNum = new Random();

            for (int i = 0; i < 10000; i++)
            {
                InsumoArea insArea = new InsumoArea();

                insArea.areaID = randNum.Next(1, 1000);
                insArea.area = contexto.Areas.Find(insArea.areaID);

                insArea.insumoID = randNum.Next(1, 60);
                Insumo insumo = contexto.Insumos.Find(insArea.insumoID);
                insArea.insumo = insumo;

                DateTime data = Convert.ToDateTime("01/01/2015");
                insArea.data = data.AddDays(randNum.Next(1, 2450));

                int max = Convert.ToInt32(insumo.quantidade);
                insArea.quantidade = randNum.Next(1, max);

                insArea.valor = insumo.valor;

                contexto.InsumosArea.Add(insArea);

            }
            contexto.SaveChanges();
            return View();
        }

    }
}

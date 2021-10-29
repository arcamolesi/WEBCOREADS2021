using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WEBCOREADS2021.Extra;
using WEBCOREADS2021.Models;
using WEBCOREADS2021.Models.Consulta;
using WEBCOREADS2021.Models.Dominio;

namespace WEBCOREADS2021.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly Contexto contexto; 

        public ConsultaController(Contexto context)
        {
            contexto = context; 
        }

        public IActionResult PivotInsArea()
        {
            IEnumerable<InsumoGrp> lstInsByArea = from item in contexto.InsumosArea
                                      .Include(a => a.area).Include(agr => agr.area.produtor)
                                      .ToList()
                                                  group item by new { item.area.produtor.proprietario, item.area.bairro }
                                      into grupo
                                                  orderby grupo.Key.proprietario, grupo.Key.bairro
                                                  select new InsumoGrp
                                                  {
                                                      agricultor = grupo.Key.proprietario,
                                                      area = grupo.Key.bairro,
                                                      total = grupo.Sum(p => p.quantidade * p.valor)
                                                  };

            var PivotTableInsArea = lstInsByArea.ToList().ToPivotTable(
                                                           pivo => pivo.area,  //coluna
                                                           pivo => pivo.agricultor, // linha
                                                           pivo => pivo.Any() ? pivo.Sum(x => x.total) : 0); ;//valor do pivot

            List<PivotInsumoArea> lista = new List<PivotInsumoArea>();
            lista = (from DataRow coluna in PivotTableInsArea.Rows
                     select new PivotInsumoArea()
                     {
                         agricultor = coluna[0].ToString(),
                         Bairro1 = Convert.ToSingle(coluna[1]),
                         Bairro2 = Convert.ToSingle(coluna[2]),
                         Bairro3 = Convert.ToSingle(coluna[3]),
                         Bairro4 = Convert.ToSingle(coluna[4]),
                         Bairro5 = Convert.ToSingle(coluna[5]),
                         Bairro6 = Convert.ToSingle(coluna[6]),
                         Bairro7 = Convert.ToSingle(coluna[7]),
                         Bairro8 = Convert.ToSingle(coluna[8]),
                         Bairro9 = Convert.ToSingle(coluna[9])
                     }).ToList();
            return View(lista); 
        }

        [HttpGet("/Consulta/agruparinsarea")]
        public IActionResult AgruparInsumosArea()
        {
            IEnumerable<InsumoGrp> lstInsByArea = from item in contexto.InsumosArea
                                                  .Include(a => a.area).Include(agr => agr.area.produtor)
                                                  .ToList()
                                                  group item by new { item.area.produtor.proprietario, item.area.bairro }
                                                  into grupo
                                                  orderby grupo.Key.proprietario, grupo.Key.bairro
                                                  select new InsumoGrp
                                                  {
                                                      agricultor = grupo.Key.proprietario,
                                                      area = grupo.Key.bairro,
                                                      total = grupo.Sum(p=>p.quantidade*p.valor)
                                                  };
            return View(lstInsByArea); 
        }

        [HttpGet("/Consulta/ListarItens/{produtorId}")]
        public IActionResult ListarItensInsumoArea(int produtorId)
        {
            IEnumerable<Itens> lstItens = from item in contexto.InsumosArea
                                          .Include(a => a.area)
                                          .Include(p => p.area.produtor)
                                          .Include(i=>i.insumo)
                                          .Where(p=>p.area.produtorID == produtorId)
                                          .OrderBy(agr => agr.area.produtor.proprietario)
                                          .ThenBy(i => i.insumo)
                                          .ThenByDescending(iq => iq.quantidade)
                                          .ToList()
                                          select new Itens {
                                              id = item.id,
                                              agricultor = item.area.produtor.proprietario,
                                              bairroArea = item.area.bairro,
                                              hectares = item.area.hectares,
                                              insumo = item.insumo.descricao,
                                              quantidade = item.quantidade,
                                              valor = item.insumo.valor,
                                              total = item.quantidade * item.insumo.valor                                          
                                          };
            return View(lstItens); 
        }

    }
}

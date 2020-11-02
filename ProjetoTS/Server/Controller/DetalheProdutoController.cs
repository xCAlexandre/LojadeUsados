using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTS.Server;
using ProjetoTS.Shared;

namespace ProjetoTS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalheProdutoController : Controller
    {
        private readonly ApplicationDBContext db;

        public DetalheProdutoController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }

        [HttpPost]
        [Route("CDetalhe")]
        public async Task<ActionResult> Post([FromBody] DetalheProduto detalheProduto)//recebe um produto do body do Http e não do header
        {

            try
            {

                var newDProduto = new DetalheProduto
                {
                    IdProduto=detalheProduto.IdProduto,
                    Descricao = detalheProduto.Descricao,
                    TempoDeUso = detalheProduto.TempoDeUso,
                    EstadodeConservacao = detalheProduto.EstadodeConservacao


                };
                db.Add(newDProduto);
                await db.SaveChangesAsync();//insere na tabela
                return Ok();

            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpGet]
        [Route("Detalhes")] //pega o detalhe do produto
        public async Task<DetalheProduto> Get([FromQuery] string id)
        {

            var deta = await db.DetalheProdutos.SingleOrDefaultAsync(x => x.IdProduto == Convert.ToInt32(id));
            return deta;
        }
    }
}

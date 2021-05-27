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
    public class DetalheAutomovelController : Controller
    {
        private readonly ApplicationDBContext db;

        public DetalheAutomovelController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }

        [HttpPost]
        [Route("CDetalhe")]
        public async Task<ActionResult> Post([FromBody] DetalheAutomovel detalheAutomovel)//recebe um automovel do body do Http e não do header
        {

            try
            {

                var newDAutomovel = new DetalheAutomovel
                {
                    IdAutomovel=detalheAutomovel.IdAutomovel,
                    Descricao = detalheAutomovel.Descricao,
                    TempoDeUso = detalheAutomovel.TempoDeUso,
                    EstadodeConservacao = detalheAutomovel.EstadodeConservacao


                };
                db.Add(newDAutomovel);
                await db.SaveChangesAsync();//insere na tabela
                return Ok();

            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpGet]
        [Route("Detalhes")] //pega o detalhe do automovel
        public async Task<DetalheAutomovel> Get([FromQuery] string id)
        {

            var deta = await db.DetalheAutomovels.SingleOrDefaultAsync(x => x.IdAutomovel == Convert.ToInt32(id));
            return deta;
        }
    }
}

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
    public class AutomovelController : Controller
    {
        private readonly ApplicationDBContext db;

        public AutomovelController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Post([FromBody] AutomovelDTO Automovel)//recebe um Automovel do body do Http e não do header
        {
            
            try
            {

                var newAutomovel = new Automovel
                {

                    Id = Automovel.Id,
                    Nome = Automovel.Nome,
                    Preco = Automovel.Preco,
                    TagAutomovel = Automovel.TagAutomovel,
                    DetalheAutomovel=Automovel.DetalheAutomovel,
                    Usuario=Automovel.Usuario,
                    IdUsuario = Convert.ToInt32(Automovel.IdUsuario)
                  
                };
                db.Add(newAutomovel);
                await db.SaveChangesAsync();//insere na tabela
                return Ok();

            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Get() //o tipo de retorno dessa ação
        {
            var Automovels = await db.Automovels.ToListAsync();//resulta em uma Lista de Automovels
            return Ok(Automovels);
        }

        [HttpGet]
        [Route("PegaId")] //pega um Automovel pelo id
        public async Task<Automovel> Get([FromQuery] string id)
        {
            var Automovel = await db.Automovels.SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
            return Automovel;
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Put([FromBody] Automovel Automovel) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(Automovel).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw (ex);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<ActionResult<Automovel>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Automovel = await db.Automovels.FindAsync(id);
            if (Automovel == null)
            {
                return NotFound();
            }
            db.Automovels.Remove(Automovel);
            await db.SaveChangesAsync();
            return Ok(Automovel);
        }
    }
}

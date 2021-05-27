using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTS.Shared;
using ProjetoTS.Server;

namespace ProjetoTS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagAutomovelController : Controller
    {
        private readonly ApplicationDBContext db;
        public TagAutomovelController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }
    
    [HttpPost]
    [Route("AddTag")]
    public async Task<ActionResult> Post([FromBody] TagAutomovelDTO tagautomovel)
        {
            try
            {
                var newTagAutomovel = new TagAutomovel
                {
                    TagId = Convert.ToInt32(tagautomovel.TagId), //Id da tag
                    Id = Convert.ToInt32(tagautomovel.Id),//Id do automovel
                    tag = tagautomovel.tag,
                    automovel = tagautomovel.automovel
                };
                db.Add(newTagAutomovel);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }



        [HttpGet]
        [Route("LTagAutomovel")]
        public async Task<IActionResult> Get() //o tipo de retorno dessa ação
        {
            var tgp = await db.TagAutomovels.ToListAsync();//resulta em uma Lista de Automovels
            return Ok(tgp);
        }

        /*
        [HttpGet]
        [Route("ListarTagAutomovel")]
        public async Task<TagAutomovel> Get() //o tipo de retorno dessa ação
        {
            Console.WriteLine("Entrou");
            //var automovels = db.Automovels.Include(x => x.TagAutomovel).ThenInclude(x => x.tag).ToList();
            var automovels = db.TagAutomovels.SingleOrDefault();//resulta em uma Lista de Automovels
            
            return automovels;
        }
        
       [HttpGet]
       [Route("FiltroLista")]
           public async Task<IActionResult> Get([FromBody] int Id ) //o tipo de retorno dessa ação
           {
               foreach(var item in )
               {

               }

           }

        
        [HttpGet]
        [Route("ListarTagAutomovel")] //pega um automovel pelo id
        public async Task<ActionResult<TagAutomovel>> Get(int id)
        {
            var automovel = await db.TagAutomovels.FindAsync(id);
            return Ok(automovel);
        }
        */

        [HttpGet]
        [Route("IdP")] //pega um automovel pelo id
        public async Task<Automovel> Get([FromBody]int id)
        {
            var automovel = await db.Automovels.SingleOrDefaultAsync(x => x.Id == id);
            return automovel;
        }
        /*
        [HttpGet]
        [Route("ITG")] //pega um automovel pelo id
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var automovel = await db.Tags.SingleOrDefaultAsync(x => x.TagId == id);
            return Ok(automovel);
        }*/
    }
}

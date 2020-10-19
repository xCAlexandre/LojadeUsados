using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTS.Shared;




namespace ProjetoTS.Server.Controllers
{
    [ApiController]
    [Route("controller")]
    public class TagController : Controller
    {
        private readonly ApplicationDBContext db;
        public TagController(ApplicationDBContext db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Post([FromBody] Tag tag)//recebe uma tag do body do Http e não do header
        {
            try
            {
                var newTag = new Produto
                {
                    Id = tag.TagId,
                    Nome = tag.Nome,
                    TagProduto = tag.TagProduto

            };
                db.Add(newTag);
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
            var tags = await db.Tags.ToListAsync();//resulta em uma Lista de Tags
            return Ok(tags);
        }


    }
}
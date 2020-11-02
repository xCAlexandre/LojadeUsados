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
    public class TagProdutoController : Controller
    {
        private readonly ApplicationDBContext db;
        public TagProdutoController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }
    
    [HttpPost]
    [Route("AddTag")]
    public async Task<ActionResult> Post([FromBody] TagProdutoDTO tagproduto)
        {
            try
            {
                var newTagProduto = new TagProduto
                {
                    TagId = Convert.ToInt32(tagproduto.TagId), //Id da tag
                    Id = Convert.ToInt32(tagproduto.Id),//Id do produto
                    tag = tagproduto.tag,
                    produto = tagproduto.produto
                };
                db.Add(newTagProduto);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }



        [HttpGet]
        [Route("LTagProduto")]
        public async Task<IActionResult> Get() //o tipo de retorno dessa ação
        {
            var tgp = await db.TagProdutos.ToListAsync();//resulta em uma Lista de Produtos
            return Ok(tgp);
        }

        /*
        [HttpGet]
        [Route("ListarTagProduto")]
        public async Task<TagProduto> Get() //o tipo de retorno dessa ação
        {
            Console.WriteLine("Entrou");
            //var produtos = db.Produtos.Include(x => x.TagProduto).ThenInclude(x => x.tag).ToList();
            var produtos = db.TagProdutos.SingleOrDefault();//resulta em uma Lista de Produtos
            
            return produtos;
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
        [Route("ListarTagProduto")] //pega um produto pelo id
        public async Task<ActionResult<TagProduto>> Get(int id)
        {
            var produto = await db.TagProdutos.FindAsync(id);
            return Ok(produto);
        }
        */

        [HttpGet]
        [Route("IdP")] //pega um produto pelo id
        public async Task<Produto> Get([FromBody]int id)
        {
            var produto = await db.Produtos.SingleOrDefaultAsync(x => x.Id == id);
            return produto;
        }
        /*
        [HttpGet]
        [Route("ITG")] //pega um produto pelo id
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var produto = await db.Tags.SingleOrDefaultAsync(x => x.TagId == id);
            return Ok(produto);
        }*/
    }
}

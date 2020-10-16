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
    public class ProdutoController : Controller
    {
        private readonly ApplicationDBContext db;

        public ProdutoController(ApplicationDBContext db)
        {
            this.db = db;
        }

        [HttpPost]
        [Route("Criar")]
        public async Task<ActionResult> Post([FromBody] Produto produto)//recebe um produto do body do Http e não do header
        {
            try
            {

                var newProduto = new Produto
                {

                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Genero = produto.Genero,
                    Descricao = produto.Descricao,
                    IdSetor = produto.IdSetor,
                    Setor = produto.Setor
                };
                db.Add(newProduto);
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
            var produtos = await db.Produtos.ToListAsync();//resulta em uma Lista de Produtos
            return Ok(produtos);
        }

        [HttpGet]
        [Route("PegaId")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var produto = await db.Produtos.SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
            return Ok(produto);
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Put([FromBody] Produto produto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(produto).State = EntityState.Modified;
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
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            db.Produtos.Remove(produto);
            await db.SaveChangesAsync();
            return Ok(produto);
        }
    }
}

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
    public class VendedorController : Controller
    {
        private readonly ApplicationDBContext db;

        public VendedorController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }

        [HttpPost]
        [Route("CVendedor")]
        public async Task<ActionResult> Post([FromBody] VendedorDTO vendedor)//recebe um produto do body do Http e não do header
        {
            try
            {
                var newVendedor = new Vendedor
                {
                    IdVendedor=Convert.ToInt32(vendedor.IdVendedor),
                    Nome=vendedor.Nome,
                    Endereco=vendedor.Endereco,
                    Produto=vendedor.Produto
                };
                db.Add(newVendedor);
                await db.SaveChangesAsync();//insere na tabela
                return Ok();

            }
            catch (Exception e)
            {
                return View(e);
            }
        }

       
        [HttpGet]
        [Route("ListVendedores")]
        public async Task<IActionResult> Get() //o tipo de retorno dessa ação
        {
            var vendedores = await db.Vendedores.ToListAsync();//resulta em uma Lista de Produtos
            return Ok(vendedores);
        }
        
    }
}

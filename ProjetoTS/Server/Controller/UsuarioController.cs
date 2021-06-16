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
    public class UsuarioController : Controller
    {
        private readonly ApplicationDBContext db;

        public UsuarioController(ApplicationDBContext db)//injeção de dependencia
        {
            this.db = db;
        }

        [HttpPost]
        [Route("CUsuario")]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO Usuario)//recebe um Automovel do body do Http e não do header
        {
            try
            {
                var newUsuario = new Usuario
                {
                    IdUsuario=Convert.ToInt32(Usuario.IdUsuario),
                    Nome=Usuario.Nome,
                    Endereco=Usuario.Endereco,
                    Cpf = Usuario.Cpf,
                    DatadeNasc = Usuario.DatadeNasc,
                    telefone = Usuario.telefone,
                    email = Usuario.email,
                    Automovel=Usuario.Automovel
                };
                db.Add(newUsuario);
                await db.SaveChangesAsync();//insere na tabela
                return Ok();

            }
            catch (Exception e)
            {
                return View(e);
            }
        }

       
        [HttpGet]
        [Route("ListUsuarios")]
        public async Task<IActionResult> Get() //o tipo de retorno dessa ação
        {
            var Usuarios = await db.Usuarios.ToListAsync();//resulta em uma Lista de Automovels
            return Ok(Usuarios);
        }

        [HttpGet]
        [Route("GetById")] //pega um Usuario pelo id
        public async Task<Usuario> Get([FromQuery] string id)
        {
            var Usuario = await db.Usuarios.SingleOrDefaultAsync(x => x.IdUsuario == Convert.ToInt32(id));
            return Usuario;
        }
        
    }
}

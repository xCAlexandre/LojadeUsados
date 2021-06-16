using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoTS.Shared
{
    public class UsuarioDTO
    {
        public string IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf {get; set;}
        public string DatadeNasc {get; set;}
        public string telefone{get;set;}
        public string email {get; set;}
        public List<Automovel> Automovel { get; set; }

    }
}

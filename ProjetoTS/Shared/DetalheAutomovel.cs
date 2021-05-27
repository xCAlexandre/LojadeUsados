using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoTS.Shared
{
    public class DetalheAutomovel
    {
        public string Descricao { get; set; }
        public string TempoDeUso { get; set; }
        public string EstadodeConservacao { get; set; }


        public int IdAutomovel { get; set; }
        public Automovel Automovel { get; set; }
    }
}

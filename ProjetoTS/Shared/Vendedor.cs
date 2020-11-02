﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoTS.Shared
{
    public class Vendedor
    {
        public int IdVendedor { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public List<Produto> Produto { get; set; }

    }
}

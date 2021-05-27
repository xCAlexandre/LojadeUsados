﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ProjetoTS.Shared
{
    public class TagAutomovelDTO
    {
        public string Id { get; set; }//id do automovel
        public string TagId { get; set; }
        public Tag tag { get; set; }
        public Automovel automovel { get; set; }

    }
}

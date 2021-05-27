using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ProjetoTS.Shared
{
    public class TagAutomovel
    {
        public int Id { get; set; }//id do automovel
        public int TagId { get; set; }
        public Tag tag { get; set; }
        public Automovel automovel { get; set; }

    }
}

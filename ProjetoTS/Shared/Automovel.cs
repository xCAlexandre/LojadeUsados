using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ProjetoTS.Shared //CADA Automovel PODERA ESTAR LIGADO À VARIAS TAGS
{
    public class Automovel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Preco { get; set; }
        public List<TagAutomovel> TagAutomovel { get; set; }//lista de tags que o Automovel vai ter
        public DetalheAutomovel DetalheAutomovel { get; set; }//Relacao 1 para 1
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ProjetoTS.Shared //CADA PRODUTO PODERA ESTAR LIGADO À VARIAS TAGS
{
    public class ProdutoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Preco { get; set; }
        public List<TagProduto> TagProduto { get; set; }//lista de tags que o produto vai ter
        public DetalheProduto DetalheProduto { get; set; }//Relacao 1 para 1
        public string IdVendedor { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ProjetoTS.Shared
{
    public class Produto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Preco { get; set; }
        public bool Genero { get; set; }
        public string Descricao { get; set; }
        
        public int IdSetor { get; set; }// o produto terá que ter uma categoria definida
        
        public Setor Setor { get; set; }
    }
}

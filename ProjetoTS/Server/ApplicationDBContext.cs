using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoTS.Shared;

namespace ProjetoTS.Server
{
    public class ApplicationDBContext : DbContext
    {
        

        
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<TagProduto> TagProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DetalheProduto> DetalheProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//criando a chave composta com fluent API
        {
            //modelBuilder.Entity<Vendedor>().HasNoKey();
              
            modelBuilder.Entity<Vendedor>().HasKey(x => new { x.IdVendedor});


            //------------------------------------------ Um pra um
            modelBuilder.Entity<DetalheProduto>().HasKey(x => new { x.IdProduto});

            modelBuilder.Entity<Produto>()
            .HasOne(a => a.DetalheProduto)
            .WithOne(a => a.Produto)
            .HasForeignKey<DetalheProduto>(c => c.IdProduto);//Fazendo a ligação de um pra um

            //------------------------------------------ Muitos Pra Muitos
            modelBuilder.Entity<TagProduto>().HasKey(x => new { x.TagId, x.Id });//Ele recebe as "primary key" das tabelas Tag e produto 


            modelBuilder.Entity<TagProduto>().HasOne(xy => xy.tag)//TagProduto tem 1 tag
                .WithMany(x => x.TagProduto)//Com muitos TagProdutos
                .HasForeignKey(xy => xy.TagId);//Com foreign key de tag

            modelBuilder.Entity<TagProduto>().HasOne(xy => xy.produto)
                .WithMany(y => y.TagProduto)
                .HasForeignKey(xy => xy.Id);
        }
    }
}
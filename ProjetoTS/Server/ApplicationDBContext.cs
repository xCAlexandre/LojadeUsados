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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagProduto>().HasKey(x => new { x.TagId, x.Id });//Ele recebe as "primary key" das tabelas Tag e produto 

            modelBuilder.Entity<TagProduto>().HasOne(xy => xy.tag)//TagProduto tem 1 tag
                .WithMany(x => x.TagProduto)//Com muitos TagProdutos
                .HasForeignKey(xy => xy.TagId);//Com foreign key de tag

            modelBuilder.Entity<TagProduto>().HasOne(xy => xy.produto)
                .WithMany(y => y.TagProduto)
                .HasForeignKey(xy => xy.Id);
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
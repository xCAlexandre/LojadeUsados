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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TagAutomovel> TagAutomovels { get; set; }
        public DbSet<Automovel> Automovels { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DetalheAutomovel> DetalheAutomovels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//criando a chave composta com fluent API
        {
            //modelBuilder.Entity<Usuario>().HasNoKey();
              
            modelBuilder.Entity<Usuario>().HasKey(x => new { x.IdUsuario});


            //------------------------------------------ Um pra um
            modelBuilder.Entity<DetalheAutomovel>().HasKey(x => new { x.IdAutomovel});

            modelBuilder.Entity<Automovel>()
            .HasOne(a => a.DetalheAutomovel)
            .WithOne(a => a.Automovel)
            .HasForeignKey<DetalheAutomovel>(c => c.IdAutomovel);//Fazendo a ligação de um pra um

            //------------------------------------------ Muitos Pra Muitos
            modelBuilder.Entity<TagAutomovel>().HasKey(x => new { x.TagId, x.Id });//Ele recebe as "primary key" das tabelas Tag e automovel 


            modelBuilder.Entity<TagAutomovel>().HasOne(xy => xy.tag)//TagAutomovel tem 1 tag
                .WithMany(x => x.TagAutomovel)//Com muitos TagAutomovels
                .HasForeignKey(xy => xy.TagId);//Com foreign key de tag

            modelBuilder.Entity<TagAutomovel>().HasOne(xy => xy.automovel)
                .WithMany(y => y.TagAutomovel)
                .HasForeignKey(xy => xy.Id);
        }
    }
}
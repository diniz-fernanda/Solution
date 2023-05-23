using Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace Infra.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base (options) 
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<PostoDeGasolina> PostoDeGasolina { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Carro>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<PostoDeGasolina>()
                .HasKey(e => e.Id);
        }
    }
}

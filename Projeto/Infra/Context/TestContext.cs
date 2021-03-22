using Domain.Entitys;
using Infra.Mappings;
using Microsoft.EntityFrameworkCore;


namespace Infra.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
      : base(options)
        {
        }
        public DbSet<ProdutoEntity> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProdutoMap(modelBuilder.Entity<ProdutoEntity>());
        }
    }
}

using DistriPack.Models;
using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace DistripackAPI.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        // public DbSet<Pedido> Pedidos { get; set; }
        // public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        // public DbSet<PedidoDetalle> Detalles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductoCategoria>()
            .HasKey(pc => new { pc.CategoriaId, pc.ProductoId, pc.ProductoSku });

            modelBuilder.Entity<ProductoCategoria>()
                .HasOne(pc => pc.Producto)
                .WithMany(p => p.ProductoCategorias)
                .HasForeignKey(pc => new { pc.ProductoId, pc.ProductoSku });

            modelBuilder.Entity<ProductoCategoria>()
                .HasOne(pc => pc.Categoria)
                .WithMany(c => c.ProductoCategorias)
                .HasForeignKey(pc => pc.CategoriaId);

            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Producto>().HasKey(c => new { c.Id, c.Sku });
            modelBuilder.Entity<Producto>().Property(p => p.Alias).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Producto>().Property(p => p.Descripcion).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Producto>().Property(p => p.Marca).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Producto>().Property(p => p.Color).HasMaxLength(50);
            modelBuilder.Entity<Producto>().Property(p => p.Material).HasMaxLength(50);
            modelBuilder.Entity<Producto>().Property(p => p.Medidas).HasMaxLength(50);
            modelBuilder.Entity<Producto>().Property(p => p.Capacidad).HasMaxLength(50);
            modelBuilder.Entity<Producto>().Property(p => p.Precio).IsRequired();
            modelBuilder.Entity<Producto>().Ignore(p => p.Categorias);

            modelBuilder.Entity<Categoria>().Property(p => p.EsRubro).IsRequired();
            modelBuilder.Entity<Categoria>().Property(p => p.Nombre).HasMaxLength(50).IsRequired();

        }
    }
}
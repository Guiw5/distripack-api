using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace DistripackAPI.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Detalle> Detalles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductoCategoria>()
                .HasKey(pc => new { pc.CategoriaId, pc.ProductoId, pc.ProductoSku });

            modelBuilder.Entity<ProductoCategoria>()
                .HasOne(pc => pc.Categoria)
                .WithMany(c => c.ProductoCategorias)
                .HasForeignKey(pc => pc.CategoriaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductoCategoria>()
                .HasOne(pc => pc.Producto)
                .WithMany(p => p.ProductoCategorias)
                .HasForeignKey(pc => new { pc.ProductoId, pc.ProductoSku })
                .OnDelete(DeleteBehavior.Cascade);

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


            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Categoria>().HasKey(p => p.Id);
            modelBuilder.Entity<Categoria>().Property(p => p.EsRubro).IsRequired();
            modelBuilder.Entity<Categoria>().Property(p => p.Nombre).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Pedido>().ToTable("Pedidos");
            modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Detalles)
                .WithOne(p => p.Pedido)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pedido>().HasOne(p => p.Cliente);
            modelBuilder.Entity<Pedido>().Property(p => p.Estado).IsRequired();
            modelBuilder.Entity<Pedido>().Property(p => p.ClienteId).IsRequired();
            modelBuilder.Entity<Pedido>().Property(p => p.FechaCreacion).IsRequired();

            modelBuilder.Entity<Detalle>().ToTable("PedidoDetalles");
            modelBuilder.Entity<Detalle>().HasKey(c => new { c.PedidoId, c.Id });
            modelBuilder.Entity<Detalle>()
                .HasOne(p => p.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(p => p.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Detalle>().HasOne(p => p.Producto);
            modelBuilder.Entity<Detalle>().Property(p => p.Cantidad).IsRequired();
            modelBuilder.Entity<Detalle>().Property(p => p.PrecioUnitario).IsRequired();
            modelBuilder.Entity<Detalle>().Property(p => p.ProductoId).IsRequired();
            modelBuilder.Entity<Detalle>().Property(p => p.ProductoSku).IsRequired();

            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Cliente>().Property(p => p.Alias).IsRequired();
            modelBuilder.Entity<Cliente>().Property(p => p.Mail).IsRequired();
        }
    }
}
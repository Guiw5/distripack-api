using DistripackAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace DistripackAPI.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Sku> Skus { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<CheckingAccount> CheckingAccounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Receipt> Receipt { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sku>().ToTable("Sku");
            modelBuilder.Entity<Sku>().HasKey(p => p.Id);
            modelBuilder.Entity<Sku>().Property(p => p.Nick).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Sku>().Property(p => p.Description).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Sku>().Property(p => p.Brand).HasMaxLength(50);
            modelBuilder.Entity<Sku>().Property(p => p.Color).HasMaxLength(20);
            modelBuilder.Entity<Sku>().Property(p => p.Material).HasMaxLength(50);
            modelBuilder.Entity<Sku>().Property(p => p.Measures).HasMaxLength(20);
            modelBuilder.Entity<Sku>().Property(p => p.Capacity).HasMaxLength(20);
            modelBuilder.Entity<Sku>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Sku>().Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Sku>().Property(p => p.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Sku>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Skus)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Nick).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Ignore(p => p.Categories);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Skus)
                .WithOne(p => p.Product);


            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>().HasKey(p => p.Id);
            modelBuilder.Entity<Category>().Property(p => p.IsCommercialType).IsRequired();
            modelBuilder.Entity<Category>().Property(p => p.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Category>().Ignore(p => p.Products);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.CategoryId, pc.ProductId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().HasOne(p => p.Client).WithMany();
            modelBuilder.Entity<Order>().Property(p => p.State).IsRequired();
            modelBuilder.Entity<Order>().Property(p => p.ClientId).IsRequired();
            modelBuilder.Entity<Order>().Property(p => p.CreatedAt).IsRequired();
            modelBuilder.Entity<Order>()
                .HasMany(p => p.Items)
                .WithOne(p => p.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<Item>().HasKey(c => c.Id);
            modelBuilder.Entity<Item>().HasOne(p => p.Sku);
            modelBuilder.Entity<Item>().Property(p => p.Quantity).IsRequired();
            modelBuilder.Entity<Item>().Property(p => p.UnitPrice).IsRequired();
            modelBuilder.Entity<Item>().Property(p => p.SkuId).IsRequired();
            modelBuilder.Entity<Item>()
               .HasOne(p => p.Order)
               .WithMany(p => p.Items)
               .HasForeignKey(p => p.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Client>().HasKey(c => c.Id);
            modelBuilder.Entity<Client>().Property(c => c.Nick).HasMaxLength(50);
            modelBuilder.Entity<Client>().Property(c => c.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Client>().Property(c => c.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Client>().Property(c => c.LastName).HasMaxLength(50);
            modelBuilder.Entity<Client>().Property(c => c.CelPhone).HasMaxLength(15);
            modelBuilder.Entity<Client>().Property(c => c.BusinessName).HasMaxLength(100);
            modelBuilder.Entity<Client>().Property(c => c.FantasyName).HasMaxLength(100);
            modelBuilder.Entity<Client>().Property(c => c.Cuit).HasMaxLength(13);
            modelBuilder.Entity<Client>().Property(c => c.Dni).HasMaxLength(11);
            modelBuilder.Entity<Client>().Property(c => c.Location).HasMaxLength(50);
            modelBuilder.Entity<Client>().Property(c => c.Address).HasMaxLength(100);
            modelBuilder.Entity<Client>().Property(c => c.PostalCode).HasMaxLength(8);
            modelBuilder.Entity<Client>().Property(c => c.Phone).HasMaxLength(10);
            modelBuilder.Entity<Client>()
                .HasOne(c => c.CheckingAccount)
                .WithOne(ca => ca.Client)
                .HasForeignKey<CheckingAccount>(ca => ca.ClientId);


            modelBuilder.Entity<CheckingAccount>().ToTable("CheckingAccount");
            modelBuilder.Entity<CheckingAccount>().HasKey(c => c.Id);
            modelBuilder.Entity<CheckingAccount>().Property(c => c.ClientId).IsRequired();
            modelBuilder.Entity<CheckingAccount>().Property(c => c.CurrentBalance).IsRequired();
            modelBuilder.Entity<CheckingAccount>().Property(c => c.CreatedAt).IsRequired();
            modelBuilder.Entity<CheckingAccount>().Property(c => c.UpdatedAt).IsRequired();

            modelBuilder.Entity<CheckingAccount>()
                .HasOne(c => c.Client)
                .WithOne(cl => cl.CheckingAccount)
                .HasForeignKey<CheckingAccount>(c => c.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<CheckingAccount>()
                .HasMany(c => c.Transactions)
                .WithOne(c => c.CheckingAccount)
                .HasForeignKey(c => c.CheckingAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Transaction>().ToTable("Transactions");
            modelBuilder.Entity<Transaction>().HasDiscriminator(t => t.Type);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);
            modelBuilder.Entity<Transaction>().HasIndex(t => t.CheckingAccountId);
            modelBuilder.Entity<Transaction>().Property(t => t.Type).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Transaction>().Property(t => t.CreatedAt).IsRequired();
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).IsRequired();
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.CheckingAccount)
                .WithMany(c => c.Transactions);

            modelBuilder.Entity<Payment>().HasBaseType<Transaction>();
            modelBuilder.Entity<Payment>().Property(p => p.PaymentAt).IsRequired();
            modelBuilder.Entity<Payment>().Property(p => p.Method).IsRequired();

            modelBuilder.Entity<Receipt>().HasBaseType<Transaction>();
            modelBuilder.Entity<Receipt>().HasOne(r => r.Order);
            modelBuilder.Entity<Receipt>().Property(r => r.OrderId).IsRequired();



        }
    }
}
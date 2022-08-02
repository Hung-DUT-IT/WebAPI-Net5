using Microsoft.EntityFrameworkCore;

namespace MyWebAPI_APP.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        #region DbSet
        public DbSet<Products> Products { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillInfor> BillInfors { get; set; }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("MyDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Bill>(e => {
                e.ToTable("Bill");
                e.HasKey(dh => dh.IdBill);
                e.Property(dh => dh.BookingDate).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NameCustomer).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<BillInfor>(e => {
                e.ToTable("BillInfor");
                e.HasKey(p => new { p.IdBill, p.IdProduct });

                e.HasOne(p => p.Bill)
                .WithMany(p => p.BillInfors)
                .HasForeignKey(p => p.IdBill)
                .HasConstraintName("FK_Bill_BillInfor");

                e.HasOne(p => p.Products)
                .WithMany(p => p.BillInfors)
                .HasForeignKey(p => p.IdProduct)
                .HasConstraintName("FK_Product_BillInfor");
            });
        }
    }
}

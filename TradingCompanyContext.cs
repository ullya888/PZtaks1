using Microsoft.EntityFrameworkCore;

namespace TradingCompany.DAL.Models
{
    public partial class TradingCompanyContext : DbContext
    {
        public TradingCompanyContext() { }

       
        public TradingCompanyContext(DbContextOptions<TradingCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
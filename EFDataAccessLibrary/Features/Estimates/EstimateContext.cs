using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Features.Estimates
{
    public class EstimateContext : DbContext
    {
        public EstimateContext(DbContextOptions options) : base(options) { }
        public DbSet<Estimate> Estimates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estimate>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(128);
            modelBuilder.Entity<Estimate>()
                .Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnType("varchar");
        }
    }
}

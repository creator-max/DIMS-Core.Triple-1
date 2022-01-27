using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Context
{
    public class DimsContext : DbContext
    {
        public DimsContext(DbContextOptions<DimsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sample> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>(entity =>
                                        {
                                            entity.HasKey(e => e.SampleId);

                                            entity.Property(e => e.Description)
                                                  .HasMaxLength(500);

                                            entity.Property(e => e.Name)
                                                  .HasMaxLength(50);
                                        });

            base.OnModelCreating(modelBuilder);
        }
    }
}
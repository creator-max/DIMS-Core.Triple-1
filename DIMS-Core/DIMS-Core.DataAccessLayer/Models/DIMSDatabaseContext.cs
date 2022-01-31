using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Models
{
    public partial class DIMSDatabaseContext : DbContext
    {
        public DIMSDatabaseContext()
        {
        }

        public DIMSDatabaseContext(DbContextOptions<DIMSDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Sample> Samples { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<VUserProfile> VUserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-5UC1O79;Database=DIMSDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direction>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sample>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Address).HasMaxLength(120);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Skype).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.DirectionId)
                    .HasConstraintName("FK_UserProfiles_Directions");
            });

            modelBuilder.Entity<VUserProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserProfiles");

                entity.Property(e => e.Address).HasMaxLength(120);

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Education).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Skype).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

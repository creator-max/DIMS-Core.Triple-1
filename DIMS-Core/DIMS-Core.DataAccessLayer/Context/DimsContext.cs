using Microsoft.EntityFrameworkCore;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.DataAccessLayer.Context
{
    public partial class DimsContext : DbContext
    {
        public DimsContext()
        {
        }

        public DimsContext(DbContextOptions<DimsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<Sample> Samples { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskState> TaskStates { get; set; }
        public virtual DbSet<TaskTrack> TaskTracks { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserTask> UserTasks { get; set; }
        public virtual DbSet<VTask> VTasks { get; set; }
        public virtual DbSet<VUserProfile> VUserProfiles { get; set; }
        public virtual DbSet<VUserProgress> VUserProgresses { get; set; }
        public virtual DbSet<VUserTask> VUserTasks { get; set; }
        public virtual DbSet<VUserTrack> VUserTracks { get; set; }

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

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.DeadlineDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TaskState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TaskTrack>(entity =>
            {
                entity.Property(e => e.TrackDate).HasColumnType("date");

                entity.Property(e => e.TrackNote)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.UserTask)
                    .WithMany(p => p.TaskTracks)
                    .HasForeignKey(d => d.UserTaskId)
                    .HasConstraintName("FK__TaskTrack__UserT__300424B4");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(50);

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

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.HasOne(d => d.State)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__UserTasks__State__33D4B598");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__UserTasks__TaskI__31EC6D26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserTasks__UserI__32E0915F");
            });

            modelBuilder.Entity<VTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vTasks");

                entity.Property(e => e.DeadlineDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TaskId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VUserProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserProfiles");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Direction)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(50);

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

            modelBuilder.Entity<VUserProgress>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserProgress");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TrackDate).HasColumnType("date");

                entity.Property(e => e.TrackNote)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(101);
            });

            modelBuilder.Entity<VUserTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserTasks");

                entity.Property(e => e.DeadlineDate).HasColumnType("datetime");

                entity.Property(e => e.Descriptions).HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VUserTrack>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUserTracks");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TrackDate).HasColumnType("date");

                entity.Property(e => e.TrackNote)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
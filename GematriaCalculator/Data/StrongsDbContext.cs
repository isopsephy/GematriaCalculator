using GematriaCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace GematriaCalculator.Data
{
    public partial class StrongsDbContext : DbContext
    {
        private readonly IWebHostEnvironment _environment;
        public string DbPath { get; }

        public StrongsDbContext(IWebHostEnvironment environment)
        {
            _environment = environment;
            DbPath = Path.Join(_environment.ContentRootPath, "Data", "strongs-sqlite3.db");
        }

        public virtual DbSet<Gematria> Gematrias { get; set; } = null!;
        public virtual DbSet<Greek> Greeks { get; set; } = null!;
        public virtual DbSet<Hebrew> Hebrews { get; set; } = null!;
        public virtual DbSet<Isopsephy> Isopsephys { get; set; } = null!;
        public virtual DbSet<Strong> Strongs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gematria>(entity =>
            {
                entity.HasKey(e => e.Letter);
            });

            modelBuilder.Entity<Greek>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Greeks");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Lemma).HasColumnType("text");

                entity.Property(e => e.Number).HasColumnType("text");

                entity.Property(e => e.Pronounce).HasColumnType("text");

                entity.Property(e => e.Xlit).HasColumnType("text");
            });

            modelBuilder.Entity<Hebrew>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Hebrews");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Lemma).HasColumnType("text");

                entity.Property(e => e.Number).HasColumnType("text");

                entity.Property(e => e.Pronounce).HasColumnType("text");

                entity.Property(e => e.Xlit).HasColumnType("text");
            });

            modelBuilder.Entity<Isopsephy>(entity =>
            {
                entity.HasKey(e => e.Letter);
            });

            modelBuilder.Entity<Strong>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.Property(e => e.Number)
                    .HasColumnType("text")
                    .HasColumnName("number");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Lemma)
                    .HasColumnType("text")
                    .HasColumnName("lemma");

                entity.Property(e => e.Pronounce)
                    .HasColumnType("text")
                    .HasColumnName("pronounce");

                entity.Property(e => e.Xlit)
                    .HasColumnType("text")
                    .HasColumnName("xlit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

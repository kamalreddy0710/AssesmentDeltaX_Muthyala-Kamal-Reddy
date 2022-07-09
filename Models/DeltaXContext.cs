using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Musictify.Models
{
    public partial class DeltaXContext : DbContext
    {
        public DeltaXContext()
        {
        }

        public DeltaXContext(DbContextOptions<DeltaXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KAMAL;Initial Catalog=DeltaX;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.ArtistName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bio)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DateofBirth).HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.ArtWork).IsUnicode(false);

                entity.Property(e => e.Artists)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DateReleased).HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SongName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyWebApi.Models
{
    public partial class MvcMovieContext1Context : DbContext
    {
        public MvcMovieContext1Context()
        {
        }

        public MvcMovieContext1Context(DbContextOptions<MvcMovieContext1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginUser> LoginUsers { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<SignupUser> SignupUsers { get; set; }
        public virtual DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=MININT-B3VJKIM;Database=MvcMovieContext1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.ToTable("LoginUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CoverPhoto)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.IsPrivate)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<SignupUser>(entity =>
            {
                entity.ToTable("SignupUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConfirmPassword).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.SongAuthor).IsRequired();

                entity.Property(e => e.SongGenre).IsRequired();

                entity.Property(e => e.Songname).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

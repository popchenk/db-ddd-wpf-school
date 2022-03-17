using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WpfDbApplication.DTOs;

#nullable disable

namespace WpfDbApplication.DbContexts
{
    public partial class BankSystemContext : DbContext
    {
        public BankSystemContext()
        {
        }

        public BankSystemContext(DbContextOptions<BankSystemContext> options)
            : base(options)
        {
        }
        public virtual DbSet<AccountDto> AccountDtos { get; set; }
        public virtual DbSet<CardDto> CardDtos { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=wpf-db.c69xzkzvbddr.us-east-1.rds.amazonaws.com;database=BankSystem;user id=admin;password=7dLjMaYjdaPmhDd6EodO", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.13-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf16")
                .UseCollation("utf16_general_ci");

            modelBuilder.Entity<AccountDto>(entity =>
            {
                entity.HasKey(e => e.Uuid)
                    .HasName("PRIMARY");

                entity.ToTable("AccountDto");

                entity.Property(e => e.Uuid)
                    .HasMaxLength(128)
                    .HasColumnName("uuid");

                entity.Property(e => e.Email)
                    .HasMaxLength(320)
                    .HasColumnName("email");

                entity.Property(e => e.Money)
                    .HasPrecision(20, 6)
                    .HasColumnName("money");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(2)
                    .HasColumnName("nationality");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

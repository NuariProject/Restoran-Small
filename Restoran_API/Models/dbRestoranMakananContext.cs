using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restoran_API.Models
{
    public partial class dbRestoranMakananContext : DbContext
    {
        public dbRestoranMakananContext()
        {
        }

        public dbRestoranMakananContext(DbContextOptions<dbRestoranMakananContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jabatan> Jabatans { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Pengguna> Penggunas { get; set; } = null!;
        public virtual DbSet<PesananDetail> PesananDetails { get; set; } = null!;
        public virtual DbSet<PesananHeader> PesananHeaders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:dbConn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jabatan>(entity =>
            {
                entity.ToTable("jabatan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Jabatan1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("jabatan");

                entity.Property(e => e.ModifiedDate).HasColumnName("modifiedDate");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("menu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");

                entity.Property(e => e.Harga)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("harga");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedDate).HasColumnName("modifiedDate");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Stok).HasColumnName("stok");
            });

            modelBuilder.Entity<Pengguna>(entity =>
            {
                entity.ToTable("pengguna");

                entity.HasIndex(e => e.Nik, "UQ__pengguna__DF97D0EDE1EC0393")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");

                entity.Property(e => e.IdJabatan).HasColumnName("idJabatan");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedDate).HasColumnName("modifiedDate");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama");

                entity.Property(e => e.Nik).HasColumnName("nik");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdJabatanNavigation)
                    .WithMany(p => p.Penggunas)
                    .HasForeignKey(d => d.IdJabatan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pengguna_jabatan");
            });

            modelBuilder.Entity<PesananDetail>(entity =>
            {
                entity.ToTable("pesananDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");

                entity.Property(e => e.IdMenu).HasColumnName("idMenu");

                entity.Property(e => e.IdPesananHeader).HasColumnName("idPesananHeader");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ModifiedDate).HasColumnName("modifiedDate");

                entity.Property(e => e.Qty).HasColumnName("qty");
            });

            modelBuilder.Entity<PesananHeader>(entity =>
            {
                entity.ToTable("pesananHeader");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CreatedDate).HasColumnName("createdDate");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsBayar).HasColumnName("isBayar");

                entity.Property(e => e.ModifiedDate).HasColumnName("modifiedDate");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("namaCustomer");

                entity.Property(e => e.NoMeja).HasColumnName("noMeja");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

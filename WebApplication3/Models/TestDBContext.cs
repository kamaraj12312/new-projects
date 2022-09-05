using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication3.Models
{
    public partial class TestDBContext : DbContext
    {
        public TestDBContext()
        {
        }

        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Market> Market { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=10.50.51.117;Initial Catalog=TestDB;User ID=bms0176;Password=Welcome@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("market");

                entity.Property(e => e.MarketAddress)
                    .HasColumnName("marketAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarketId).HasColumnName("marketID");

                entity.Property(e => e.Marketname)
                    .HasColumnName("marketname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ModelId).HasMaxLength(50);

                entity.Property(e => e.Price).HasMaxLength(50);

                entity.Property(e => e.ProdId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProdName).HasMaxLength(50);
            });

            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sales");

                entity.Property(e => e.SalesId).HasColumnName("salesID");

                entity.Property(e => e.Salesname)
                    .HasColumnName("salesname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

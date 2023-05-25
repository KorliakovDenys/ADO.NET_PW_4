using System;
using System.Collections.Generic;
using ADO.NET_PW_4.Models;
using Microsoft.EntityFrameworkCore;

namespace ADO.NET_PW_4.Context;

public partial class StoreDBContext : DbContext
{
    public StoreDBContext()
    {
    }

    public StoreDBContext(DbContextOptions<StoreDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerInterest> CustomerInterests { get; set; }

    public virtual DbSet<Interest> Interests { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<PromotionItem> PromotionItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=Store;User Id=Server;Password=qwe123;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("db_owner");

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21B767FA107C9");

            entity.ToTable("Cities", "dbo");

            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Cities__CountryI__44FF419A");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Countrie__10D1609F3B6E6443");

            entity.ToTable("Countries", "dbo");

            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tmp_ms_x__A4AE64D867C8A708");

            entity.ToTable("Customers", "dbo");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK__Customers__CityI__5070F446");
        });

        modelBuilder.Entity<CustomerInterest>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CustomerInterests", "dbo");

            entity.HasOne(d => d.Customer).WithMany()
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__CustomerI__Custo__47DBAE45");

            entity.HasOne(d => d.Interest).WithMany()
                .HasForeignKey(d => d.InterestId)
                .HasConstraintName("FK__CustomerI__Inter__4BAC3F29");
        });

        modelBuilder.Entity<Interest>(entity =>
        {
            entity.HasKey(e => e.InterestId).HasName("PK__tmp_ms_x__20832C67D8F6746B");

            entity.ToTable("Interests", "dbo");

            entity.Property(e => e.InterestName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__tmp_ms_x__52C42FCF59B2A138");

            entity.ToTable("Promotions", "dbo");

            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.PromotionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Country).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Promotion__Count__4F7CD00D");
        });

        modelBuilder.Entity<PromotionItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PromotionItems", "dbo");

            entity.HasOne(d => d.Interest).WithMany()
                .HasForeignKey(d => d.InterestId)
                .HasConstraintName("FK__Promotion__Inter__4AB81AF0");

            entity.HasOne(d => d.Promotion).WithMany()
                .HasForeignKey(d => d.PromotionId)
                .HasConstraintName("FK__Promotion__Promo__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

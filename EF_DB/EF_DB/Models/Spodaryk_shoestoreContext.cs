using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF_DB.Models
{
    public partial class Spodaryk_shoestoreContext : DbContext
    {
        public Spodaryk_shoestoreContext()
        {
        }

        public Spodaryk_shoestoreContext(DbContextOptions<Spodaryk_shoestoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalProduct> AdditionalProducts { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Crew> Crews { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DiscountCard> DiscountCards { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;
        public virtual DbSet<Shoe> Shoes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.; Database=Spodaryk_shoestore; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalProduct>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Addition__BA39E84F64CD55EC");

                entity.Property(e => e.IdProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("id_product");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.IdShoes).HasColumnName("id_shoes");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Type)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type");

                entity.HasOne(d => d.IdShoesNavigation)
                    .WithMany(p => p.AdditionalProducts)
                    .HasForeignKey(d => d.IdShoes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdditionalProducts_Shoes");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.IdBrand);

                entity.Property(e => e.IdBrand)
                    .ValueGeneratedNever()
                    .HasColumnName("id_brand");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TypeShoes)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("type_shoes");
            });

            modelBuilder.Entity<Crew>(entity =>
            {
                entity.HasKey(e => e.IdEmployee);

                entity.ToTable("Crew");

                entity.Property(e => e.IdEmployee)
                    .ValueGeneratedNever()
                    .HasColumnName("id_employee");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.Position)
                    .IsUnicode(false)
                    .HasColumnName("position");

                entity.Property(e => e.Surname)
                    .IsUnicode(false)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK_Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("id_customer");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdCard).HasColumnName("id_card");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.Surname)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.IdCardNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdCard)
                    .HasConstraintName("FK_Customers_DiscountCards");
            });

            modelBuilder.Entity<DiscountCard>(entity =>
            {
                entity.HasKey(e => e.IdCard)
                    .HasName("PK__Discount__C71FE367BB702642");

                entity.Property(e => e.IdCard)
                    .ValueGeneratedNever()
                    .HasColumnName("id_card");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Orders__DD5B8F3F41A242E4");

                entity.Property(e => e.IdOrder)
                    .ValueGeneratedNever()
                    .HasColumnName("id_order");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("datetime")
                    .HasColumnName("date_order");

                entity.Property(e => e.IdCard).HasColumnName("id_card");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdShoes).HasColumnName("id_shoes");

                entity.HasOne(d => d.IdCardNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCard)
                    .HasConstraintName("FK_Orders_DiscountCards");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Crew");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Orders_AdditionalProducts");

                entity.HasOne(d => d.IdShoesNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdShoes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Shoes");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasKey(e => e.IdProvider)
                    .HasName("PK__Provider__BCFF02345AC741FC");

                entity.Property(e => e.IdProvider)
                    .ValueGeneratedNever()
                    .HasColumnName("id_provider");

                entity.Property(e => e.DeliveryTime).HasColumnName("delivery_time");

                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

                entity.Property(e => e.Surname)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.IdBrand)
                    .HasConstraintName("FK_Providers_Brands");
            });

            modelBuilder.Entity<Shoe>(entity =>
            {
                entity.HasKey(e => e.IdShoes)
                    .HasName("PK__Shoes__E570F9530FF4BEB8");

                entity.Property(e => e.IdShoes)
                    .ValueGeneratedNever()
                    .HasColumnName("id_shoes");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.IdBrand).HasColumnName("id_brand");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Shoes)
                    .HasForeignKey(d => d.IdBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shoes_Brands");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

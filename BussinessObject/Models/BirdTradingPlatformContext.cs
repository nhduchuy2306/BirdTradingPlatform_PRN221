using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace BussinessObject.Models
{
    public partial class BirdTradingPlatformContext : DbContext
    {
        public BirdTradingPlatformContext()
        {
        }

        public BirdTradingPlatformContext(DbContextOptions<BirdTradingPlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("BirdTradingPlatformDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Password)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(1);

                entity.Property(e => e.Status).HasMaxLength(1);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.OrderParent)
                    .WithMany(p => p.InverseOrderParent)
                    .HasForeignKey(d => d.OrderParentId)
                    .HasConstraintName("FK__Order__OrderPare__2F9A1060");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK__Order__PaymentMe__2EA5EC27");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Status).HasMaxLength(1);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__336AA144");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderDeta__Produ__32767D0B");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.Property(e => e.PaymentNumber).HasMaxLength(1);

                entity.Property(e => e.PaymentType).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PaymentMethods)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__PaymentMe__UserI__2057CCD0");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.BrandName).HasMaxLength(50);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Expiration).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.MadeIn).HasMaxLength(50);

                entity.Property(e => e.Material).HasMaxLength(20);

                entity.Property(e => e.ProductName).HasMaxLength(1);

                entity.Property(e => e.Species).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__28ED12D1");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK__Product__ShopId__27F8EE98");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImage");

                entity.Property(e => e.ImageUrl).HasMaxLength(1);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductIm__Produ__2BC97F7C");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.AvatarUrl).HasMaxLength(1);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.ShopName).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(1);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Shop__Status__251C81ED");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasMaxLength(1);

                entity.Property(e => e.AvatarUrl).HasMaxLength(1);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__User__Address__1D7B6025");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

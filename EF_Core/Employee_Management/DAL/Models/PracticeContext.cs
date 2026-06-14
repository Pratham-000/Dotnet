using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class PracticeContext : DbContext
{
    public PracticeContext()
    {
    }

    public PracticeContext(DbContextOptions<PracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductModel> ProductModels { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:pratham-sql-server-1.database.windows.net,1433;Initial Catalog=Practice;User ID=Pratham-Arora;Password=Yogesh(1);Encrypt=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__091C2A1B73E8AAEB");

            entity.ToTable("Address", "SalesLT");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressLine1).HasMaxLength(60);
            entity.Property(e => e.AddressLine2).HasMaxLength(60);
            entity.Property(e => e.City).HasMaxLength(30);
            entity.Property(e => e.CountryRegion).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PostalCode).HasMaxLength(15);
            entity.Property(e => e.StateProvince).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B80DA08BAC");

            entity.ToTable("Customer", "SalesLT");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CompanyName).HasMaxLength(128);
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(25);
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => new { e.CustomerId, e.AddressId });

            entity.ToTable("CustomerAddress", "SalesLT");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.AddressType).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Address).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerAddress_Address");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerAddress_Customer");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED280EE839");

            entity.ToTable("Product", "SalesLT");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Color).HasMaxLength(15);
            entity.Property(e => e.ListPrice).HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.ProductNumber).HasMaxLength(25);

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.ProductModel).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductModelId)
                .HasConstraintName("FK_Product_Model");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK__ProductC__3224ECEEDBE5326F");

            entity.ToTable("ProductCategory", "SalesLT");

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ParentProductCategoryId).HasColumnName("ParentProductCategoryID");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.ProductModelId).HasName("PK__ProductM__DB7B7E9BE41E5C5D");

            entity.ToTable("ProductModel", "SalesLT");

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<SalesOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId });

            entity.ToTable("SalesOrderDetail", "SalesLT");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.SalesOrderDetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SalesOrderDetailID");
            entity.Property(e => e.LineTotal)
                .HasComputedColumnSql("([OrderQty]*[UnitPrice])", false)
                .HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetail_Product");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => d.SalesOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetail_Header");
        });

        modelBuilder.Entity<SalesOrderHeader>(entity =>
        {
            entity.HasKey(e => e.SalesOrderId).HasName("PK__SalesOrd__B14003C289DB05B6");

            entity.ToTable("SalesOrderHeader", "SalesLT");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.SubTotal).HasColumnType("money");
            entity.Property(e => e.TaxAmt).HasColumnType("money");
            entity.Property(e => e.TotalDue)
                .HasComputedColumnSql("(([SubTotal]+[TaxAmt])+[Freight])", false)
                .HasColumnType("money");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrderHeaders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderHeader_Customer");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VirtualWaiter.Service.Data.Models;

public partial class VirtualWaiterContext : DbContext
{
    public VirtualWaiterContext()
    {
    }

    public VirtualWaiterContext(DbContextOptions<VirtualWaiterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Eaterytable> Eaterytable { get; set; }

    public virtual DbSet<Order> Order { get; set; }

    public virtual DbSet<OrderDetail> OrderDetail { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Eaterytable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Number, "Number").IsUnique();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdEaterytable, "IdEaterytable");

            entity.HasIndex(e => e.IdUser, "IdUser");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Observation).HasMaxLength(255);

            //entity.HasOne(d => d.IdEaterytableNavigation).WithMany(p => p.Order)
            //    .HasForeignKey(d => d.IdEaterytable)
            //    .HasConstraintName("Order_ibfk_2");

            //entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Order)
            //    .HasForeignKey(d => d.IdUser)
            //    .HasConstraintName("Order_ibfk_1");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.IdOrder, "IdOrder");

            entity.HasIndex(e => e.IdProduct, "IdProduct");

            entity.Property(e => e.Observation).HasMaxLength(255);

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDetail)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("OrderDetail_ibfk_1");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderDetail)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("OrderDetail_ibfk_2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Identification, "Identification").IsUnique();

            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Identification).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.RoleCode).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

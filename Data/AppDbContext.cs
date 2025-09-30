using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaProject1pw.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TestAvalonia;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.IdBasket);

            entity.ToTable("Basket");

            entity.Property(e => e.IdBasket).HasColumnName("Id_Basket");
            entity.Property(e => e.IdItem).HasColumnName("Id_Item");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");

            entity.HasOne(d => d.IdItemNavigation).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.IdItem)
                .HasConstraintName("FK_Basket_Item");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Basket_User");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.IdItem);

            entity.ToTable("Item");

            entity.Property(e => e.IdItem).HasColumnName("Id_Item");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.NameItem).HasColumnType("text");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("PK__Login__897D1C67DE596C86");

            entity.ToTable("Login");

            entity.Property(e => e.IdLogin).HasColumnName("id_Login");
            entity.Property(e => e.IdUser).HasColumnName("id_User");
            entity.Property(e => e.Login1)
                .HasColumnType("text")
                .HasColumnName("Login");
            entity.Property(e => e.Password).HasColumnType("text");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_Login_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__Role__5E5EB16B5D5E2A94");

            entity.ToTable("Role");

            entity.Property(e => e.IdRole).HasColumnName("id_Role");
            entity.Property(e => e.NameRole).HasColumnType("text");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__55649556D0B2DEC7");

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("id_User");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.FullName).HasColumnType("text");
            entity.Property(e => e.IdRole).HasColumnName("id_Role");
            entity.Property(e => e.PhoneNumber).HasColumnType("text");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("fk_user_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

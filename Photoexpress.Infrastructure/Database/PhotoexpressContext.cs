using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Photoexpress.Domain.Entities;

namespace Photoexpress.Infrastructure.Database;

public partial class PhotoexpressContext : DbContext
{
    public PhotoexpressContext()
    {
    }

    public PhotoexpressContext(DbContextOptions<PhotoexpressContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Parameter> Parameters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ActivationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AdditionalValue).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.BaseValue).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.InstitutionAddress)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.InstitutionName)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasColumnType("bit");
            entity.Property(e => e.NumStudents).HasColumnType("int");
        });

        modelBuilder.Entity<Parameter>(entity =>
        {
            entity.HasIndex(e => e.Name, "UQ_Parameters").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ActivationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Value)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasColumnType("bit");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    public virtual DbSet<Incident> Incidents { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Example of Fluent API configuration
        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
        });


        OnModelCreatingPartial(modelBuilder);
    }

#pragma warning disable S3251 // Implementations should be provided for "partial" methods
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


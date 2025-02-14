using DomainLayer;
using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }
    public virtual DbSet<Incident> Incident { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Stakeholder> Stakeholders { get; set; }

    // Incident Types
    public DbSet<NaturalDisaster> NaturalDisasters { get; set; }
    public DbSet<CybersecurityIncident> CybersecurityIncidents { get; set; }
    public DbSet<HealthIncident> HealthIncidents { get; set; }
    public DbSet<ManMadeIncident> ManMadeIncidents { get; set; }

    // Supporting Models
    public DbSet<EmergencyResponseTeam> EmergencyResponseTeams { get; set; }
    public DbSet<Alert> Alerts { get; set; }
    public DbSet<IncidentMetrics> IncidentMetrics { get; set; }

    // Audit Models
    public DbSet<AuditLog> AuditLogs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // IncidentReport Configuration
        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Id);
      
            entity.Property(e => e.IncidentType).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Severity).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(e => e.Location)
                .WithOne()
                .HasForeignKey<Incident>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Attachments)
                .WithOne()
                .HasForeignKey(e => e.IncidentReportId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Stakeholders)
                .WithOne()
                .HasForeignKey(e => e.IncidentReportId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Location Configuration
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Country).IsRequired().HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Latitude).HasPrecision(9, 6);
            entity.Property(e => e.Longitude).HasPrecision(9, 6);
        });

      
        

        // Attachment Configuration
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FileName).IsRequired().HasMaxLength(200);
            entity.Property(e => e.FileType).HasMaxLength(50);
            entity.Property(e => e.FileData).IsRequired();
        });

        // Stakeholder Configuration
        modelBuilder.Entity<Stakeholder>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Role).HasMaxLength(100);
            entity.Property(e => e.ContactInfo).HasMaxLength(200);
        });

        // Natural Disaster Configuration
        modelBuilder.Entity<NaturalDisaster>(entity =>
        {
            entity.Property(e => e.DisasterType).HasMaxLength(100);
            entity.Property(e => e.Magnitude).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.AffectedAreas).HasMaxLength(1000);
            entity.Property(e => e.EstimatedDamage).HasColumnType("decimal(18, 2)");
        });

        // Cybersecurity Incident Configuration
        modelBuilder.Entity<CybersecurityIncident>(entity =>
        {
            entity.Property(e => e.BreachType).HasMaxLength(100);
            entity.Property(e => e.AffectedSystems).HasDefaultValue(0);
            entity.Property(e => e.DataCompromised).HasDefaultValue(0);
        });

        // Health Incident Configuration
        modelBuilder.Entity<HealthIncident>(entity =>
        {
            entity.Property(e => e.Disease).HasMaxLength(100);
            entity.Property(e => e.ConfirmedCases).HasDefaultValue(0);
            entity.Property(e => e.Fatalities).HasDefaultValue(0);
            entity.Property(e => e.Recovered).HasDefaultValue(0);
        });

        // Man-Made Incident Configuration
        modelBuilder.Entity<ManMadeIncident>(entity =>
        {
            entity.Property(e => e.AccidentType).HasMaxLength(100);
            entity.Property(e => e.Casualties).HasDefaultValue(0);
            entity.Property(e => e.EstimatedDamage).HasColumnType("decimal(18, 2)");
        });

        // Emergency Response Team Configuration
        modelBuilder.Entity<EmergencyResponseTeam>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Specialization).HasMaxLength(100);
            entity.Property(e => e.ContactNumber).HasMaxLength(15);
        });

        // Alert Configuration
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.AlertMessage).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Severity).HasMaxLength(50);
            entity.Property(e => e.Timestamp).IsRequired();
        });

        // Incident Metrics Configuration
        modelBuilder.Entity<IncidentMetrics>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.NumberOfCasualties).HasDefaultValue(0);
            entity.Property(e => e.NumberOfInjuries).HasDefaultValue(0);
            entity.Property(e => e.FinancialLoss).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RecoveryTime).HasColumnType("decimal(5, 2)");
        });

        // Audit Log Configuration
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Action).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Timestamp).IsRequired();
            entity.Property(e => e.PerformedBy).HasMaxLength(150);
        });

        modelBuilder.Entity<Incident>()
    .HasDiscriminator<string>("Discriminator")
    .HasValue<Incident>("Base")
    .HasValue<NaturalDisaster>("NaturalDisaster")
    .HasValue<CybersecurityIncident>("CybersecurityIncident")
    .HasValue<HealthIncident>("HealthIncident")
    .HasValue<ManMadeIncident>("ManMadeIncident");


        OnModelCreatingPartial(modelBuilder);
    }


#pragma warning disable S3251 // Implementations should be provided for "partial" methods
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


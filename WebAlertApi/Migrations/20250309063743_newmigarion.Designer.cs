﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebAlertApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250309063743_newmigarion")]
    partial class newmigarion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainLayer.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int?>("EmergencyResponseTeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IncidentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IncidentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Severity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EmergencyResponseTeamId");

                    b.ToTable("Incident");

                    b.HasDiscriminator().HasValue("Base");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DomainLayer.Model.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AlertMessage")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Severity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("DomainLayer.Model.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IncidentReportId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IncidentReportId");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("DomainLayer.Model.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IncidentReportId")
                        .HasColumnType("int");

                    b.Property<string>("PerformedBy")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("DomainLayer.Model.EmergencyResponseTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("EmergencyResponseTeams");
                });

            modelBuilder.Entity("DomainLayer.Model.IncidentMetrics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("FinancialLoss")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("IncidentReportId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfCasualties")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("NumberOfInjuries")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("RecoveryTime")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id");

                    b.ToTable("IncidentMetrics");
                });

            modelBuilder.Entity("DomainLayer.Model.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Latitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("float(9)");

                    b.Property<double>("Longitude")
                        .HasPrecision(9, 6)
                        .HasColumnType("float(9)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DomainLayer.Model.Stakeholder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlertId")
                        .HasColumnType("int");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IncidentReportId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AlertId");

                    b.HasIndex("IncidentReportId");

                    b.ToTable("Stakeholders");
                });

            modelBuilder.Entity("DomainLayer.Model.CybersecurityIncident", b =>
                {
                    b.HasBaseType("DomainLayer.Incident");

                    b.Property<int>("AffectedSystems")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("BreachType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DataCompromised")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasDiscriminator().HasValue("CybersecurityIncident");
                });

            modelBuilder.Entity("DomainLayer.Model.HealthIncident", b =>
                {
                    b.HasBaseType("DomainLayer.Incident");

                    b.Property<int>("ConfirmedCases")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Disease")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Fatalities")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("Recovered")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasDiscriminator().HasValue("HealthIncident");
                });

            modelBuilder.Entity("DomainLayer.Model.ManMadeIncident", b =>
                {
                    b.HasBaseType("DomainLayer.Incident");

                    b.Property<string>("AccidentType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Casualties")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("EstimatedDamage")
                        .HasColumnType("decimal(18, 2)");

                    b.HasDiscriminator().HasValue("ManMadeIncident");
                });

            modelBuilder.Entity("DomainLayer.Model.NaturalDisaster", b =>
                {
                    b.HasBaseType("DomainLayer.Incident");

                    b.Property<string>("AffectedAreas")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("DisasterType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("EstimatedDamage")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Magnitude")
                        .HasColumnType("decimal(5, 2)");

                    b.ToTable("Incident", t =>
                        {
                            t.Property("EstimatedDamage")
                                .HasColumnName("NaturalDisaster_EstimatedDamage");
                        });

                    b.HasDiscriminator().HasValue("NaturalDisaster");
                });

            modelBuilder.Entity("DomainLayer.Incident", b =>
                {
                    b.HasOne("DomainLayer.Model.EmergencyResponseTeam", null)
                        .WithMany("AssignedIncidents")
                        .HasForeignKey("EmergencyResponseTeamId");

                    b.HasOne("DomainLayer.Model.Location", "Location")
                        .WithOne()
                        .HasForeignKey("DomainLayer.Incident", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DomainLayer.Model.Attachment", b =>
                {
                    b.HasOne("DomainLayer.Incident", null)
                        .WithMany("Attachments")
                        .HasForeignKey("IncidentReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomainLayer.Model.Stakeholder", b =>
                {
                    b.HasOne("DomainLayer.Model.Alert", null)
                        .WithMany("Recipients")
                        .HasForeignKey("AlertId");

                    b.HasOne("DomainLayer.Incident", null)
                        .WithMany("Stakeholders")
                        .HasForeignKey("IncidentReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomainLayer.Incident", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Stakeholders");
                });

            modelBuilder.Entity("DomainLayer.Model.Alert", b =>
                {
                    b.Navigation("Recipients");
                });

            modelBuilder.Entity("DomainLayer.Model.EmergencyResponseTeam", b =>
                {
                    b.Navigation("AssignedIncidents");
                });
#pragma warning restore 612, 618
        }
    }
}

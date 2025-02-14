using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAlertApi.Migrations
{
    /// <inheritdoc />
    public partial class newmigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertMessage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PerformedBy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IncidentReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyResponseTeams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyResponseTeams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidentReportId = table.Column<int>(type: "int", nullable: false),
                    NumberOfCasualties = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NumberOfInjuries = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FinancialLoss = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecoveryTime = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentMetrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Latitude = table.Column<double>(type: "float(9)", precision: 9, scale: 6, nullable: false),
                    Longitude = table.Column<double>(type: "float(9)", precision: 9, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IncidentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    EmergencyResponseTeamId = table.Column<int>(type: "int", nullable: true),
                    BreachType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AffectedSystems = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    DataCompromised = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Disease = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConfirmedCases = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Fatalities = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Recovered = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    AccidentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Casualties = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    EstimatedDamage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DisasterType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Magnitude = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AffectedAreas = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NaturalDisaster_EstimatedDamage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incident_EmergencyResponseTeams_EmergencyResponseTeamId",
                        column: x => x.EmergencyResponseTeamId,
                        principalTable: "EmergencyResponseTeams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incident_Locations_Id",
                        column: x => x.Id,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IncidentReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Incident_IncidentReportId",
                        column: x => x.IncidentReportId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stakeholders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IncidentReportId = table.Column<int>(type: "int", nullable: false),
                    AlertId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stakeholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stakeholders_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stakeholders_Incident_IncidentReportId",
                        column: x => x.IncidentReportId,
                        principalTable: "Incident",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_IncidentReportId",
                table: "Attachments",
                column: "IncidentReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_EmergencyResponseTeamId",
                table: "Incident",
                column: "EmergencyResponseTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholders_AlertId",
                table: "Stakeholders",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Stakeholders_IncidentReportId",
                table: "Stakeholders",
                column: "IncidentReportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "IncidentMetrics");

            migrationBuilder.DropTable(
                name: "Stakeholders");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "EmergencyResponseTeams");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TryLog.Infraestructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "environment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(500)", nullable: false),
                    date_register = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_environment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "layer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(500)", nullable: false),
                    date_register = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_layer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "severity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(500)", nullable: false),
                    data_register = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_severity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(500)", nullable: false),
                    date_register = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    created_at = table.Column<string>(type: "varchar(500)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(500)", nullable: false),
                    DateRegister = table.Column<DateTime>(nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    token = table.Column<string>(type: "varchar(500)", nullable: false),
                    IdEnvironment = table.Column<int>(nullable: false),
                    IdLayer = table.Column<int>(nullable: false),
                    IdSeverity = table.Column<int>(nullable: false),
                    IdStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_log_environment_IdEnvironment",
                        column: x => x.IdEnvironment,
                        principalTable: "environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_log_layer_IdLayer",
                        column: x => x.IdLayer,
                        principalTable: "layer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_log_severity_IdSeverity",
                        column: x => x.IdSeverity,
                        principalTable: "severity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_log_status_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_log_IdEnvironment",
                table: "log",
                column: "IdEnvironment");

            migrationBuilder.CreateIndex(
                name: "IX_log_IdLayer",
                table: "log",
                column: "IdLayer");

            migrationBuilder.CreateIndex(
                name: "IX_log_IdSeverity",
                table: "log",
                column: "IdSeverity");

            migrationBuilder.CreateIndex(
                name: "IX_log_IdStatus",
                table: "log",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "user",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "log");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "environment");

            migrationBuilder.DropTable(
                name: "layer");

            migrationBuilder.DropTable(
                name: "severity");

            migrationBuilder.DropTable(
                name: "status");
        }
    }
}

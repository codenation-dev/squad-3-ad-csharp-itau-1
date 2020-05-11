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
                name: "role",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
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
                name: "roleclaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roleclaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roleclaim_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "userclaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userclaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userclaim_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userlogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userlogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_userlogin_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userrole",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userrole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_userrole_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userrole_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usertoken",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usertoken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_usertoken_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "environment",
                columns: new[] { "Id", "date_register", "deleted", "description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 11, 11, 49, 26, 517, DateTimeKind.Local).AddTicks(3731), false, "Desenvolvimento" },
                    { 2, new DateTime(2020, 5, 11, 11, 49, 26, 519, DateTimeKind.Local).AddTicks(8649), false, "Homologação" },
                    { 3, new DateTime(2020, 5, 11, 11, 49, 26, 519, DateTimeKind.Local).AddTicks(8764), false, "Produção" }
                });

            migrationBuilder.InsertData(
                table: "layer",
                columns: new[] { "Id", "date_register", "deleted", "description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 11, 11, 49, 26, 525, DateTimeKind.Local).AddTicks(902), false, "FrontEnd" },
                    { 2, new DateTime(2020, 5, 11, 11, 49, 26, 525, DateTimeKind.Local).AddTicks(2456), false, "Back-End" },
                    { 3, new DateTime(2020, 5, 11, 11, 49, 26, 525, DateTimeKind.Local).AddTicks(2524), false, "Mobile" },
                    { 4, new DateTime(2020, 5, 11, 11, 49, 26, 525, DateTimeKind.Local).AddTicks(2551), false, "Desktop" }
                });

            migrationBuilder.InsertData(
                table: "severity",
                columns: new[] { "Id", "data_register", "deleted", "description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 11, 11, 49, 26, 545, DateTimeKind.Local).AddTicks(5056), false, "Baixo" },
                    { 2, new DateTime(2020, 5, 11, 11, 49, 26, 545, DateTimeKind.Local).AddTicks(6641), false, "Médio" },
                    { 3, new DateTime(2020, 5, 11, 11, 49, 26, 545, DateTimeKind.Local).AddTicks(6720), false, "Alto" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "Id", "date_register", "deleted", "description" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 11, 11, 49, 26, 549, DateTimeKind.Local).AddTicks(7021), false, "Arquivado" },
                    { 2, new DateTime(2020, 5, 11, 11, 49, 26, 549, DateTimeKind.Local).AddTicks(8526), false, "Pendente" },
                    { 3, new DateTime(2020, 5, 11, 11, 49, 26, 549, DateTimeKind.Local).AddTicks(8636), false, "Ignorado" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "created_at", "deleted", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "updated_at", "UserName" },
                values: new object[,]
                {
                    { "9bddd32f78", 0, "bd44f745-d36b-4cb6-a9aa-2b052524eaa9", "2020-05-11 14:49:26.5531193", false, "le_andro@emailprovider.com", true, "Leandro Costa", false, null, null, null, "St2r_as2312%$%", null, null, false, null, false, new DateTime(2020, 5, 11, 14, 49, 26, 553, DateTimeKind.Utc).AddTicks(1193), "le_andro@emailprovider.com" },
                    { "d0f753c3cf", 0, "e385bd13-b0a3-4ea6-9a7b-24fe775bccdc", "2020-05-11 14:49:26.5542517", false, "marcelasilv@provideremail.com.br", true, "Marcela Silva", false, null, null, null, "1@#A3Sas9d_3we5@#", null, null, false, null, false, new DateTime(2020, 5, 11, 14, 49, 26, 554, DateTimeKind.Utc).AddTicks(2517), "marcelasilv@provideremail.com.br" }
                });

            migrationBuilder.InsertData(
                table: "log",
                columns: new[] { "Id", "DateRegister", "deleted", "description", "IdEnvironment", "IdLayer", "IdSeverity", "IdStatus", "token" },
                values: new object[] { 1, new DateTime(2020, 5, 11, 14, 49, 26, 541, DateTimeKind.Utc).AddTicks(7358), false, "System.NotSupportedException: The SMTP server does not support authentication. at MailKit.Net.Smtp.SmtpClient.AuthenticateAsync(Encoding encoding, ICredentials credentials, Boolean doAsync, CancellationToken cancellationToken)", 1, 2, 1, 3, "aasfdjg2jhlb1j2n3k12h3kjçh12jkeasdasd" });

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
                name: "RoleNameIndex",
                table: "role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_roleclaim_RoleId",
                table: "roleclaim",
                column: "RoleId");

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

            migrationBuilder.CreateIndex(
                name: "IX_userclaim_UserId",
                table: "userclaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userlogin_UserId",
                table: "userlogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userrole_RoleId",
                table: "userrole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "log");

            migrationBuilder.DropTable(
                name: "roleclaim");

            migrationBuilder.DropTable(
                name: "userclaim");

            migrationBuilder.DropTable(
                name: "userlogin");

            migrationBuilder.DropTable(
                name: "userrole");

            migrationBuilder.DropTable(
                name: "usertoken");

            migrationBuilder.DropTable(
                name: "environment");

            migrationBuilder.DropTable(
                name: "layer");

            migrationBuilder.DropTable(
                name: "severity");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}

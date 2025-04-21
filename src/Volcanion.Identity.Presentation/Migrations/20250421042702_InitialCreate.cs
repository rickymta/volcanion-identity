using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Volcanion.Identity.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Fullname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActived = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActived = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActived = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PermissionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsActived = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GrantPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AccountId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RolePermissionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsActived = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrantPermissions_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrantPermissions_RolePermissions_RolePermissionId",
                        column: x => x.RolePermissionId,
                        principalTable: "RolePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActived", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("94a933de-37a9-4539-b00c-1ae7b253fcb3"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7647), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "Create", null, null },
                    { new Guid("99b51ee3-e78b-4c4d-9d24-685d193b18d9"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7672), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "Grant", null, null },
                    { new Guid("bb1be038-efdc-4089-b818-f270f749f73d"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7654), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "SoftDelete", null, null },
                    { new Guid("d34cf9c6-8a97-4cf5-aaf8-68c4e9949f6d"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7660), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "HardDelete", null, null },
                    { new Guid("e0c2db33-56cc-42d0-bb00-c42411492a4b"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7652), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "Update", null, null },
                    { new Guid("f5ce26f7-d1b4-4a5c-9f88-48c1cd025eeb"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7650), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "Read", null, null },
                    { new Guid("f68f9851-84c3-4191-8d81-01433f9c5277"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7566), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "All", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActived", "IsDeleted", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("5143ea64-edd7-42f0-bf70-7168f93e8c97"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7338), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "Admin", null, null },
                    { new Guid("582cdad6-0e24-4cb4-8298-357084ab4b22"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7393), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "RolePermission", null, null },
                    { new Guid("7747afba-eb22-4c2b-a465-937745b5953f"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7391), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "Permission", null, null },
                    { new Guid("b48a42ee-61ef-46fb-8e0e-9a1b5be5195f"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7376), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "Role", null, null },
                    { new Guid("ba9b27cf-3186-4495-9a65-c2711b545634"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7374), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "Account", null, null },
                    { new Guid("d667e0f0-5313-46c1-ada4-a1d1bcb79d36"), new DateTimeOffset(new DateTime(2025, 4, 21, 11, 26, 58, 687, DateTimeKind.Unspecified).AddTicks(7395), new TimeSpan(0, 7, 0, 0, 0)), null, null, null, true, false, "GrantPermission", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GrantPermissions_AccountId",
                table: "GrantPermissions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantPermissions_RolePermissionId",
                table: "GrantPermissions",
                column: "RolePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrantPermissions");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

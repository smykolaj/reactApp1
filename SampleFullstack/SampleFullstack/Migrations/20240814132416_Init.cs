using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SampleFullstack.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Login = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Salt = table.Column<string>(type: "longtext", nullable: false),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: false),
                    RefreshTokenExp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.IdUser);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    IdCompany = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Krs = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.IdCompany);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    IdDiscount = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Offer = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.IdDiscount);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    IdIndividual = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Pesel = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.IdIndividual);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Softwares",
                columns: table => new
                {
                    IdSoftware = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IdCategory = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.IdSoftware);
                    table.ForeignKey(
                        name: "FK_Softwares_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    IdVersion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VersionNumber = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comments = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IdSoftware = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.IdVersion);
                    table.ForeignKey(
                        name: "FK_Versions_Softwares_IdSoftware",
                        column: x => x.IdSoftware,
                        principalTable: "Softwares",
                        principalColumn: "IdSoftware",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    IdContract = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    FullPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IdIndividual = table.Column<long>(type: "bigint", nullable: true),
                    IdCompany = table.Column<long>(type: "bigint", nullable: true),
                    IdSoftware = table.Column<long>(type: "bigint", nullable: false),
                    IdVersion = table.Column<long>(type: "bigint", nullable: false),
                    ContinuedSupportYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.IdContract);
                    table.ForeignKey(
                        name: "FK_Contracts_Companies_IdCompany",
                        column: x => x.IdCompany,
                        principalTable: "Companies",
                        principalColumn: "IdCompany",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Individuals_IdIndividual",
                        column: x => x.IdIndividual,
                        principalTable: "Individuals",
                        principalColumn: "IdIndividual",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Softwares_IdSoftware",
                        column: x => x.IdSoftware,
                        principalTable: "Softwares",
                        principalColumn: "IdSoftware",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Versions_IdVersion",
                        column: x => x.IdVersion,
                        principalTable: "Versions",
                        principalColumn: "IdVersion",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    IdPayment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdContract = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.IdPayment);
                    table.ForeignKey(
                        name: "FK_Payments_Contracts_IdContract",
                        column: x => x.IdContract,
                        principalTable: "Contracts",
                        principalColumn: "IdContract",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "IdUser", "Email", "IsAdmin", "Login", "Password", "RefreshToken", "RefreshTokenExp", "Salt" },
                values: new object[] { 1, "a@a.com", true, "admin", "admin", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "IdCategory", "CategoryName" },
                values: new object[,]
                {
                    { 1L, "Business" },
                    { 2L, "Education" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "IdDiscount", "Name", "Offer", "TimeEnd", "TimeStart", "Value" },
                values: new object[,]
                {
                    { 1L, "Summer Sale", "15% off", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0m },
                    { 2L, "Winter Sale", "25% off", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0m }
                });

            migrationBuilder.InsertData(
                table: "Softwares",
                columns: new[] { "IdSoftware", "Description", "IdCategory", "Name", "Price" },
                values: new object[,]
                {
                    { 1L, "A comprehensive business management software", 1L, "Business Suite", 5000.00m },
                    { 2L, "An interactive educational platform", 2L, "Education Hub", 3000.00m }
                });

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "IdVersion", "Comments", "Date", "IdSoftware", "VersionNumber" },
                values: new object[,]
                {
                    { 1L, "Initial release", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "1.0" },
                    { 2L, "Major update", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "2.0" },
                    { 3L, "Minor update", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "2.1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_IdCompany",
                table: "Contracts",
                column: "IdCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_IdIndividual",
                table: "Contracts",
                column: "IdIndividual");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_IdSoftware",
                table: "Contracts",
                column: "IdSoftware");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_IdVersion",
                table: "Contracts",
                column: "IdVersion");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdContract",
                table: "Payments",
                column: "IdContract");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_IdCategory",
                table: "Softwares",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Versions_IdSoftware",
                table: "Versions",
                column: "IdSoftware");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "Softwares");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customers.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "varchar(150)", nullable: true),
                    age = table.Column<short>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    street = table.Column<string>(type: "varchar(80)", nullable: true),
                    city = table.Column<string>(type: "varchar(150)", nullable: true),
                    state = table.Column<string>(type: "varchar(2)", nullable: true),
                    postal_code = table.Column<string>(type: "varchar(9)", nullable: true),
                    country = table.Column<string>(type: "varchar(50)", nullable: true),
                    customer_id = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_addresses_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_customer_id",
                table: "addresses",
                column: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BelleAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingMMedRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.AddColumn<string>(
                name: "MRID",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Customer_ID = table.Column<string>(type: "text", nullable: false),
                    Subjective = table.Column<string>(type: "text", nullable: false),
                    Objective = table.Column<string>(type: "text", nullable: false),
                    Assessmment = table.Column<string>(type: "text", nullable: false),
                    Plan = table.Column<string>(type: "text", nullable: false),
                    VisitDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    kode_item = table.Column<string>(type: "text", nullable: false),
                    nama_item = table.Column<string>(type: "text", nullable: false),
                    jenis = table.Column<string>(type: "text", nullable: false),
                    satuan = table.Column<string>(type: "text", nullable: false),
                    harga = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.kode_item);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropColumn(
                name: "MRID",
                table: "Transactions");

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    kode_item = table.Column<string>(type: "text", nullable: false),
                    harga = table.Column<decimal>(type: "numeric", nullable: false),
                    jenis = table.Column<string>(type: "text", nullable: false),
                    nama_item = table.Column<string>(type: "text", nullable: false),
                    satuan = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.kode_item);
                });
        }
    }
}

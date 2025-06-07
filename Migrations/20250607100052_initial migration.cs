using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelleAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    kode_item = table.Column<string>(type: "text", nullable: false),
                    keterangan = table.Column<string>(type: "text", nullable: false),
                    satuan = table.Column<string>(type: "text", nullable: false),
                    harga = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.kode_item);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");
        }
    }
}

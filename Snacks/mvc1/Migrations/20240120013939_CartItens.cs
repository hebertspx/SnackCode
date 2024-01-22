using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc1.Migrations
{
    public partial class CartItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItens",
                columns: table => new
                {
                    CartItensId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    Qtd = table.Column<int>(type: "int", nullable: false),
                    BuyerCart = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItens", x => x.CartItensId);
                    table.ForeignKey(
                        name: "FK_CartItens_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "SnackId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItens_SnackId",
                table: "CartItens",
                column: "SnackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItens");
        }
    }
}

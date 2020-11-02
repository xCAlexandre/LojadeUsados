using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTS.Server.Migrations
{
    public partial class ummuitos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdVendedor",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendedorIdVendedor",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    IdVendedor = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.IdVendedor);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_VendedorIdVendedor",
                table: "Produtos",
                column: "VendedorIdVendedor");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Vendedores_VendedorIdVendedor",
                table: "Produtos",
                column: "VendedorIdVendedor",
                principalTable: "Vendedores",
                principalColumn: "IdVendedor",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Vendedores_VendedorIdVendedor",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_VendedorIdVendedor",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdVendedor",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "VendedorIdVendedor",
                table: "Produtos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTS.Server.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    DatadeNasc = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Automovels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    UsuarioIdUsuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automovels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automovels_Usuarios_UsuarioIdUsuario",
                        column: x => x.UsuarioIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalheAutomovels",
                columns: table => new
                {
                    IdAutomovel = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    TempoDeUso = table.Column<string>(nullable: true),
                    EstadodeConservacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheAutomovels", x => x.IdAutomovel);
                    table.ForeignKey(
                        name: "FK_DetalheAutomovels_Automovels_IdAutomovel",
                        column: x => x.IdAutomovel,
                        principalTable: "Automovels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagAutomovels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagAutomovels", x => new { x.TagId, x.Id });
                    table.ForeignKey(
                        name: "FK_TagAutomovels_Automovels_Id",
                        column: x => x.Id,
                        principalTable: "Automovels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagAutomovels_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automovels_UsuarioIdUsuario",
                table: "Automovels",
                column: "UsuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TagAutomovels_Id",
                table: "TagAutomovels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalheAutomovels");

            migrationBuilder.DropTable(
                name: "TagAutomovels");

            migrationBuilder.DropTable(
                name: "Automovels");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

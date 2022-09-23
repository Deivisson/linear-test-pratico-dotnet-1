using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LinearSistemas.CanaisVendas.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanaisVendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanaisVendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoCanaisVendas",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    CanalVendaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoCanaisVendas", x => new { x.ProdutoId, x.CanalVendaId });
                    table.ForeignKey(
                        name: "FK_ProdutoCanaisVendas_CanaisVendas_CanalVendaId",
                        column: x => x.CanalVendaId,
                        principalTable: "CanaisVendas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdutoCanaisVendas_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoCanaisVendas_CanalVendaId",
                table: "ProdutoCanaisVendas",
                column: "CanalVendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoCanaisVendas");

            migrationBuilder.DropTable(
                name: "CanaisVendas");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}

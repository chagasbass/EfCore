using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCORE.Exemplos.Migrations
{
    public partial class criacaodobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(type: "CHAR(11)", nullable: true),
                    CEP = table.Column<string>(type: "CHAR(8)", nullable: false),
                    Estado = table.Column<string>(type: "CHAR(2)", nullable: false),
                    Cidade = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoDeBarras = table.Column<string>(type: "VARCHAR(14)", maxLength: 8, nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(60)", nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    TipoProduto = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    IniciadoEm = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    FinalizadoEm = table.Column<DateTime>(nullable: false),
                    TipoFrete = table.Column<int>(nullable: false),
                    StatusPedido = table.Column<string>(nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(512)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PEDIDOS_CLIENTES_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CLIENTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDO_ITEMS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false, defaultValue: 1),
                    Valor = table.Column<decimal>(nullable: false),
                    Desconto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO_ITEMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PEDIDO_ITEMS_PEDIDOS_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "PEDIDOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PEDIDO_ITEMS_PRODUTOS_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "PRODUTOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cliente_telefone",
                table: "CLIENTES",
                column: "Telefone");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_ITEMS_PedidoId",
                table: "PEDIDO_ITEMS",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDO_ITEMS_ProdutoId",
                table: "PEDIDO_ITEMS",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_ClienteId",
                table: "PEDIDOS",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PEDIDO_ITEMS");

            migrationBuilder.DropTable(
                name: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "CLIENTES");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiluTienda.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeLineaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasPedido_Pedidos_PedidoId",
                table: "LineasPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_LineasPedido_Pedidos_PedidoId",
                table: "LineasPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineasPedido_Pedidos_PedidoId",
                table: "LineasPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_LineasPedido_Pedidos_PedidoId",
                table: "LineasPedido",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }
    }
}

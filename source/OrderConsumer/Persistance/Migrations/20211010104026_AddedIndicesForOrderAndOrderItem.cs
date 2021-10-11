using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddedIndicesForOrderAndOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemCode",
                table: "OrderItem",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderItem_ItemCode",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");
        }
    }
}

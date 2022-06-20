using Microsoft.EntityFrameworkCore.Migrations;

namespace SpendControl.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransportWarehouseId",
                table: "Transportations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_TransportWarehouseId",
                table: "Transportations",
                column: "TransportWarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transportations_Warehouses_TransportWarehouseId",
                table: "Transportations",
                column: "TransportWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transportations_Warehouses_TransportWarehouseId",
                table: "Transportations");

            migrationBuilder.DropIndex(
                name: "IX_Transportations_TransportWarehouseId",
                table: "Transportations");

            migrationBuilder.DropColumn(
                name: "TransportWarehouseId",
                table: "Transportations");
        }
    }
}

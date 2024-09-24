using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasteMuseum.DataAccess.Migrations
{
    public partial class added_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantFood_Foods_FoodId",
                table: "RestaurantFood");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantFood_Restaurants_RestaurantId",
                table: "RestaurantFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantFood",
                table: "RestaurantFood");

            migrationBuilder.RenameTable(
                name: "RestaurantFood",
                newName: "RestaurantFoods");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantFood_FoodId",
                table: "RestaurantFoods",
                newName: "IX_RestaurantFoods_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantFoods",
                table: "RestaurantFoods",
                columns: new[] { "RestaurantId", "FoodId" });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    PersonCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId",
                table: "Reservations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantFoods_Foods_FoodId",
                table: "RestaurantFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantFoods_Restaurants_RestaurantId",
                table: "RestaurantFoods",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantFoods_Foods_FoodId",
                table: "RestaurantFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantFoods_Restaurants_RestaurantId",
                table: "RestaurantFoods");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RestaurantFoods",
                table: "RestaurantFoods");

            migrationBuilder.RenameTable(
                name: "RestaurantFoods",
                newName: "RestaurantFood");

            migrationBuilder.RenameIndex(
                name: "IX_RestaurantFoods_FoodId",
                table: "RestaurantFood",
                newName: "IX_RestaurantFood_FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RestaurantFood",
                table: "RestaurantFood",
                columns: new[] { "RestaurantId", "FoodId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantFood_Foods_FoodId",
                table: "RestaurantFood",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantFood_Restaurants_RestaurantId",
                table: "RestaurantFood",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

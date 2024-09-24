using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasteMuseum.DataAccess.Migrations
{
    public partial class added_AverageRating_and_RatingCount_columns_to_Food_and_Restaurant_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Restaurants",
                newName: "RatingCount");

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Restaurants",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "RestaurantComments",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RatingCount",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "FoodComments",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "RatingCount",
                table: "Restaurants",
                newName: "Rating");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "RestaurantComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "FoodComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}

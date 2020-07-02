using Microsoft.EntityFrameworkCore.Migrations;

namespace Visio_Beta_1.Data.Migrations
{
    public partial class changeCatCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_BookCategoryId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookCategoryId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_BookCategoryId",
                table: "Books",
                column: "BookCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_BookCategoryId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookCategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_BookCategoryId",
                table: "Books",
                column: "BookCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

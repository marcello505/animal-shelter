using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Added_AdoptionRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "CastratedOrSterilized",
                table: "AnimalSubmissions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AnimalSubmissions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "AnimalSubmissions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdoptionRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    AnimalId1 = table.Column<int>(nullable: false),
                    AnimalId2 = table.Column<int>(nullable: true),
                    AnimalId3 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AnimalSubmissions");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "AnimalSubmissions");

            migrationBuilder.AlterColumn<string>(
                name: "CastratedOrSterilized",
                table: "AnimalSubmissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}

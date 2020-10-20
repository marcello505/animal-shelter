using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RedoneAdoptionRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalId1",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "AnimalId2",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "AnimalId3",
                table: "AdoptionRequests");

            migrationBuilder.AddColumn<int>(
                name: "Animal1",
                table: "AdoptionRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Animal2",
                table: "AdoptionRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Animal3",
                table: "AdoptionRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Animal1",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "Animal2",
                table: "AdoptionRequests");

            migrationBuilder.DropColumn(
                name: "Animal3",
                table: "AdoptionRequests");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId1",
                table: "AdoptionRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnimalId2",
                table: "AdoptionRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimalId3",
                table: "AdoptionRequests",
                type: "int",
                nullable: true);
        }
    }
}

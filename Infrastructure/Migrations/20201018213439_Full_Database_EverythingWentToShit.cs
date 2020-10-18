using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Full_Database_EverythingWentToShit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaximumAnimals = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    EstimatedAge = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    DogOrCat = table.Column<string>(nullable: false),
                    Breed = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    DateOfArrival = table.Column<DateTime>(nullable: false),
                    DateOfAdoption = table.Column<DateTime>(nullable: true),
                    DateOfDeath = table.Column<DateTime>(nullable: true),
                    CastratedOrSterilized = table.Column<bool>(nullable: false),
                    SafeForKids = table.Column<bool>(nullable: false),
                    ReasonForLeavingOwner = table.Column<string>(nullable: false),
                    Adoptable = table.Column<bool>(nullable: false),
                    AdoptedBy = table.Column<string>(nullable: true),
                    CageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(nullable: false),
                    DateOfComment = table.Column<DateTime>(nullable: false),
                    CommentMadeBy = table.Column<string>(nullable: false),
                    AnimalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    MinimumAgeInMonths = table.Column<int>(nullable: true),
                    TreatmentDoneBy = table.Column<string>(nullable: false),
                    DateOfTreatment = table.Column<DateTime>(nullable: false),
                    AnimalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Adoptable", "AdoptedBy", "Breed", "CageId", "CastratedOrSterilized", "DateOfAdoption", "DateOfArrival", "DateOfBirth", "DateOfDeath", "Description", "DogOrCat", "EstimatedAge", "Gender", "ImageURL", "Name", "ReasonForLeavingOwner", "SafeForKids" },
                values: new object[] { 1, true, null, "LapjesKat", null, true, null, new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Een mooie lapjeskat", "cat", 18, "f", null, "Carolientje", "Eigenaar had het te druk met werk.", true });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Adoptable", "AdoptedBy", "Breed", "CageId", "CastratedOrSterilized", "DateOfAdoption", "DateOfArrival", "DateOfBirth", "DateOfDeath", "Description", "DogOrCat", "EstimatedAge", "Gender", "ImageURL", "Name", "ReasonForLeavingOwner", "SafeForKids" },
                values: new object[] { 2, true, null, "Amerikaanse Korthaar", null, true, null, new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Een brutale kater", "cat", 15, "m", null, "Tom", "Veel te eigenwijs en iritant.", false });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "AnimalId", "Cost", "DateOfTreatment", "Description", "MinimumAgeInMonths", "TreatmentDoneBy", "Type" },
                values: new object[] { 1, 1, null, new DateTime(2005, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Marcello", 0 });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "Id", "AnimalId", "Cost", "DateOfTreatment", "Description", "MinimumAgeInMonths", "TreatmentDoneBy", "Type" },
                values: new object[] { 2, 2, null, new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Dirk", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CageId",
                table: "Animals",
                column: "CageId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalId",
                table: "Comments",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_AnimalId",
                table: "Treatments",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Cages");
        }
    }
}

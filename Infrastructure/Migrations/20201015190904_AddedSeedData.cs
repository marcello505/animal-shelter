using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

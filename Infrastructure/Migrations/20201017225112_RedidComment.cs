using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RedidComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Treatments_TreatmentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "TreatmentId",
                table: "Comments",
                newName: "AnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TreatmentId",
                table: "Comments",
                newName: "IX_Comments_AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Animals_AnimalId",
                table: "Comments",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Animals_AnimalId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "AnimalId",
                table: "Comments",
                newName: "TreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AnimalId",
                table: "Comments",
                newName: "IX_Comments_TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Treatments_TreatmentId",
                table: "Comments",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

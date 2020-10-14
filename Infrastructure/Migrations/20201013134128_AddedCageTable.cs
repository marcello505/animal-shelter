using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddedCageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Treatments_TreatmentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Animals_AnimalId",
                table: "Treatments");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Treatments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CageId",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaximumAnimals = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CageId",
                table: "Animals",
                column: "CageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Cages_CageId",
                table: "Animals",
                column: "CageId",
                principalTable: "Cages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Treatments_TreatmentId",
                table: "Comments",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Animals_AnimalId",
                table: "Treatments",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Cages_CageId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Treatments_TreatmentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Animals_AnimalId",
                table: "Treatments");

            migrationBuilder.DropTable(
                name: "Cages");

            migrationBuilder.DropIndex(
                name: "IX_Animals_CageId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CageId",
                table: "Animals");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Treatments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TreatmentId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Treatments_TreatmentId",
                table: "Comments",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Animals_AnimalId",
                table: "Treatments",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

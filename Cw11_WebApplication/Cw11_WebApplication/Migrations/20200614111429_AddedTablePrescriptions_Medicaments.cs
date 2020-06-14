using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw11_WebApplication.Migrations
{
    public partial class AddedTablePrescriptions_Medicaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_Medicaments_IdMedicament",
                table: "Prescription_Medicament");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_IdPrescription",
                table: "Prescription_Medicament");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescription_Medicament",
                table: "Prescription_Medicament");

            migrationBuilder.RenameTable(
                name: "Prescription_Medicament",
                newName: "Prescriptions_Medicaments");

            migrationBuilder.RenameIndex(
                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescriptions_Medicaments",
                newName: "IX_Prescriptions_Medicaments_IdPrescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescriptions_Medicaments",
                table: "Prescriptions_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Medicaments_Medicaments_IdMedicament",
                table: "Prescriptions_Medicaments",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Medicaments_Prescriptions_IdPrescription",
                table: "Prescriptions_Medicaments",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Medicaments_Medicaments_IdMedicament",
                table: "Prescriptions_Medicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Medicaments_Prescriptions_IdPrescription",
                table: "Prescriptions_Medicaments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prescriptions_Medicaments",
                table: "Prescriptions_Medicaments");

            migrationBuilder.RenameTable(
                name: "Prescriptions_Medicaments",
                newName: "Prescription_Medicament");

            migrationBuilder.RenameIndex(
                name: "IX_Prescriptions_Medicaments_IdPrescription",
                table: "Prescription_Medicament",
                newName: "IX_Prescription_Medicament_IdPrescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prescription_Medicament",
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription" });

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_Medicaments_IdMedicament",
                table: "Prescription_Medicament",
                column: "IdMedicament",
                principalTable: "Medicaments",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_Prescriptions_IdPrescription",
                table: "Prescription_Medicament",
                column: "IdPrescription",
                principalTable: "Prescriptions",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

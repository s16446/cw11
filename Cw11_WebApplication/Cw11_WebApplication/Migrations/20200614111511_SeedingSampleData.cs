using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cw11_WebApplication.Migrations
{
    public partial class SeedingSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "jk@gmail.com", "Jan", "Kowalski" },
                    { 2, "an@gmail.com", "Anna", "Nowak" },
                    { 3, "bz@gmail.com", "Barbara", "Zawadzka" },
                    { 4, "dw@medicover.com", "Danuta", "Wasikowska" },
                    { 5, "tomasz@onet.pl", "Tomasz", "Lewandowski" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "aaaa", "APAP", "OTC" },
                    { 2, "bbbb", "Antybiotyk", "na receptę" },
                    { 3, "cccc", "Witamina C", "OTC" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "Nowak" },
                    { 2, new DateTime(1943, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonina", "Michalak" },
                    { 3, new DateTime(1965, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eugeniusz", "Kamiński" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 4, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 5, new DateTime(2020, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 1, "1 x dziennie na czczo", 1 },
                    { 2, 1, "dowolnie", 1 },
                    { 1, 2, "2 x dziennie (rano i wieczorem)", 2 },
                    { 2, 3, "razem z jedzeniem", 1 },
                    { 3, 4, "wieczorem ", 1 },
                    { 3, 5, "1 x dziennie przez 7 dni", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prescriptions_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Prescriptions_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Prescriptions_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Prescriptions_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Prescriptions_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Prescriptions_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);
        }
    }
}

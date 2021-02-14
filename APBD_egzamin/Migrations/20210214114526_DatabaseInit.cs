using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD_egzamin.Migrations
{
    public partial class DatabaseInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_pk", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Desciption = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Medicament_pk", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_pk", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    IdPatient = table.Column<int>(nullable: false),
                    IdDoctor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_pk", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "Doctor_Prescription",
                        column: x => x.IdDoctor,
                        principalTable: "Doctors",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Patient_Prescription",
                        column: x => x.IdPrescription,
                        principalTable: "Patients",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: true),
                    Details = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Multiple_pk", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "Medicament_PrescriptionMedicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicaments",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Medicament_Prescriptions_IdPrescription",
                        column: x => x.IdPrescription,
                        principalTable: "Prescriptions",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { -1, "j.n@doctor.com", "Jan", "Nowak" },
                    { -2, "j.n@doctor.com", "Kamil", "Janowski" },
                    { -3, "j.n@doctor.com", "Michał", "Wolski" },
                    { -4, "j.n@doctor.com", "Krzysztof", "Kowalski" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Desciption", "Name", "Type" },
                values: new object[,]
                {
                    { -1, "some description", "PainKiller 3000", "pill" },
                    { -2, "some description", "Cough Syrup", "syrup" },
                    { -3, "some description", "COVID-19 Vaccine", "injection" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { -1, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michał", "Michalczewski" },
                    { -2, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomasz", "Piaskowy" },
                    { -3, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "Szklany" },
                    { -4, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stanisław", "Stanowski" },
                    { -5, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Konrad", "Kwiatkowski" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { -1, new DateTime(2021, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, -1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { -2, new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), -2, -2 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { -3, new DateTime(2020, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), -3, -3 });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { -1, -1, "before meal", 50 },
                    { -2, -1, "after meal", 150 },
                    { -3, -1, "n/a", 250 },
                    { -1, -2, "before meal", 50 },
                    { -2, -2, "after meal", 150 },
                    { -3, -2, "n/a", 250 },
                    { -1, -3, "before meal", 50 },
                    { -2, -3, "after meal", 150 },
                    { -3, -3, "n/a", 250 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_IdPrescription",
                table: "Prescription_Medicament",
                column: "IdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_IdDoctor",
                table: "Prescriptions",
                column: "IdDoctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}

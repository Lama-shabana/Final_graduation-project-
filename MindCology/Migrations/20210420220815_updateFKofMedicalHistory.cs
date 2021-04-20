using Microsoft.EntityFrameworkCore.Migrations;

namespace MindCology.Migrations
{
    public partial class updateFKofMedicalHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistory_User_UserId",
                table: "MedicalHistory");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MedicalHistory",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistory_UserId",
                table: "MedicalHistory",
                newName: "IX_MedicalHistory_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistory_Patient_PatientId",
                table: "MedicalHistory",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistory_Patient_PatientId",
                table: "MedicalHistory");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "MedicalHistory",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistory_PatientId",
                table: "MedicalHistory",
                newName: "IX_MedicalHistory_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistory_User_UserId",
                table: "MedicalHistory",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MindCology.Migrations
{
    public partial class Initiate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    FilledMedicalForm = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvidedWithMentalHealthServices = table.Column<string>(nullable: true),
                    SessionsLanguage = table.Column<string>(nullable: true),
                    TherapistGender = table.Column<string>(nullable: true),
                    TraumaticExperience = table.Column<string>(nullable: true),
                    SeekingHelpFor = table.Column<string>(nullable: true),
                    MentalOrPhysicalDisorder = table.Column<bool>(nullable: false),
                    MentalOrPhysicalDisorderDetails = table.Column<string>(nullable: true),
                    ThinkAboutHarmingYourself = table.Column<bool>(nullable: false),
                    ThinkAboutHarmingYourselfDetails = table.Column<string>(nullable: true),
                    UnderMedications = table.Column<bool>(nullable: false),
                    UnderMedicationsDetails = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_UserId",
                table: "MedicalHistory",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

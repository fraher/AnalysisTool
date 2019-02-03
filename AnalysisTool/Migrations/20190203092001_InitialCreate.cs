using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalysisTool.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssessmentName = table.Column<string>(nullable: false),
                    AssessmentVersion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    BirthYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentSteps",
                columns: table => new
                {
                    AssessmentStepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssessmentId = table.Column<int>(nullable: false),
                    StepName = table.Column<string>(nullable: false),
                    Instructions = table.Column<string>(nullable: false),
                    MetaData = table.Column<string>(nullable: false),
                    PossiblePoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentSteps", x => x.AssessmentStepId);
                    table.ForeignKey(
                        name: "FK_AssessmentSteps_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentSessions",
                columns: table => new
                {
                    AssessmentSessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    MoodRating = table.Column<int>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentSessions", x => x.AssessmentSessionId);
                    table.ForeignKey(
                        name: "FK_AssessmentSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAssessments",
                columns: table => new
                {
                    UserAssessmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    AssessmentId = table.Column<int>(nullable: false),
                    Frequency = table.Column<string>(nullable: false),
                    PrescribingProvider = table.Column<string>(nullable: false),
                    WindowStartDateTime = table.Column<DateTime>(nullable: false),
                    WindowEndDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssessments", x => x.UserAssessmentId);
                    table.ForeignKey(
                        name: "FK_UserAssessments_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAssessments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentSessionStepResults",
                columns: table => new
                {
                    AssessmentSessionStepResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssessmentSessionId = table.Column<int>(nullable: false),
                    AssessmentStepId = table.Column<int>(nullable: false),
                    AssessmentOrder = table.Column<int>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentSessionStepResults", x => x.AssessmentSessionStepResultId);
                    table.ForeignKey(
                        name: "FK_AssessmentSessionStepResults_AssessmentSessions_AssessmentSessionId",
                        column: x => x.AssessmentSessionId,
                        principalTable: "AssessmentSessions",
                        principalColumn: "AssessmentSessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentSessionStepResults_AssessmentSteps_AssessmentStepId",
                        column: x => x.AssessmentStepId,
                        principalTable: "AssessmentSteps",
                        principalColumn: "AssessmentStepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentSessions_UserId",
                table: "AssessmentSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentSessionStepResults_AssessmentSessionId",
                table: "AssessmentSessionStepResults",
                column: "AssessmentSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentSessionStepResults_AssessmentStepId",
                table: "AssessmentSessionStepResults",
                column: "AssessmentStepId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentSteps_AssessmentId",
                table: "AssessmentSteps",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssessments_AssessmentId",
                table: "UserAssessments",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssessments_UserId",
                table: "UserAssessments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentSessionStepResults");

            migrationBuilder.DropTable(
                name: "UserAssessments");

            migrationBuilder.DropTable(
                name: "AssessmentSessions");

            migrationBuilder.DropTable(
                name: "AssessmentSteps");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Assessments");
        }
    }
}

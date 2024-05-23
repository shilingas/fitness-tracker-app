using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackingApp.Migrations
{
    public partial class fixedForeign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Users_WorkoutId",
                table: "UserExercises");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercises_UserId",
                table: "UserExercises",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Users_UserId",
                table: "UserExercises",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Users_UserId",
                table: "UserExercises");

            migrationBuilder.DropIndex(
                name: "IX_UserExercises_UserId",
                table: "UserExercises");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Users_WorkoutId",
                table: "UserExercises",
                column: "WorkoutId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

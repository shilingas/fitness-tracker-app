using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackingApp.Migrations
{
    public partial class UpdatedMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExercises_Workouts_WorkoutId",
                table: "UserExercises");

            migrationBuilder.DropIndex(
                name: "IX_UserExercises_WorkoutId",
                table: "UserExercises");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "UserExercises");

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Users",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Heigth",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GoalWeight",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "UserExerciseWorkout",
                columns: table => new
                {
                    UserExercisesId = table.Column<Guid>(type: "char(36)", nullable: false),
                    WorkoutsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExerciseWorkout", x => new { x.UserExercisesId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_UserExerciseWorkout_UserExercises_UserExercisesId",
                        column: x => x.UserExercisesId,
                        principalTable: "UserExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExerciseWorkout_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserExerciseWorkout_WorkoutsId",
                table: "UserExerciseWorkout",
                column: "WorkoutsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExerciseWorkout");

            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "Users",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Heigth",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GoalWeight",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkoutId",
                table: "UserExercises",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserExercises_WorkoutId",
                table: "UserExercises",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExercises_Workouts_WorkoutId",
                table: "UserExercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

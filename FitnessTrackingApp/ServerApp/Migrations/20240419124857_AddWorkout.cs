using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace FitnessTrackingApp.Migrations
{
    public partial class AddWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Exercises",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Exercises",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Exercises",
                type: "longblob",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Surname = table.Column<string>(type: "longtext", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    Weight = table.Column<float>(type: "float", nullable: false),
                    Heigth = table.Column<int>(type: "int", nullable: false),
                    GoalWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserExercises",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ExerciseId = table.Column<long>(type: "bigint", nullable: false),
                    WorkoutId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MaxWeight = table.Column<double>(type: "double", nullable: false),
                    MaxReps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercises_Users_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercises_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercises_ExerciseId",
                table: "UserExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercises_WorkoutId",
                table: "UserExercises",
                column: "WorkoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExercises");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Exercises");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Exercises",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }
    }
}

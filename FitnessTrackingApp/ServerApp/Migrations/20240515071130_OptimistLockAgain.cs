using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace FitnessTrackingApp.Migrations
{
    public partial class OptimistLockAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Version",
                table: "Workouts",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldRowVersion: true)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "Version",
                table: "Users",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldRowVersion: true)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "Version",
                table: "UserExercises",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldRowVersion: true)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "Version",
                table: "Exercises",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldRowVersion: true)
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                table: "Workouts",
                type: "longblob",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                table: "Users",
                type: "longblob",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                table: "UserExercises",
                type: "longblob",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                table: "Exercises",
                type: "longblob",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }
    }
}

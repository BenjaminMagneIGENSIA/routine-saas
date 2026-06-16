using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Routine_SaaS.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompleteMvpRoutine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MuscleTravaillé",
                table: "Exercices",
                newName: "MuscleTravaille");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciceName",
                table: "Exercices",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategorieName",
                table: "CategorieExercices",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PerformanceEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ExerciceId = table.Column<int>(type: "INTEGER", nullable: false),
                    DatePerformance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ChargeKg = table.Column<decimal>(type: "TEXT", nullable: false),
                    Repetitions = table.Column<int>(type: "INTEGER", nullable: false),
                    Commentaire = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceEntries_Exercices_ExerciceId",
                        column: x => x.ExerciceId,
                        principalTable: "Exercices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoutineEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    JourSemaine = table.Column<string>(type: "TEXT", nullable: false),
                    ExerciceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutineEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutineEntries_Exercices_ExerciceId",
                        column: x => x.ExerciceId,
                        principalTable: "Exercices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceEntries_ExerciceId",
                table: "PerformanceEntries",
                column: "ExerciceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutineEntries_ExerciceId",
                table: "RoutineEntries",
                column: "ExerciceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformanceEntries");

            migrationBuilder.DropTable(
                name: "RoutineEntries");

            migrationBuilder.RenameColumn(
                name: "MuscleTravaille",
                table: "Exercices",
                newName: "MuscleTravaillé");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciceName",
                table: "Exercices",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CategorieName",
                table: "CategorieExercices",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}

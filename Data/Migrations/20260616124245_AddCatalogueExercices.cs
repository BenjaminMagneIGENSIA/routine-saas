using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Routine_SaaS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCatalogueExercices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieExercices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategorieName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieExercices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExerciceName = table.Column<string>(type: "TEXT", nullable: true),
                    MuscleTravaillé = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    MaxPerf = table.Column<int>(type: "INTEGER", nullable: false),
                    CategorieExerciceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercices_CategorieExercices_CategorieExerciceId",
                        column: x => x.CategorieExerciceId,
                        principalTable: "CategorieExercices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercices_CategorieExerciceId",
                table: "Exercices",
                column: "CategorieExerciceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercices");

            migrationBuilder.DropTable(
                name: "CategorieExercices");
        }
    }
}

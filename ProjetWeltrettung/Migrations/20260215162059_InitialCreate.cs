using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetWeltrettung.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aggressoren",
                columns: table => new
                {
                    AggressorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Spezialgebiet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aggressoren", x => x.AggressorId);
                });

            migrationBuilder.CreateTable(
                name: "Helden",
                columns: table => new
                {
                    HeldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beruf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helden", x => x.HeldId);
                });

            migrationBuilder.CreateTable(
                name: "Weltretter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Faehigkeit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IstVolljaehrig = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weltretter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bedrohungen",
                columns: table => new
                {
                    BedrohungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bedrohungsname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Existiert = table.Column<bool>(type: "bit", nullable: false),
                    AggressorId = table.Column<int>(type: "int", nullable: false),
                    HeldId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bedrohungen", x => x.BedrohungId);
                    table.ForeignKey(
                        name: "FK_Bedrohungen_Aggressoren_AggressorId",
                        column: x => x.AggressorId,
                        principalTable: "Aggressoren",
                        principalColumn: "AggressorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bedrohungen_Helden_HeldId",
                        column: x => x.HeldId,
                        principalTable: "Helden",
                        principalColumn: "HeldId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bedrohungen_AggressorId",
                table: "Bedrohungen",
                column: "AggressorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bedrohungen_HeldId",
                table: "Bedrohungen",
                column: "HeldId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bedrohungen");

            migrationBuilder.DropTable(
                name: "Weltretter");

            migrationBuilder.DropTable(
                name: "Aggressoren");

            migrationBuilder.DropTable(
                name: "Helden");
        }
    }
}

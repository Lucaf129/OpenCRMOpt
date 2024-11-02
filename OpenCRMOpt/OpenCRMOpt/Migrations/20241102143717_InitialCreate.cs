using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenCRMOptModels.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Macchine",
                columns: table => new
                {
                    MacchineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macchine", x => x.MacchineID);
                });

            migrationBuilder.CreateTable(
                name: "ModelliLotti",
                columns: table => new
                {
                    ModelloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MacchineCompatibili = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelliLotti", x => x.ModelloID);
                });

            migrationBuilder.CreateTable(
                name: "Lotti",
                columns: table => new
                {
                    LottoID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modello = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantita = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lotti", x => x.LottoID);
                    table.ForeignKey(
                        name: "FK_Lotti_Modelli",
                        column: x => x.Modello,
                        principalTable: "ModelliLotti",
                        principalColumn: "ModelloID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lotti_Modello",
                table: "Lotti",
                column: "Modello");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lotti");

            migrationBuilder.DropTable(
                name: "Macchine");

            migrationBuilder.DropTable(
                name: "ModelliLotti");
        }
    }
}

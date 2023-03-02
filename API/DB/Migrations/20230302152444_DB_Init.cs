using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class DB_Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surfaces",
                columns: table => new
                {
                    surfaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    xSize = table.Column<int>(type: "int", nullable: false),
                    ySize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surfaces", x => x.surfaceId);
                });

            migrationBuilder.CreateTable(
                name: "LostRobots",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    xCoordinate = table.Column<int>(type: "int", nullable: false),
                    yCoordinate = table.Column<int>(type: "int", nullable: false),
                    orientation = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    surfaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LostRobots", x => x.id);
                    table.ForeignKey(
                        name: "FK_LostRobots_Surfaces_surfaceId",
                        column: x => x.surfaceId,
                        principalTable: "Surfaces",
                        principalColumn: "surfaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LostRobots_surfaceId",
                table: "LostRobots",
                column: "surfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Surfaces_xSize_ySize",
                table: "Surfaces",
                columns: new[] { "xSize", "ySize" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LostRobots");

            migrationBuilder.DropTable(
                name: "Surfaces");
        }
    }
}

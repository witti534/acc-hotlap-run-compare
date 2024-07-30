using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acc_hotlab_private_run_compare.Migrations
{
    /// <inheritdoc />
    public partial class db_v0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunInformationSet",
                columns: table => new
                {
                    RunID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrackName = table.Column<string>(type: "TEXT", nullable: false),
                    CarName = table.Column<string>(type: "TEXT", nullable: false),
                    DrivenTime = table.Column<int>(type: "INTEGER", nullable: false),
                    FastestLap = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionTime = table.Column<int>(type: "INTEGER", nullable: false),
                    PenaltyOccured = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunInformationSet", x => x.RunID);
                });

            migrationBuilder.CreateTable(
                name: "SectorInformationSet",
                columns: table => new
                {
                    LapNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    SectorIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    RunID = table.Column<long>(type: "INTEGER", nullable: false),
                    DrivenSectorTime = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorInformationSet", x => new { x.RunID, x.LapNumber, x.SectorIndex });
                    table.ForeignKey(
                        name: "FK_SectorInformationSet_RunInformationSet_RunID",
                        column: x => x.RunID,
                        principalTable: "RunInformationSet",
                        principalColumn: "RunID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectorInformationSet");

            migrationBuilder.DropTable(
                name: "RunInformationSet");
        }
    }
}

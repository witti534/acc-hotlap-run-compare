using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acc_hotrun_run_compare.acchotrunruncompare.Migrations
{
    /// <inheritdoc />
    public partial class Test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "RunInformationSet",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RunDescription",
                table: "RunInformationSet",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "RunInformationSet");

            migrationBuilder.DropColumn(
                name: "RunDescription",
                table: "RunInformationSet");
        }
    }
}

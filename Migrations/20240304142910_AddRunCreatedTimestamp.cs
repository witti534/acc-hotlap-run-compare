using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acc_hotlab_private_run_compare.Migrations
{
    /// <inheritdoc />
    public partial class AddRunCreatedTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RunCreatedDateTime",
                table: "RunInformationSet",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RunCreatedDateTime",
                table: "RunInformationSet");
        }
    }
}

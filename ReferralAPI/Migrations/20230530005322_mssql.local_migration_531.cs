using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReferralAPI.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_531 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferralName",
                table: "DynamicReferral",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferralName",
                table: "DynamicReferral");
        }
    }
}

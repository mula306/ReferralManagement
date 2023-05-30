using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReferralAPI.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_263 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicReferral",
                columns: table => new
                {
                    DynamicReferralId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReferralJson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicReferral", x => x.DynamicReferralId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicReferral");
        }
    }
}

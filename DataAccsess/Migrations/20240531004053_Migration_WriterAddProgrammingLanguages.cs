using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsess.Migrations
{
    /// <inheritdoc />
    public partial class Migration_WriterAddProgrammingLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KnowTeknologies",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgrammingLanguages",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KnowTeknologies",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "ProgrammingLanguages",
                table: "Writers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsess.Migrations
{
    /// <inheritdoc />
    public partial class Migration_WriterAddSocialMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldOfInterest",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "Writers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tweeter",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Youtube",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "FieldOfInterest",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "Tweeter",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "Youtube",
                table: "Writers");
        }
    }
}

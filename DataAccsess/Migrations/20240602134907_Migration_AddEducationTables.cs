using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsess.Migrations
{
    /// <inheritdoc />
    public partial class Migration_AddEducationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    WriterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Educations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "WriterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EducationId",
                table: "Comments",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CategoryId",
                table: "Educations",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_WriterId",
                table: "Educations",
                column: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Educations_EducationId",
                table: "Comments",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "EducationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Educations_EducationId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EducationId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Comments");
        }
    }
}

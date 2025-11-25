using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaqAssistant.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Categories", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Tags", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),
                    DisplayName = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1,1"),
                    Question = table.Column<string>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                    table.ForeignKey("FK_Faqs_Categories", x => x.CategoryId, "Categories", "Id", onDelete: ReferentialAction.Cascade);
                    table.ForeignKey("FK_Faqs_Users_Created", x => x.CreatedByUserId, "Users", "Id", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey("FK_Faqs_Users_Updated", x => x.UpdatedByUserId, "Users", "Id", onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaqTags",
                columns: table => new
                {
                    FaqId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqTags", x => new { x.FaqId, x.TagId });
                    table.ForeignKey("FK_FaqTags_Faqs", x => x.FaqId, "Faqs", "Id", onDelete: ReferentialAction.Cascade);
                    table.ForeignKey("FK_FaqTags_Tags", x => x.TagId, "Tags", "Id", onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("FaqTags");
            migrationBuilder.DropTable("Faqs");
            migrationBuilder.DropTable("Tags");
            migrationBuilder.DropTable("Categories");
            migrationBuilder.DropTable("Users");
        }
    }
}

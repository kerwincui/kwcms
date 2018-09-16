using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kewcms.Migrations
{
    public partial class AddVisitorInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitorInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VisitorIp = table.Column<string>(nullable: true),
                    CityId = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    VisitUrl = table.Column<string>(nullable: true),
                    AppVersion = table.Column<string>(nullable: true),
                    AddTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitorInfo");
        }
    }
}

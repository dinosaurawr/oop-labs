using Microsoft.EntityFrameworkCore.Migrations;

namespace MoscowWiFi.WebService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessPoints",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    AdmArea = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    NumberOfAccessPoints = table.Column<int>(nullable: false),
                    WiFiName = table.Column<string>(nullable: true),
                    CoverageArea = table.Column<int>(nullable: false),
                    FunctionFlag = table.Column<string>(nullable: true),
                    AccessFlag = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPoints", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AccessPoints",
                columns: new[] { "Id", "AccessFlag", "AdmArea", "CoverageArea", "District", "FunctionFlag", "Location", "Name", "NumberOfAccessPoints", "Password", "WiFiName" },
                values: new object[] { 1L, "asda", "asdasd", 400, "123", "asdasd", "123", "123", 2, "123", "asda" });

            migrationBuilder.InsertData(
                table: "AccessPoints",
                columns: new[] { "Id", "AccessFlag", "AdmArea", "CoverageArea", "District", "FunctionFlag", "Location", "Name", "NumberOfAccessPoints", "Password", "WiFiName" },
                values: new object[] { 2L, "asda", "asdasd", 400, "123", "asdasd", "123", "123", 3, "123", "asda" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessPoints");
        }
    }
}

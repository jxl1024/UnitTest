using Microsoft.EntityFrameworkCore.Migrations;

namespace UnitTest.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Student",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 32, nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Student", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "T_Student",
                columns: new[] { "ID", "Age", "Gender", "Name" },
                values: new object[] { 1, 20, "男", "测试1" });

            migrationBuilder.InsertData(
                table: "T_Student",
                columns: new[] { "ID", "Age", "Gender", "Name" },
                values: new object[] { 2, 22, "女", "测试2" });

            migrationBuilder.InsertData(
                table: "T_Student",
                columns: new[] { "ID", "Age", "Gender", "Name" },
                values: new object[] { 3, 23, "男", "测试3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Student");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfDbApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountDtos",
                columns: table => new
                {
                    Uuid = table.Column<string>(type: "TEXT", nullable: false),
                    Nationality = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Money = table.Column<decimal>(type: "TEXT", nullable: true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDtos", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "CardDtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cardNum = table.Column<string>(type: "TEXT", nullable: true),
                    cvv = table.Column<int>(type: "INTEGER", nullable: false),
                    expDate = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDtos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountDtos");

            migrationBuilder.DropTable(
                name: "CardDtos");
        }
    }
}

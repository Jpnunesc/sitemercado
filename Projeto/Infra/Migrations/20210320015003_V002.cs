using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class V002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Produto",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Imagem",
                table: "Produto",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");
        }
    }
}

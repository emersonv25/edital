using Microsoft.EntityFrameworkCore.Migrations;

namespace edital.Migrations
{
    public partial class upInscricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "objetivos",
                table: "inscricao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "publicoalvo",
                table: "inscricao",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "objetivos",
                table: "inscricao");

            migrationBuilder.DropColumn(
                name: "publicoalvo",
                table: "inscricao");
        }
    }
}

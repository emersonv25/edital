using Microsoft.EntityFrameworkCore.Migrations;

namespace edital.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inscricao_pessoajuridica_pessoajuridicacnpj",
                table: "inscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_inscricao_segmento_segmentoid",
                table: "inscricao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inscricao",
                table: "inscricao");

            migrationBuilder.DropIndex(
                name: "IX_inscricao_pessoajuridicacnpj",
                table: "inscricao");

            migrationBuilder.DropColumn(
                name: "pessoajuridica_id",
                table: "inscricao");

            migrationBuilder.DropColumn(
                name: "segmento_id",
                table: "inscricao");

            migrationBuilder.AlterColumn<int>(
                name: "segmentoid",
                table: "inscricao",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pessoajuridicacnpj",
                table: "inscricao",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inscricao",
                table: "inscricao",
                columns: new[] { "pessoajuridicacnpj", "segmentoid" });

            migrationBuilder.AddForeignKey(
                name: "FK_inscricao_pessoajuridica_pessoajuridicacnpj",
                table: "inscricao",
                column: "pessoajuridicacnpj",
                principalTable: "pessoajuridica",
                principalColumn: "cnpj",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inscricao_segmento_segmentoid",
                table: "inscricao",
                column: "segmentoid",
                principalTable: "segmento",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_inscricao_pessoajuridica_pessoajuridicacnpj",
                table: "inscricao");

            migrationBuilder.DropForeignKey(
                name: "FK_inscricao_segmento_segmentoid",
                table: "inscricao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inscricao",
                table: "inscricao");

            migrationBuilder.AlterColumn<int>(
                name: "segmentoid",
                table: "inscricao",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "pessoajuridicacnpj",
                table: "inscricao",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "pessoajuridica_id",
                table: "inscricao",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "segmento_id",
                table: "inscricao",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_inscricao",
                table: "inscricao",
                columns: new[] { "pessoajuridica_id", "segmento_id" });

            migrationBuilder.CreateIndex(
                name: "IX_inscricao_pessoajuridicacnpj",
                table: "inscricao",
                column: "pessoajuridicacnpj");

            migrationBuilder.AddForeignKey(
                name: "FK_inscricao_pessoajuridica_pessoajuridicacnpj",
                table: "inscricao",
                column: "pessoajuridicacnpj",
                principalTable: "pessoajuridica",
                principalColumn: "cnpj",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_inscricao_segmento_segmentoid",
                table: "inscricao",
                column: "segmentoid",
                principalTable: "segmento",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

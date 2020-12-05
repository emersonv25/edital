using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace edital.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contato",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    telefone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    celular = table.Column<string>(type: "text", nullable: false),
                    site = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contato", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "edital",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    datainicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    datafim = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    vigencia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_edital", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    uf = table.Column<string>(type: "text", nullable: false),
                    flgativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "segmento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    segmento = table.Column<string>(type: "text", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    editalid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_segmento", x => x.id);
                    table.ForeignKey(
                        name: "FK_segmento_edital_editalid",
                        column: x => x.editalid,
                        principalTable: "edital",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    estadoid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_cidade_estado_estadoid",
                        column: x => x.estadoid,
                        principalTable: "estado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    logradouro = table.Column<string>(type: "text", nullable: false),
                    bairro = table.Column<string>(type: "text", nullable: false),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    numero = table.Column<string>(type: "text", nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    cidadeid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.id);
                    table.ForeignKey(
                        name: "FK_endereco_cidade_cidadeid",
                        column: x => x.cidadeid,
                        principalTable: "cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "representante",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: false),
                    contatoid = table.Column<int>(type: "integer", nullable: true),
                    enderecoid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_representante", x => x.id);
                    table.ForeignKey(
                        name: "FK_representante_contato_contatoid",
                        column: x => x.contatoid,
                        principalTable: "contato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_representante_endereco_enderecoid",
                        column: x => x.enderecoid,
                        principalTable: "endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pessoajuridica",
                columns: table => new
                {
                    cnpj = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    razaosocial = table.Column<string>(type: "text", nullable: false),
                    enderecoid = table.Column<int>(type: "integer", nullable: true),
                    representanteid = table.Column<int>(type: "integer", nullable: true),
                    contatoid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoajuridica", x => x.cnpj);
                    table.ForeignKey(
                        name: "FK_pessoajuridica_contato_contatoid",
                        column: x => x.contatoid,
                        principalTable: "contato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pessoajuridica_endereco_enderecoid",
                        column: x => x.enderecoid,
                        principalTable: "endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pessoajuridica_representante_representanteid",
                        column: x => x.representanteid,
                        principalTable: "representante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "inscricao",
                columns: table => new
                {
                    pessoajuridica_id = table.Column<int>(type: "integer", nullable: false),
                    segmento_id = table.Column<int>(type: "integer", nullable: false),
                    pessoajuridicacnpj = table.Column<int>(type: "integer", nullable: true),
                    segmentoid = table.Column<int>(type: "integer", nullable: false),
                    flgativo = table.Column<bool>(type: "boolean", nullable: false),
                    nomeiniciativa = table.Column<string>(type: "text", nullable: true),
                    objetivos = table.Column<string>(type: "text", nullable: true),
                    publicoalvo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscricao", x => new { x.pessoajuridica_id, x.segmento_id });
                    table.ForeignKey(
                        name: "FK_inscricao_pessoajuridica_pessoajuridicacnpj",
                        column: x => x.pessoajuridicacnpj,
                        principalTable: "pessoajuridica",
                        principalColumn: "cnpj",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inscricao_segmento_segmentoid",
                        column: x => x.segmentoid,
                        principalTable: "segmento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cidade_estadoid",
                table: "cidade",
                column: "estadoid");

            migrationBuilder.CreateIndex(
                name: "IX_endereco_cidadeid",
                table: "endereco",
                column: "cidadeid");

            migrationBuilder.CreateIndex(
                name: "IX_inscricao_pessoajuridicacnpj",
                table: "inscricao",
                column: "pessoajuridicacnpj");

            migrationBuilder.CreateIndex(
                name: "IX_inscricao_segmentoid",
                table: "inscricao",
                column: "segmentoid");

            migrationBuilder.CreateIndex(
                name: "IX_pessoajuridica_contatoid",
                table: "pessoajuridica",
                column: "contatoid");

            migrationBuilder.CreateIndex(
                name: "IX_pessoajuridica_enderecoid",
                table: "pessoajuridica",
                column: "enderecoid");

            migrationBuilder.CreateIndex(
                name: "IX_pessoajuridica_representanteid",
                table: "pessoajuridica",
                column: "representanteid");

            migrationBuilder.CreateIndex(
                name: "IX_representante_contatoid",
                table: "representante",
                column: "contatoid");

            migrationBuilder.CreateIndex(
                name: "IX_representante_enderecoid",
                table: "representante",
                column: "enderecoid");

            migrationBuilder.CreateIndex(
                name: "IX_segmento_editalid",
                table: "segmento",
                column: "editalid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inscricao");

            migrationBuilder.DropTable(
                name: "pessoajuridica");

            migrationBuilder.DropTable(
                name: "segmento");

            migrationBuilder.DropTable(
                name: "representante");

            migrationBuilder.DropTable(
                name: "edital");

            migrationBuilder.DropTable(
                name: "contato");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "cidade");

            migrationBuilder.DropTable(
                name: "estado");
        }
    }
}

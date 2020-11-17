using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace edital.Migrations
{
    public partial class criandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anexo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: true),
                    contentype = table.Column<string>(nullable: true),
                    arquivo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anexo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "contato",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    telefone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    celular = table.Column<string>(nullable: false),
                    site = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contato", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "edital",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: false),
                    datainicio = table.Column<DateTime>(nullable: false),
                    datafim = table.Column<DateTime>(nullable: true),
                    vigencia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_edital", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: false),
                    uf = table.Column<string>(nullable: false),
                    flgativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "segmento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    segmento = table.Column<string>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    editalid = table.Column<int>(nullable: false)
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
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: false),
                    estadoid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_cidade_estado_estadoid",
                        column: x => x.estadoid,
                        principalTable: "estado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    logradouro = table.Column<string>(nullable: false),
                    bairro = table.Column<string>(nullable: false),
                    complemento = table.Column<string>(nullable: true),
                    numero = table.Column<string>(nullable: false),
                    cep = table.Column<string>(nullable: false),
                    cidadeid = table.Column<int>(nullable: false)
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
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(nullable: false),
                    cpf = table.Column<string>(nullable: false),
                    contatoid = table.Column<int>(nullable: false),
                    enderecoid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_representante", x => x.id);
                    table.ForeignKey(
                        name: "FK_representante_contato_contatoid",
                        column: x => x.contatoid,
                        principalTable: "contato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_representante_endereco_enderecoid",
                        column: x => x.enderecoid,
                        principalTable: "endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pessoajuridica",
                columns: table => new
                {
                    cnpj = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    razaosocial = table.Column<string>(nullable: false),
                    enderecoid = table.Column<int>(nullable: false),
                    representanteid = table.Column<int>(nullable: false),
                    contatoid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoajuridica", x => x.cnpj);
                    table.ForeignKey(
                        name: "FK_pessoajuridica_contato_contatoid",
                        column: x => x.contatoid,
                        principalTable: "contato",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pessoajuridica_endereco_enderecoid",
                        column: x => x.enderecoid,
                        principalTable: "endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pessoajuridica_representante_representanteid",
                        column: x => x.representanteid,
                        principalTable: "representante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inscricao",
                columns: table => new
                {
                    pessoajuridica_id = table.Column<int>(nullable: false),
                    segmento_id = table.Column<int>(nullable: false),
                    pessoajuridicacnpj = table.Column<int>(nullable: false),
                    segmentoid = table.Column<int>(nullable: false),
                    flgativo = table.Column<bool>(nullable: false),
                    nomeiniciativa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inscricao", x => new { x.pessoajuridica_id, x.segmento_id });
                    table.ForeignKey(
                        name: "FK_inscricao_pessoajuridica_pessoajuridicacnpj",
                        column: x => x.pessoajuridicacnpj,
                        principalTable: "pessoajuridica",
                        principalColumn: "cnpj",
                        onDelete: ReferentialAction.Cascade);
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
                name: "anexo");

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

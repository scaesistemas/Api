using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class SplitPagamentoParcela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adiantamentocarteira",
                schema: "financeiro");

            migrationBuilder.DropTable(
                name: "situacaoadiantamentocarteira",
                schema: "financeiro");

            migrationBuilder.DropTable(
                name: "tipoadiantamentocarteira",
                schema: "financeiro");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    schema: "loteamento",
            //    table: "seguradora_contato");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    schema: "geral",
            //    table: "pessoaprefeituracontato");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    schema: "geral",
            //    table: "pessoacontato");

            migrationBuilder.AddColumn<int>(
                name: "SplitPagamento_GalaxyPayId",
                schema: "financeiro",
                table: "receitaparcela",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SplitPagamento_TipoSplit",
                schema: "financeiro",
                table: "receitaparcela",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SplitPagamento_Valor",
                schema: "financeiro",
                table: "receitaparcela",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone2",
                schema: "geral",
                table: "pessoa",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isGerado",
                schema: "financeiro",
                table: "parametrogatway",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "contacorrentesplit",
                schema: "financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParametroGatewayId = table.Column<int>(type: "integer", nullable: false),
                    ContaCorrenteId = table.Column<int>(type: "integer", nullable: false),
                    IsPercentual = table.Column<bool>(type: "boolean", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacorrentesplit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacorrentesplit_contacorrente_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalSchema: "financeiro",
                        principalTable: "contacorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contacorrentesplit_parametrogatway_ParametroGatewayId",
                        column: x => x.ParametroGatewayId,
                        principalSchema: "financeiro",
                        principalTable: "parametrogatway",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contacorrentesplit_ContaCorrenteId",
                schema: "financeiro",
                table: "contacorrentesplit",
                column: "ContaCorrenteId");

            migrationBuilder.CreateIndex(
                name: "IX_contacorrentesplit_ParametroGatewayId",
                schema: "financeiro",
                table: "contacorrentesplit",
                column: "ParametroGatewayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacorrentesplit",
                schema: "financeiro");

            migrationBuilder.DropColumn(
                name: "SplitPagamento_GalaxyPayId",
                schema: "financeiro",
                table: "receitaparcela");

            migrationBuilder.DropColumn(
                name: "SplitPagamento_TipoSplit",
                schema: "financeiro",
                table: "receitaparcela");

            migrationBuilder.DropColumn(
                name: "SplitPagamento_Valor",
                schema: "financeiro",
                table: "receitaparcela");

            migrationBuilder.DropColumn(
                name: "Telefone2",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "isGerado",
                schema: "financeiro",
                table: "parametrogatway");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "loteamento",
                table: "seguradora_contato",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "geral",
                table: "pessoaprefeituracontato",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "geral",
                table: "pessoacontato",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "situacaoadiantamentocarteira",
                schema: "financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_situacaoadiantamentocarteira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipoadiantamentocarteira",
                schema: "financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoadiantamentocarteira", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adiantamentocarteira",
                schema: "financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpresaSolicitanteId = table.Column<int>(type: "integer", nullable: false),
                    SituacaoAdiantamentoCarteiraId = table.Column<int>(type: "integer", nullable: false),
                    TipoAdiantamentoCarteiraId = table.Column<int>(type: "integer", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Objetivo = table.Column<string>(type: "text", nullable: true),
                    PrimeiroMesParcela = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    QuantidadeParcelas = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adiantamentocarteira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adiantamentocarteira_empresa_EmpresaSolicitanteId",
                        column: x => x.EmpresaSolicitanteId,
                        principalSchema: "geral",
                        principalTable: "empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adiantamentocarteira_situacaoadiantamentocarteira_SituacaoA~",
                        column: x => x.SituacaoAdiantamentoCarteiraId,
                        principalSchema: "financeiro",
                        principalTable: "situacaoadiantamentocarteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adiantamentocarteira_tipoadiantamentocarteira_TipoAdiantame~",
                        column: x => x.TipoAdiantamentoCarteiraId,
                        principalSchema: "financeiro",
                        principalTable: "tipoadiantamentocarteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "financeiro",
                table: "situacaoadiantamentocarteira",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Pendente de aprovação" },
                    { 2, "Aprovado" },
                    { 3, "Negado" },
                    { 4, "Cancelado" }
                });

            migrationBuilder.InsertData(
                schema: "financeiro",
                table: "tipoadiantamentocarteira",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Split de pagamento" });

            migrationBuilder.CreateIndex(
                name: "IX_adiantamentocarteira_EmpresaSolicitanteId",
                schema: "financeiro",
                table: "adiantamentocarteira",
                column: "EmpresaSolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_adiantamentocarteira_SituacaoAdiantamentoCarteiraId",
                schema: "financeiro",
                table: "adiantamentocarteira",
                column: "SituacaoAdiantamentoCarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_adiantamentocarteira_TipoAdiantamentoCarteiraId",
                schema: "financeiro",
                table: "adiantamentocarteira",
                column: "TipoAdiantamentoCarteiraId");
        }
    }
}

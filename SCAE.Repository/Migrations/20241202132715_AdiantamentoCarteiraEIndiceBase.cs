using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCAE.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdiantamentoCarteiraEIndiceBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "financeiro");

            migrationBuilder.CreateTable(
                name: "situacaoadiantamentocarteira",
                schema: "base",
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
                schema: "base",
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
                name: "tipoindice",
                schema: "financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoindice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoIndiceBase",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIndiceBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adiantamentocarteira",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssinanteId = table.Column<int>(type: "integer", nullable: false),
                    EmpresaSolicitante_EmpresaId = table.Column<int>(type: "integer", nullable: true),
                    EmpresaSolicitante_Nome = table.Column<string>(type: "text", nullable: true),
                    EmpresaSolicitante_CNPJ = table.Column<string>(type: "text", nullable: true),
                    Objetivo = table.Column<string>(type: "text", nullable: true),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    PrimeiroMesParcela = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    QuantidadeParcelas = table.Column<int>(type: "integer", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "numeric", nullable: false),
                    TipoAdiantamentoCarteiraId = table.Column<int>(type: "integer", nullable: false),
                    SituacaoAdiantamentoCarteiraId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adiantamentocarteira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adiantamentocarteira_situacaoadiantamentocarteira_SituacaoA~",
                        column: x => x.SituacaoAdiantamentoCarteiraId,
                        principalSchema: "base",
                        principalTable: "situacaoadiantamentocarteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adiantamentocarteira_tipoadiantamentocarteira_TipoAdiantame~",
                        column: x => x.TipoAdiantamentoCarteiraId,
                        principalSchema: "base",
                        principalTable: "tipoadiantamentocarteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "indice",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoIndiceId = table.Column<int>(type: "integer", nullable: false),
                    Dia = table.Column<byte>(type: "smallint", nullable: false),
                    Mes = table.Column<byte>(type: "smallint", nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: false),
                    Percentual = table.Column<decimal>(type: "numeric", nullable: false),
                    Mensal = table.Column<decimal>(type: "numeric", nullable: false),
                    AvulsoMensal = table.Column<decimal>(type: "numeric", nullable: false),
                    Acumulado = table.Column<decimal>(type: "numeric", nullable: false),
                    Executado = table.Column<bool>(type: "boolean", nullable: false),
                    AplicarIndiceNegativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_indice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_indice_tipoindice_TipoIndiceId",
                        column: x => x.TipoIndiceId,
                        principalSchema: "financeiro",
                        principalTable: "tipoindice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contratoadiantamento",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContratoId = table.Column<int>(type: "integer", nullable: false),
                    AdiantamentoCarteiraId = table.Column<int>(type: "integer", nullable: false),
                    NumContrato = table.Column<int>(type: "integer", nullable: false),
                    TotalParcelas = table.Column<int>(type: "integer", nullable: false),
                    ParcelasPagas = table.Column<int>(type: "integer", nullable: false),
                    ValorParcela = table.Column<decimal>(type: "numeric", nullable: false),
                    SaldoContrato = table.Column<decimal>(type: "numeric", nullable: false),
                    ParcelasVencer = table.Column<int>(type: "integer", nullable: false),
                    ValorTotalParcela = table.Column<decimal>(type: "numeric", nullable: false),
                    NumeroSequencia = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contratoadiantamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contratoadiantamento_adiantamentocarteira_AdiantamentoCarte~",
                        column: x => x.AdiantamentoCarteiraId,
                        principalSchema: "base",
                        principalTable: "adiantamentocarteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "base",
                table: "TipoIndiceBase",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "IGP-M (FGV)" },
                    { 2, "Selic" },
                    { 3, "INCC (FGV)" },
                    { 4, "INPC (IBGE)" },
                    { 5, "PARCELAS FIXAS" },
                    { 6, "SALÁRIO MÍNIMO" },
                    { 7, "UFIR" },
                    { 8, "IPCA" },
                    { 9, "Outro" }
                });

            migrationBuilder.InsertData(
                schema: "base",
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
                schema: "base",
                table: "tipoadiantamentocarteira",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Split de pagamento" });

            migrationBuilder.CreateIndex(
                name: "IX_adiantamentocarteira_SituacaoAdiantamentoCarteiraId",
                schema: "base",
                table: "adiantamentocarteira",
                column: "SituacaoAdiantamentoCarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_adiantamentocarteira_TipoAdiantamentoCarteiraId",
                schema: "base",
                table: "adiantamentocarteira",
                column: "TipoAdiantamentoCarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_contratoadiantamento_AdiantamentoCarteiraId",
                schema: "base",
                table: "contratoadiantamento",
                column: "AdiantamentoCarteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_indice_TipoIndiceId",
                schema: "base",
                table: "indice",
                column: "TipoIndiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contratoadiantamento",
                schema: "base");

            migrationBuilder.DropTable(
                name: "indice",
                schema: "base");

            migrationBuilder.DropTable(
                name: "TipoIndiceBase",
                schema: "base");

            migrationBuilder.DropTable(
                name: "adiantamentocarteira",
                schema: "base");

            migrationBuilder.DropTable(
                name: "tipoindice",
                schema: "financeiro");

            migrationBuilder.DropTable(
                name: "situacaoadiantamentocarteira",
                schema: "base");

            migrationBuilder.DropTable(
                name: "tipoadiantamentocarteira",
                schema: "base");
        }
    }
}

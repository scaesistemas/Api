using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations
{
    /// <inheritdoc />
    public partial class ParcelasContratoAdiantamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parcelaadiantamento",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContratoAdiantamentoId = table.Column<int>(type: "integer", nullable: false),
                    ParcelaId = table.Column<int>(type: "integer", nullable: false),
                    NumeroParcela = table.Column<int>(type: "integer", nullable: false),
                    ValorPercentualSplit = table.Column<decimal>(type: "numeric", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isColchao = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parcelaadiantamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parcelaadiantamento_contratoadiantamento_ContratoAdiantamen~",
                        column: x => x.ContratoAdiantamentoId,
                        principalSchema: "base",
                        principalTable: "contratoadiantamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_parcelaadiantamento_ContratoAdiantamentoId",
                schema: "base",
                table: "parcelaadiantamento",
                column: "ContratoAdiantamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parcelaadiantamento",
                schema: "base");
        }
    }
}

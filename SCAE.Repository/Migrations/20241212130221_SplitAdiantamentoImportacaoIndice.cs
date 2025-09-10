using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations
{
    /// <inheritdoc />
    public partial class SplitAdiantamentoImportacaoIndice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contratoadiantamento_adiantamentocarteira_AdiantamentoCarte~",
                schema: "base",
                table: "contratoadiantamento");

            migrationBuilder.DropForeignKey(
                name: "FK_indice_tipoindice_TipoIndiceId",
                schema: "base",
                table: "indice");

            migrationBuilder.DropTable(
                name: "tipoindice",
                schema: "financeiro");

            migrationBuilder.AddColumn<int>(
                name: "CodigoLigacao",
                schema: "base",
                table: "indice",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SplitPagamentoBase",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdiantamentoCarteiraId = table.Column<int>(type: "integer", nullable: false),
                    EmpresaNome = table.Column<string>(type: "text", nullable: true),
                    GalaxyId = table.Column<int>(type: "integer", nullable: true),
                    IsPercentual = table.Column<bool>(type: "boolean", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SplitPagamentoBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SplitPagamentoBase_adiantamentocarteira_AdiantamentoCarteir~",
                        column: x => x.AdiantamentoCarteiraId,
                        principalSchema: "base",
                        principalTable: "adiantamentocarteira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "base",
                table: "situacaoadiantamentocarteira",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 5, "Finalizado" });

            migrationBuilder.CreateIndex(
                name: "IX_SplitPagamentoBase_AdiantamentoCarteiraId",
                schema: "base",
                table: "SplitPagamentoBase",
                column: "AdiantamentoCarteiraId");

            migrationBuilder.AddForeignKey(
                name: "FK_contratoadiantamento_adiantamentocarteira_AdiantamentoCarte~",
                schema: "base",
                table: "contratoadiantamento",
                column: "AdiantamentoCarteiraId",
                principalSchema: "base",
                principalTable: "adiantamentocarteira",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_indice_TipoIndiceBase_TipoIndiceId",
                schema: "base",
                table: "indice",
                column: "TipoIndiceId",
                principalSchema: "base",
                principalTable: "TipoIndiceBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contratoadiantamento_adiantamentocarteira_AdiantamentoCarte~",
                schema: "base",
                table: "contratoadiantamento");

            migrationBuilder.DropForeignKey(
                name: "FK_indice_TipoIndiceBase_TipoIndiceId",
                schema: "base",
                table: "indice");

            migrationBuilder.DropTable(
                name: "SplitPagamentoBase",
                schema: "base");

            migrationBuilder.DeleteData(
                schema: "base",
                table: "situacaoadiantamentocarteira",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CodigoLigacao",
                schema: "base",
                table: "indice");

            migrationBuilder.EnsureSchema(
                name: "financeiro");

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

            migrationBuilder.AddForeignKey(
                name: "FK_contratoadiantamento_adiantamentocarteira_AdiantamentoCarte~",
                schema: "base",
                table: "contratoadiantamento",
                column: "AdiantamentoCarteiraId",
                principalSchema: "base",
                principalTable: "adiantamentocarteira",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_indice_tipoindice_TipoIndiceId",
                schema: "base",
                table: "indice",
                column: "TipoIndiceId",
                principalSchema: "financeiro",
                principalTable: "tipoindice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

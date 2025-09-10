using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations
{
    /// <inheritdoc />
    public partial class NomeMaeCertificado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contratoadiantamento_adiantamentocarteira_AdiantamentoCarte~",
                schema: "base",
                table: "contratoadiantamento");

            migrationBuilder.DropForeignKey(
                name: "FK_SplitPagamentoBase_adiantamentocarteira_AdiantamentoCarteir~",
                schema: "base",
                table: "SplitPagamentoBase");

            migrationBuilder.AddColumn<string>(
                name: "Responsavel_NomeDaMae",
                schema: "base",
                table: "assinante",
                type: "text",
                nullable: true);

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
                name: "FK_SplitPagamentoBase_adiantamentocarteira_AdiantamentoCarteir~",
                schema: "base",
                table: "SplitPagamentoBase",
                column: "AdiantamentoCarteiraId",
                principalSchema: "base",
                principalTable: "adiantamentocarteira",
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
                name: "FK_SplitPagamentoBase_adiantamentocarteira_AdiantamentoCarteir~",
                schema: "base",
                table: "SplitPagamentoBase");

            migrationBuilder.DropColumn(
                name: "Responsavel_NomeDaMae",
                schema: "base",
                table: "assinante");

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
                name: "FK_SplitPagamentoBase_adiantamentocarteira_AdiantamentoCarteir~",
                schema: "base",
                table: "SplitPagamentoBase",
                column: "AdiantamentoCarteiraId",
                principalSchema: "base",
                principalTable: "adiantamentocarteira",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

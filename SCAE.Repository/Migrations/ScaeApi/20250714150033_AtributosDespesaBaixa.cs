using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class AtributosDespesaBaixa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropColumn(
            //     name: "Discriminator",
            //     schema: "loteamento",
            //     table: "seguradora_contato");

            // migrationBuilder.DropColumn(
            //     name: "Discriminator",
            //     schema: "geral",
            //     table: "pessoaprefeituracontato");

            // migrationBuilder.DropColumn(
            //     name: "Discriminator",
            //     schema: "geral",
            //     table: "pessoacontato");

            migrationBuilder.AddColumn<int>(
                name: "CentroCustoId",
                schema: "financeiro",
                table: "despesabaixa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContaGerencialId",
                schema: "financeiro",
                table: "despesabaixa",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_despesabaixa_CentroCustoId",
                schema: "financeiro",
                table: "despesabaixa",
                column: "CentroCustoId");

            migrationBuilder.CreateIndex(
                name: "IX_despesabaixa_ContaGerencialId",
                schema: "financeiro",
                table: "despesabaixa",
                column: "ContaGerencialId");

            migrationBuilder.AddForeignKey(
                name: "FK_despesabaixa_centrodecusto_CentroCustoId",
                schema: "financeiro",
                table: "despesabaixa",
                column: "CentroCustoId",
                principalSchema: "financeiro",
                principalTable: "centrodecusto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_despesabaixa_contagerencial_ContaGerencialId",
                schema: "financeiro",
                table: "despesabaixa",
                column: "ContaGerencialId",
                principalSchema: "financeiro",
                principalTable: "contagerencial",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_despesabaixa_centrodecusto_CentroCustoId",
                schema: "financeiro",
                table: "despesabaixa");

            migrationBuilder.DropForeignKey(
                name: "FK_despesabaixa_contagerencial_ContaGerencialId",
                schema: "financeiro",
                table: "despesabaixa");

            migrationBuilder.DropIndex(
                name: "IX_despesabaixa_CentroCustoId",
                schema: "financeiro",
                table: "despesabaixa");

            migrationBuilder.DropIndex(
                name: "IX_despesabaixa_ContaGerencialId",
                schema: "financeiro",
                table: "despesabaixa");

            migrationBuilder.DropColumn(
                name: "CentroCustoId",
                schema: "financeiro",
                table: "despesabaixa");

            migrationBuilder.DropColumn(
                name: "ContaGerencialId",
                schema: "financeiro",
                table: "despesabaixa");

            // migrationBuilder.AddColumn<string>(
            //     name: "Discriminator",
            //     schema: "loteamento",
            //     table: "seguradora_contato",
            //     type: "text",
            //     nullable: false,
            //     defaultValue: "");

            // migrationBuilder.AddColumn<string>(
            //     name: "Discriminator",
            //     schema: "geral",
            //     table: "pessoaprefeituracontato",
            //     type: "text",
            //     nullable: false,
            //     defaultValue: "");

            // migrationBuilder.AddColumn<string>(
            //     name: "Discriminator",
            //     schema: "geral",
            //     table: "pessoacontato",
            //     type: "text",
            //     nullable: false,
            //     defaultValue: "");
        }
    }
}

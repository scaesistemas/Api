using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class ComissaoCorretorDespesa : Migration
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
                name: "ComissaoParcelaId",
                schema: "financeiro",
                table: "despesaparcela",
                type: "integer",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_despesaparcela_ComissaoParcelaId",
                schema: "financeiro",
                table: "despesaparcela",
                column: "ComissaoParcelaId");

            migrationBuilder.AddForeignKey(
                name: "FK_despesaparcela_receitaparcela_ComissaoParcelaId",
                schema: "financeiro",
                table: "despesaparcela",
                column: "ComissaoParcelaId",
                principalSchema: "financeiro",
                principalTable: "receitaparcela",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_despesaparcela_receitaparcela_ComissaoParcelaId",
                schema: "financeiro",
                table: "despesaparcela");

            migrationBuilder.DropIndex(
                name: "IX_despesaparcela_ComissaoParcelaId",
                schema: "financeiro",
                table: "despesaparcela");

            migrationBuilder.DropColumn(
                name: "ComissaoParcelaId",
                schema: "financeiro",
                table: "despesaparcela");

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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class IntegracaoSantander : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacorrentesplit_contacorrente_ContaCorrenteId",
                schema: "financeiro",
                table: "contacorrentesplit");

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

            migrationBuilder.AlterColumn<int>(
                name: "ContaCorrenteId",
                schema: "financeiro",
                table: "contacorrentesplit",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CodWorkerSpace",
                schema: "financeiro",
                table: "contacorrente",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_contacorrentesplit_contacorrente_ContaCorrenteId",
                schema: "financeiro",
                table: "contacorrentesplit",
                column: "ContaCorrenteId",
                principalSchema: "financeiro",
                principalTable: "contacorrente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacorrentesplit_contacorrente_ContaCorrenteId",
                schema: "financeiro",
                table: "contacorrentesplit");

            migrationBuilder.DropColumn(
                name: "CodWorkerSpace",
                schema: "financeiro",
                table: "contacorrente");

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

            migrationBuilder.AlterColumn<int>(
                name: "ContaCorrenteId",
                schema: "financeiro",
                table: "contacorrentesplit",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_contacorrentesplit_contacorrente_ContaCorrenteId",
                schema: "financeiro",
                table: "contacorrentesplit",
                column: "ContaCorrenteId",
                principalSchema: "financeiro",
                principalTable: "contacorrente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

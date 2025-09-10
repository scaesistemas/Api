using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class IntegracaoWhatsapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEnvioCobrancaWhatsapp",
                schema: "financeiro",
                table: "receitaparcela",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnviarWhatsapp",
                schema: "financeiro",
                table: "parametrocobranca",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CodigoLigacao",
                schema: "financeiro",
                table: "indice",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEnvioCobrancaWhatsapp",
                schema: "financeiro",
                table: "receitaparcela");

            migrationBuilder.DropColumn(
                name: "EnviarWhatsapp",
                schema: "financeiro",
                table: "parametrocobranca");

            migrationBuilder.DropColumn(
                name: "CodigoLigacao",
                schema: "financeiro",
                table: "indice");

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    schema: "loteamento",
            //    table: "seguradora_contato",
            //    type: "text",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    schema: "geral",
            //    table: "pessoaprefeituracontato",
            //    type: "text",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    schema: "geral",
            //    table: "pessoacontato",
            //    type: "text",
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}

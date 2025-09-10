using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class IntegracaoHokmaBradesco : Migration
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCancelamento",
                schema: "financeiro",
                table: "receitatransacao",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceIdBoleto",
                schema: "financeiro",
                table: "receitatransacao",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoStatusTransacaoId",
                schema: "financeiro",
                table: "receitatransacao",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BancoInfoPessoa_Agencia",
                schema: "geral",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BancoInfoPessoa_ChavePix",
                schema: "geral",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BancoInfoPessoa_CodigoBanco",
                schema: "geral",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BancoInfoPessoa_NumeroConta",
                schema: "geral",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BancoInfoEmpresa_Agencia",
                schema: "geral",
                table: "empresa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BancoInfoEmpresa_ChavePix",
                schema: "geral",
                table: "empresa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BancoInfoEmpresa_CodigoBanco",
                schema: "geral",
                table: "empresa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BancoInfoEmpresa_NumeroConta",
                schema: "geral",
                table: "empresa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GerarHokma",
                schema: "geral",
                table: "empresa",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GerarZoop",
                schema: "geral",
                table: "empresa",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "tipotransacao",
                schema: "financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipotransacao", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "financeiro",
                table: "tipogateway",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 6, "Hokma" });

            migrationBuilder.InsertData(
                schema: "financeiro",
                table: "tipotransacao",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Criação de parcela" },
                    { 2, "Edição de parcela" },
                    { 3, "Reajuste de índice" },
                    { 4, "Baixa" },
                    { 5, "Baixa Webhook" },
                    { 6, "Baixa Worker" },
                    { 7, "Baixa cancelada" },
                    { 8, "Baixa importada" },
                    { 9, "Emissão de boleto" },
                    { 10, "Boleto cancelado normal" },
                    { 11, "Boleto cancelado forçado" },
                    { 12, "Amortização" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_receitatransacao_TipoStatusTransacaoId",
                schema: "financeiro",
                table: "receitatransacao",
                column: "TipoStatusTransacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_receitatransacao_tipotransacao_TipoStatusTransacaoId",
                schema: "financeiro",
                table: "receitatransacao",
                column: "TipoStatusTransacaoId",
                principalSchema: "financeiro",
                principalTable: "tipotransacao",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_receitatransacao_tipotransacao_TipoStatusTransacaoId",
                schema: "financeiro",
                table: "receitatransacao");

            migrationBuilder.DropTable(
                name: "tipotransacao",
                schema: "financeiro");

            migrationBuilder.DropIndex(
                name: "IX_receitatransacao_TipoStatusTransacaoId",
                schema: "financeiro",
                table: "receitatransacao");

            migrationBuilder.DeleteData(
                schema: "financeiro",
                table: "tipogateway",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "DataCancelamento",
                schema: "financeiro",
                table: "receitatransacao");

            migrationBuilder.DropColumn(
                name: "ReferenceIdBoleto",
                schema: "financeiro",
                table: "receitatransacao");

            migrationBuilder.DropColumn(
                name: "TipoStatusTransacaoId",
                schema: "financeiro",
                table: "receitatransacao");

            migrationBuilder.DropColumn(
                name: "BancoInfoPessoa_Agencia",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "BancoInfoPessoa_ChavePix",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "BancoInfoPessoa_CodigoBanco",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "BancoInfoPessoa_NumeroConta",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "BancoInfoEmpresa_Agencia",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "BancoInfoEmpresa_ChavePix",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "BancoInfoEmpresa_CodigoBanco",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "BancoInfoEmpresa_NumeroConta",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "GerarHokma",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "GerarZoop",
                schema: "geral",
                table: "empresa");

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

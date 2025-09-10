using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class NovosCamposEmpresaContaCorrente : Migration
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

            migrationBuilder.DropColumn(
                name: "FotoDocumentoResponsavel",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "SelfieResponsavel",
                schema: "geral",
                table: "empresa");

            migrationBuilder.AddColumn<int>(
                name: "ContratoSocialLtdaId",
                schema: "geral",
                table: "empresa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FotoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelfieResponsavelId",
                schema: "geral",
                table: "empresa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteDaEmpresa",
                schema: "geral",
                table: "empresa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumentoResponsavel",
                schema: "geral",
                table: "empresa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VersoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorComissaoCorretor",
                schema: "clientes",
                table: "contrato",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "GerarBoletoComPix",
                schema: "financeiro",
                table: "contacorrente",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KeyDictKey",
                schema: "financeiro",
                table: "contacorrente",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyTypeDict",
                schema: "financeiro",
                table: "contacorrente",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TxIdSantander",
                schema: "financeiro",
                table: "contacorrente",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "empresaarquivounico",
                schema: "geral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Tamanho = table.Column<decimal>(type: "numeric", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Dados = table.Column<byte[]>(type: "bytea", nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresaarquivounico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empresaarquivounico_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "geral",
                        principalTable: "usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_empresa_ContratoSocialLtdaId",
                schema: "geral",
                table: "empresa",
                column: "ContratoSocialLtdaId");

            migrationBuilder.CreateIndex(
                name: "IX_empresa_FotoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa",
                column: "FotoDocumentoResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_empresa_SelfieResponsavelId",
                schema: "geral",
                table: "empresa",
                column: "SelfieResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_empresa_VersoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa",
                column: "VersoDocumentoResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_empresaarquivounico_UsuarioId",
                schema: "geral",
                table: "empresaarquivounico",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_empresa_empresaarquivounico_ContratoSocialLtdaId",
                schema: "geral",
                table: "empresa",
                column: "ContratoSocialLtdaId",
                principalSchema: "geral",
                principalTable: "empresaarquivounico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_empresa_empresaarquivounico_FotoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa",
                column: "FotoDocumentoResponsavelId",
                principalSchema: "geral",
                principalTable: "empresaarquivounico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_empresa_empresaarquivounico_SelfieResponsavelId",
                schema: "geral",
                table: "empresa",
                column: "SelfieResponsavelId",
                principalSchema: "geral",
                principalTable: "empresaarquivounico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_empresa_empresaarquivounico_VersoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa",
                column: "VersoDocumentoResponsavelId",
                principalSchema: "geral",
                principalTable: "empresaarquivounico",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresa_empresaarquivounico_ContratoSocialLtdaId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_empresa_empresaarquivounico_FotoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_empresa_empresaarquivounico_SelfieResponsavelId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_empresa_empresaarquivounico_VersoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropTable(
                name: "empresaarquivounico",
                schema: "geral");

            migrationBuilder.DropIndex(
                name: "IX_empresa_ContratoSocialLtdaId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropIndex(
                name: "IX_empresa_FotoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropIndex(
                name: "IX_empresa_SelfieResponsavelId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropIndex(
                name: "IX_empresa_VersoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "ContratoSocialLtdaId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "FotoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "SelfieResponsavelId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "SiteDaEmpresa",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoResponsavel",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "VersoDocumentoResponsavelId",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "ValorComissaoCorretor",
                schema: "clientes",
                table: "contrato");

            migrationBuilder.DropColumn(
                name: "GerarBoletoComPix",
                schema: "financeiro",
                table: "contacorrente");

            migrationBuilder.DropColumn(
                name: "KeyDictKey",
                schema: "financeiro",
                table: "contacorrente");

            migrationBuilder.DropColumn(
                name: "KeyTypeDict",
                schema: "financeiro",
                table: "contacorrente");

            migrationBuilder.DropColumn(
                name: "TxIdSantander",
                schema: "financeiro",
                table: "contacorrente");

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

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoDocumentoResponsavel",
                schema: "geral",
                table: "empresa",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SelfieResponsavel",
                schema: "geral",
                table: "empresa",
                type: "bytea",
                nullable: true);
        }
    }
}

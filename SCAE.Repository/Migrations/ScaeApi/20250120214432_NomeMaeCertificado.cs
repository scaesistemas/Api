using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class NomeMaeCertificado : Migration
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

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoDocumentoResponsavel",
                schema: "geral",
                table: "empresa",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RendaMensal",
                schema: "geral",
                table: "empresa",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsavel_NomeDaMae",
                schema: "geral",
                table: "empresa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SelfieResponsavel",
                schema: "geral",
                table: "empresa",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QtdeParcela",
                schema: "clientes",
                table: "contratocorretor",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CertificadoBanco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContaCorrenteId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Formato = table.Column<string>(type: "text", nullable: true),
                    DataValidacaoInicial = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataValidacaoFinal = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    Conteudo = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadoBanco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificadoBanco_contacorrente_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalSchema: "financeiro",
                        principalTable: "contacorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificadoBanco_ContaCorrenteId",
                table: "CertificadoBanco",
                column: "ContaCorrenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificadoBanco");

            migrationBuilder.DropColumn(
                name: "FotoDocumentoResponsavel",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "RendaMensal",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "Responsavel_NomeDaMae",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "SelfieResponsavel",
                schema: "geral",
                table: "empresa");

            migrationBuilder.DropColumn(
                name: "QtdeParcela",
                schema: "clientes",
                table: "contratocorretor");

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

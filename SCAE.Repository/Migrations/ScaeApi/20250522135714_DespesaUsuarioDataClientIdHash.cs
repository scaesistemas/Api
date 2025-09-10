using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class DespesaUsuarioDataClientIdHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_despesaparcela_receitaparcela_ComissaoParcelaId",
            //     schema: "financeiro",
            //     table: "despesaparcela");

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

            // migrationBuilder.DropColumn(
            //     name: "QtdeParcela",
            //     schema: "clientes",
            //     table: "contratocorretor");

            migrationBuilder.AddColumn<string>(
                name: "ClientHash",
                schema: "geral",
                table: "pessoagateway",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                schema: "geral",
                table: "pessoagateway",
                type: "text",
                nullable: true);

            // migrationBuilder.AlterColumn<int>(
            //     name: "ComissaoParcelaId",
            //     schema: "financeiro",
            //     table: "despesaparcela",
            //     type: "integer",
            //     nullable: true,
            //     oldClrType: typeof(int),
            //     oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                schema: "financeiro",
                table: "despesa",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraCriacao",
                schema: "financeiro",
                table: "despesa",
                type: "interval",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                schema: "financeiro",
                table: "despesa",
                type: "integer",
                nullable: true);

            // migrationBuilder.CreateTable(
            //     name: "leaddocumento",
            //     schema: "geral",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "integer", nullable: false)
            //             .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //         LeadId = table.Column<int>(type: "integer", nullable: false),
            //         Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
            //         Tamanho = table.Column<decimal>(type: "numeric", nullable: false),
            //         Tipo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
            //         Dados = table.Column<byte[]>(type: "bytea", nullable: true),
            //         DataEmissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
            //         UsuarioId = table.Column<int>(type: "integer", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_leaddocumento", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_leaddocumento_lead_LeadId",
            //             column: x => x.LeadId,
            //             principalSchema: "geral",
            //             principalTable: "lead",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_leaddocumento_usuario_UsuarioId",
            //             column: x => x.UsuarioId,
            //             principalSchema: "geral",
            //             principalTable: "usuario",
            //             principalColumn: "Id");
            //     });

            migrationBuilder.CreateIndex(
                name: "IX_despesa_UsuarioId",
                schema: "financeiro",
                table: "despesa",
                column: "UsuarioId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_leaddocumento_LeadId",
            //     schema: "geral",
            //     table: "leaddocumento",
            //     column: "LeadId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_leaddocumento_UsuarioId",
            //     schema: "geral",
            //     table: "leaddocumento",
            //     column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_despesa_usuario_UsuarioId",
                schema: "financeiro",
                table: "despesa",
                column: "UsuarioId",
                principalSchema: "geral",
                principalTable: "usuario",
                principalColumn: "Id");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_despesaparcela_receitaparcela_ComissaoParcelaId",
            //     schema: "financeiro",
            //     table: "despesaparcela",
            //     column: "ComissaoParcelaId",
            //     principalSchema: "financeiro",
            //     principalTable: "receitaparcela",
            //     principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_despesa_usuario_UsuarioId",
                schema: "financeiro",
                table: "despesa");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_despesaparcela_receitaparcela_ComissaoParcelaId",
            //     schema: "financeiro",
            //     table: "despesaparcela");

            // migrationBuilder.DropTable(
            //     name: "leaddocumento",
            //     schema: "geral");

            migrationBuilder.DropIndex(
                name: "IX_despesa_UsuarioId",
                schema: "financeiro",
                table: "despesa");

            migrationBuilder.DropColumn(
                name: "ClientHash",
                schema: "geral",
                table: "pessoagateway");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "geral",
                table: "pessoagateway");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                schema: "financeiro",
                table: "despesa");

            migrationBuilder.DropColumn(
                name: "HoraCriacao",
                schema: "financeiro",
                table: "despesa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                schema: "financeiro",
                table: "despesa");

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

            // migrationBuilder.AlterColumn<int>(
            //     name: "ComissaoParcelaId",
            //     schema: "financeiro",
            //     table: "despesaparcela",
            //     type: "integer",
            //     nullable: false,
            //     defaultValue: 0,
            //     oldClrType: typeof(int),
            //     oldType: "integer",
            //     oldNullable: true);

            // migrationBuilder.AddColumn<int>(
            //     name: "QtdeParcela",
            //     schema: "clientes",
            //     table: "contratocorretor",
            //     type: "integer",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_despesaparcela_receitaparcela_ComissaoParcelaId",
            //     schema: "financeiro",
            //     table: "despesaparcela",
            //     column: "ComissaoParcelaId",
            //     principalSchema: "financeiro",
            //     principalTable: "receitaparcela",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}

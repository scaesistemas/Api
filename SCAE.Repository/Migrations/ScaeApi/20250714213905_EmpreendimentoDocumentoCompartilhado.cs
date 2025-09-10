using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class EmpreendimentoDocumentoCompartilhado : Migration
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

            migrationBuilder.CreateTable(
                name: "empreendimentoDocumentoCompartilhado",
                schema: "empreendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpreendimentoId = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Tamanho = table.Column<decimal>(type: "numeric", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Dados = table.Column<byte[]>(type: "bytea", nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empreendimentoDocumentoCompartilhado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empreendimentoDocumentoCompartilhado_empreendimento_Empreen~",
                        column: x => x.EmpreendimentoId,
                        principalSchema: "empreendimento",
                        principalTable: "empreendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empreendimentoDocumentoCompartilhado_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "geral",
                        principalTable: "usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_empreendimentoDocumentoCompartilhado_EmpreendimentoId",
                schema: "empreendimento",
                table: "empreendimentoDocumentoCompartilhado",
                column: "EmpreendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_empreendimentoDocumentoCompartilhado_UsuarioId",
                schema: "empreendimento",
                table: "empreendimentoDocumentoCompartilhado",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empreendimentoDocumentoCompartilhado",
                schema: "empreendimento");

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

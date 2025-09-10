using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class DespesaObservacao : Migration
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
                name: "despesaobservacao",
                schema: "financeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DespesaId = table.Column<int>(type: "integer", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_despesaobservacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_despesaobservacao_despesa_DespesaId",
                        column: x => x.DespesaId,
                        principalSchema: "financeiro",
                        principalTable: "despesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_despesaobservacao_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "geral",
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_despesaobservacao_DespesaId",
                schema: "financeiro",
                table: "despesaobservacao",
                column: "DespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_despesaobservacao_UsuarioId",
                schema: "financeiro",
                table: "despesaobservacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "despesaobservacao",
                schema: "financeiro");

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

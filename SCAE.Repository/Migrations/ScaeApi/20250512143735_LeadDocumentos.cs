using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class LeadDocumentos : Migration
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
                name: "leaddocumento",
                schema: "geral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeadId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Tamanho = table.Column<decimal>(type: "numeric", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Dados = table.Column<byte[]>(type: "bytea", nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaddocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaddocumento_lead_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "geral",
                        principalTable: "lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_leaddocumento_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "geral",
                        principalTable: "usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_leaddocumento_LeadId",
                schema: "geral",
                table: "leaddocumento",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_leaddocumento_UsuarioId",
                schema: "geral",
                table: "leaddocumento",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaddocumento",
                schema: "geral");

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

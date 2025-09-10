using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCAE.Data.Migrations
{
    /// <inheritdoc />
    public partial class TermosDeUso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assinante_estado_Endereco_EstadoId",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropForeignKey(
                name: "FK_assinante_estado_Responsavel_Endereco_EstadoId",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropForeignKey(
                name: "FK_assinante_municipio_Endereco_MunicipioId",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropForeignKey(
                name: "FK_assinante_municipio_Responsavel_Endereco_MunicipioId",
                schema: "base",
                table: "assinante");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "geral",
                table: "municipio",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "geral",
                table: "estado",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "base",
                table: "assinantecontato",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel_Endereco_Bairro",
                schema: "base",
                table: "assinante",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco_Bairro",
                schema: "base",
                table: "assinante",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssinanteTermo_DataAssinatura",
                schema: "base",
                table: "assinante",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AssinanteTermo_DataPrimeiraAssinatura",
                schema: "base",
                table: "assinante",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssinanteTermo_TermosDeUsoId",
                schema: "base",
                table: "assinante",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tipotermoempresa",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipotermoempresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "termosdeuso",
                schema: "base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataRegistro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TermoString = table.Column<string>(type: "text", nullable: true),
                    TipoTermoEmpresaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_termosdeuso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_termosdeuso_tipotermoempresa_TipoTermoEmpresaId",
                        column: x => x.TipoTermoEmpresaId,
                        principalSchema: "base",
                        principalTable: "tipotermoempresa",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "base",
                table: "tipotermoempresa",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Scae" },
                    { 2, "Celcoin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_assinante_AssinanteTermo_TermosDeUsoId",
                schema: "base",
                table: "assinante",
                column: "AssinanteTermo_TermosDeUsoId");

            migrationBuilder.CreateIndex(
                name: "IX_termosdeuso_TipoTermoEmpresaId",
                schema: "base",
                table: "termosdeuso",
                column: "TipoTermoEmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_assinante_estado_Endereco_EstadoId",
                schema: "base",
                table: "assinante",
                column: "Endereco_EstadoId",
                principalSchema: "geral",
                principalTable: "estado",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assinante_estado_Responsavel_Endereco_EstadoId",
                schema: "base",
                table: "assinante",
                column: "Responsavel_Endereco_EstadoId",
                principalSchema: "geral",
                principalTable: "estado",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assinante_municipio_Endereco_MunicipioId",
                schema: "base",
                table: "assinante",
                column: "Endereco_MunicipioId",
                principalSchema: "geral",
                principalTable: "municipio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assinante_municipio_Responsavel_Endereco_MunicipioId",
                schema: "base",
                table: "assinante",
                column: "Responsavel_Endereco_MunicipioId",
                principalSchema: "geral",
                principalTable: "municipio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_assinante_termosdeuso_AssinanteTermo_TermosDeUsoId",
                schema: "base",
                table: "assinante",
                column: "AssinanteTermo_TermosDeUsoId",
                principalSchema: "base",
                principalTable: "termosdeuso",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assinante_estado_Endereco_EstadoId",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropForeignKey(
                name: "FK_assinante_estado_Responsavel_Endereco_EstadoId",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropForeignKey(
                name: "FK_assinante_municipio_Endereco_MunicipioId",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropForeignKey(
                name: "FK_assinante_municipio_Responsavel_Endereco_MunicipioId",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropForeignKey(
                name: "FK_assinante_termosdeuso_AssinanteTermo_TermosDeUsoId",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropTable(
                name: "termosdeuso",
                schema: "base");

            migrationBuilder.DropTable(
                name: "tipotermoempresa",
                schema: "base");

            migrationBuilder.DropIndex(
                name: "IX_assinante_AssinanteTermo_TermosDeUsoId",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropColumn(
                name: "AssinanteTermo_DataAssinatura",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropColumn(
                name: "AssinanteTermo_DataPrimeiraAssinatura",
                schema: "base",
                table: "assinante");

            migrationBuilder.DropColumn(
                name: "AssinanteTermo_TermosDeUsoId",
                schema: "base",
                table: "assinante");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "geral",
                table: "municipio",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "geral",
                table: "estado",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "base",
                table: "assinantecontato",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel_Endereco_Bairro",
                schema: "base",
                table: "assinante",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Endereco_Bairro",
                schema: "base",
                table: "assinante",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_assinante_estado_Endereco_EstadoId",
                schema: "base",
                table: "assinante",
                column: "Endereco_EstadoId",
                principalSchema: "geral",
                principalTable: "estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assinante_estado_Responsavel_Endereco_EstadoId",
                schema: "base",
                table: "assinante",
                column: "Responsavel_Endereco_EstadoId",
                principalSchema: "geral",
                principalTable: "estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assinante_municipio_Endereco_MunicipioId",
                schema: "base",
                table: "assinante",
                column: "Endereco_MunicipioId",
                principalSchema: "geral",
                principalTable: "municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_assinante_municipio_Responsavel_Endereco_MunicipioId",
                schema: "base",
                table: "assinante",
                column: "Responsavel_Endereco_MunicipioId",
                principalSchema: "geral",
                principalTable: "municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

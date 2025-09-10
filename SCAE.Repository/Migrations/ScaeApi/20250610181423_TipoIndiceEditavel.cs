using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class TipoIndiceEditavel : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "Criado",
                schema: "financeiro",
                table: "tipoindice",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EdicaoBloqueada",
                schema: "financeiro",
                table: "tipoindice",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NomeEditavel",
                schema: "financeiro",
                table: "tipoindice",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Criado", "EdicaoBloqueada", "NomeEditavel" },
                values: new object[] { true, true, "IGP-M (FGV)" });

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Criado", "EdicaoBloqueada", "NomeEditavel" },
                values: new object[] { true, true, "INCC (FGV)" });

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Criado", "EdicaoBloqueada", "NomeEditavel" },
                values: new object[] { true, true, "INPC (IBGE)" });

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Criado", "EdicaoBloqueada", "NomeEditavel" },
                values: new object[] { true, true, "PARCELAS FIXAS" });

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Criado", "EdicaoBloqueada", "NomeEditavel" },
                values: new object[] { true, true, "SALÁRIO MÍNIMO" });

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Criado", "EdicaoBloqueada", "NomeEditavel" },
                values: new object[] { true, true, "UFIR" });

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Criado", "EdicaoBloqueada", "NomeEditavel" },
                values: new object[] { true, true, "IPCA" });

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Criado", "EdicaoBloqueada", "NomeEditavel" },
                values: new object[] { true, true, "Outro" });

            migrationBuilder.InsertData(
                schema: "financeiro",
                table: "tipoindice",
                columns: new[] { "Id", "Criado", "EdicaoBloqueada", "Nome", "NomeEditavel" },
                values: new object[,]
                {
                    { 10, false, false, "Novo Tipo Indice 1", "Novo Tipo Indice 1" },
                    { 11, false, false, "Novo Tipo Indice 2", "Novo Tipo Indice 2" },
                    { 12, false, false, "Novo Tipo Indice 3", "Novo Tipo Indice 3" },
                    { 13, false, false, "Novo Tipo Indice 4", "Novo Tipo Indice 4" },
                    { 14, false, false, "Novo Tipo Indice 5", "Novo Tipo Indice 5" },
                    { 15, false, false, "Novo Tipo Indice 6", "Novo Tipo Indice 6" },
                    { 16, false, false, "Novo Tipo Indice 7", "Novo Tipo Indice 7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "financeiro",
                table: "tipoindice",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DropColumn(
                name: "Criado",
                schema: "financeiro",
                table: "tipoindice");

            migrationBuilder.DropColumn(
                name: "EdicaoBloqueada",
                schema: "financeiro",
                table: "tipoindice");

            migrationBuilder.DropColumn(
                name: "NomeEditavel",
                schema: "financeiro",
                table: "tipoindice");

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

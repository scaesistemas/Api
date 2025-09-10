using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class NovosTipoEmpresa : Migration
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

            migrationBuilder.InsertData(
                schema: "geral",
                table: "tipoempresa",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 7, "Ltda" },
                    { 8, "Imobiliária" },
                    { 9, "Urbanizadora" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "geral",
                table: "tipoempresa",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "geral",
                table: "tipoempresa",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "geral",
                table: "tipoempresa",
                keyColumn: "Id",
                keyValue: 9);

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

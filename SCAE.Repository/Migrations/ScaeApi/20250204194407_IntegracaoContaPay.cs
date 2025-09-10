using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class IntegracaoContaPay : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "ContaPay_AccessToken",
                schema: "financeiro",
                table: "parametrogatway",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContaPay_email",
                schema: "financeiro",
                table: "parametrogatway",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "financeiro",
                table: "tipogateway",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 5, "ContaPay" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "financeiro",
                table: "tipogateway",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ContaPay_AccessToken",
                schema: "financeiro",
                table: "parametrogatway");

            migrationBuilder.DropColumn(
                name: "ContaPay_email",
                schema: "financeiro",
                table: "parametrogatway");

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

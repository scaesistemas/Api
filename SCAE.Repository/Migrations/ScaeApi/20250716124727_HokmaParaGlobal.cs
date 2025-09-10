using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class HokmaParaGlobal : Migration
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
                name: "GalaxPay_DocumentosEnviados",
                schema: "financeiro",
                table: "parametrogatway",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GlobalPay_DocumentosEnviados",
                schema: "financeiro",
                table: "parametrogatway",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlobalPay_Senha",
                schema: "financeiro",
                table: "parametrogatway",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlobalPay_email",
                schema: "financeiro",
                table: "parametrogatway",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GlobalPay_isSubconta",
                schema: "financeiro",
                table: "parametrogatway",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "GlobalPay_isSubcontaAtiva",
                schema: "financeiro",
                table: "parametrogatway",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipogateway",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nome",
                value: "Global");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GalaxPay_DocumentosEnviados",
                schema: "financeiro",
                table: "parametrogatway");

            migrationBuilder.DropColumn(
                name: "GlobalPay_DocumentosEnviados",
                schema: "financeiro",
                table: "parametrogatway");

            migrationBuilder.DropColumn(
                name: "GlobalPay_Senha",
                schema: "financeiro",
                table: "parametrogatway");

            migrationBuilder.DropColumn(
                name: "GlobalPay_email",
                schema: "financeiro",
                table: "parametrogatway");

            migrationBuilder.DropColumn(
                name: "GlobalPay_isSubconta",
                schema: "financeiro",
                table: "parametrogatway");

            migrationBuilder.DropColumn(
                name: "GlobalPay_isSubcontaAtiva",
                schema: "financeiro",
                table: "parametrogatway");

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
            //    defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "financeiro",
                table: "tipogateway",
                keyColumn: "Id",
                keyValue: 6,
                column: "Nome",
                value: "Hokma");
        }
    }
}

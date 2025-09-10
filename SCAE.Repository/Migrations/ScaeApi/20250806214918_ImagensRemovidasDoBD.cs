using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class ImagensRemovidasDoBD : Migration
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

            migrationBuilder.DropColumn(
                name: "FotoPrincipal",
                schema: "empreendimento",
                table: "empreendimento");

            migrationBuilder.DropColumn(
                name: "MapaInterativo_Imagem",
                schema: "empreendimento",
                table: "empreendimento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPrincipal",
                schema: "empreendimento",
                table: "empreendimento",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MapaInterativo_Imagem",
                schema: "empreendimento",
                table: "empreendimento",
                type: "bytea",
                nullable: true);
        }
    }
}

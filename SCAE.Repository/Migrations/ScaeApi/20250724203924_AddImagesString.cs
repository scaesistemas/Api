using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class AddImagesString : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "ImagemPrincipal",
                schema: "empreendimento",
                table: "empreendimento",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MapaInterativo_ImagemMapa",
                schema: "empreendimento",
                table: "empreendimento",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemPrincipal",
                schema: "empreendimento",
                table: "empreendimento");

            migrationBuilder.DropColumn(
                name: "MapaInterativo_ImagemMapa",
                schema: "empreendimento",
                table: "empreendimento");

        //     migrationBuilder.AddColumn<string>(
        //         name: "Discriminator",
        //         schema: "loteamento",
        //         table: "seguradora_contato",
        //         type: "text",
        //         nullable: false,
        //         defaultValue: "");

        //     migrationBuilder.AddColumn<string>(
        //         name: "Discriminator",
        //         schema: "geral",
        //         table: "pessoaprefeituracontato",
        //         type: "text",
        //         nullable: false,
        //         defaultValue: "");

        //     migrationBuilder.AddColumn<string>(
        //         name: "Discriminator",
        //         schema: "geral",
        //         table: "pessoacontato",
        //         type: "text",
        //         nullable: false,
        //         defaultValue: "");
        }
    }
}

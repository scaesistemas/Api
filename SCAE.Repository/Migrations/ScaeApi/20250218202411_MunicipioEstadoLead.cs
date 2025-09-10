using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class MunicipioEstadoLead : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_lead_EstadoId",
                schema: "geral",
                table: "lead",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_lead_MunicipioId",
                schema: "geral",
                table: "lead",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_estado_EstadoId",
                schema: "geral",
                table: "lead",
                column: "EstadoId",
                principalSchema: "geral",
                principalTable: "estado",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_municipio_MunicipioId",
                schema: "geral",
                table: "lead",
                column: "MunicipioId",
                principalSchema: "geral",
                principalTable: "municipio",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lead_estado_EstadoId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_lead_municipio_MunicipioId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropIndex(
                name: "IX_lead_EstadoId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropIndex(
                name: "IX_lead_MunicipioId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                schema: "geral",
                table: "lead");

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    schema: "loteamento",
            //    table: "seguradora_contato",
            //    type: "text",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    schema: "geral",
            //    table: "pessoaprefeituracontato",
            //    type: "text",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    schema: "geral",
            //    table: "pessoacontato",
            //    type: "text",
            //    nullable: false,
            //    defaultValue: "");
        }
    }
}

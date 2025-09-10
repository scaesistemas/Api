using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class CorretoresEmpreendimentos : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "GalaxPay_isSubconta",
                schema: "financeiro",
                table: "parametrogatway",
                type: "boolean",
                defaultValue: false,
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "GalaxPay_isSubcontaAtiva",
                schema: "financeiro",
                table: "parametrogatway",
                type: "boolean",
                defaultValue: false,
                nullable: false);

            migrationBuilder.CreateTable(
                name: "empreendimentopessoa",
                schema: "geral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmpreendimentoId = table.Column<int>(type: "integer", nullable: false),
                    PessoaId = table.Column<int>(type: "integer", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empreendimentopessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empreendimentopessoa_empreendimento_EmpreendimentoId",
                        column: x => x.EmpreendimentoId,
                        principalSchema: "empreendimento",
                        principalTable: "empreendimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_empreendimentopessoa_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "geral",
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_empreendimentopessoa_EmpreendimentoId",
                schema: "geral",
                table: "empreendimentopessoa",
                column: "EmpreendimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_empreendimentopessoa_PessoaId",
                schema: "geral",
                table: "empreendimentopessoa",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empreendimentopessoa",
                schema: "geral");

            migrationBuilder.DropColumn(
                name: "GalaxPay_isSubconta",
                schema: "financeiro",
                table: "parametrogatway");

            migrationBuilder.DropColumn(
                name: "GalaxPay_isSubcontaAtiva",
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

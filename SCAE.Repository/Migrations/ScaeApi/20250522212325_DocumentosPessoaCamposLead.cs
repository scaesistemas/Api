using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SCAE.Data.Migrations.ScaeApi
{
    /// <inheritdoc />
    public partial class DocumentosPessoaCamposLead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lead_comoleadcontactou_ComoLeadContactouId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_lead_comoleadnosencontrou_ComoLeadNosEncontrouId",
                schema: "geral",
                table: "lead");

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
                name: "Conjuge_Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoaprefeitura",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoaprefeitura",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComprovanteResidencialId",
                schema: "geral",
                table: "pessoa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conjuge_Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FotoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JuridicaResponsavel_Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RendaMensal",
                schema: "geral",
                table: "pessoa",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelfieDocumentoId",
                schema: "geral",
                table: "pessoa",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteDaPessoa",
                schema: "geral",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumentoPessoa",
                schema: "geral",
                table: "pessoa",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VersoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComoLeadNosEncontrouId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ComoLeadContactouId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                schema: "geral",
                table: "lead",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                schema: "geral",
                table: "lead",
                type: "character varying(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                schema: "geral",
                table: "lead",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExpedicao",
                schema: "geral",
                table: "lead",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                schema: "geral",
                table: "lead",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                schema: "geral",
                table: "lead",
                type: "character varying(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                schema: "geral",
                table: "lead",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgaoExpedido",
                schema: "geral",
                table: "lead",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Qualificacao_EscolaridadeId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Qualificacao_EstadoCivilId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Qualificacao_NacionalidadeId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Qualificacao_NaturalidadeId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "lead",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Qualificacao_ProfissaoId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Qualificacao_RendaBruta",
                schema: "geral",
                table: "lead",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Qualificacao_RendaLiquida",
                schema: "geral",
                table: "lead",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualificacao_Susep",
                schema: "geral",
                table: "lead",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                schema: "geral",
                table: "lead",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SexoId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeParcela",
                schema: "clientes",
                table: "contratocorretor",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            // migrationBuilder.CreateTable(
            //     name: "leaddocumento",
            //     schema: "geral",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "integer", nullable: false)
            //             .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //         LeadId = table.Column<int>(type: "integer", nullable: false),
            //         Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
            //         Tamanho = table.Column<decimal>(type: "numeric", nullable: false),
            //         Tipo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
            //         Dados = table.Column<byte[]>(type: "bytea", nullable: true),
            //         DataEmissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
            //         UsuarioId = table.Column<int>(type: "integer", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_leaddocumento", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_leaddocumento_lead_LeadId",
            //             column: x => x.LeadId,
            //             principalSchema: "geral",
            //             principalTable: "lead",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_leaddocumento_usuario_UsuarioId",
            //             column: x => x.UsuarioId,
            //             principalSchema: "geral",
            //             principalTable: "usuario",
            //             principalColumn: "Id");
            //     });

            migrationBuilder.CreateTable(
                name: "pessoaarquivounico",
                schema: "geral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Tamanho = table.Column<decimal>(type: "numeric", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Dados = table.Column<byte[]>(type: "bytea", nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoaarquivounico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pessoaarquivounico_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "geral",
                        principalTable: "usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_ComprovanteResidencialId",
                schema: "geral",
                table: "pessoa",
                column: "ComprovanteResidencialId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_FotoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa",
                column: "FotoDocumentoPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_SelfieDocumentoId",
                schema: "geral",
                table: "pessoa",
                column: "SelfieDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_VersoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa",
                column: "VersoDocumentoPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_lead_Qualificacao_EscolaridadeId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_EscolaridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_lead_Qualificacao_EstadoCivilId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_lead_Qualificacao_NacionalidadeId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_NacionalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_lead_Qualificacao_NaturalidadeId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_NaturalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_lead_Qualificacao_ProfissaoId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_ProfissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_lead_SexoId",
                schema: "geral",
                table: "lead",
                column: "SexoId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_leaddocumento_LeadId",
            //     schema: "geral",
            //     table: "leaddocumento",
            //     column: "LeadId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_leaddocumento_UsuarioId",
            //     schema: "geral",
            //     table: "leaddocumento",
            //     column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_pessoaarquivounico_UsuarioId",
                schema: "geral",
                table: "pessoaarquivounico",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_comoleadcontactou_ComoLeadContactouId",
                schema: "geral",
                table: "lead",
                column: "ComoLeadContactouId",
                principalSchema: "geral",
                principalTable: "comoleadcontactou",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_comoleadnosencontrou_ComoLeadNosEncontrouId",
                schema: "geral",
                table: "lead",
                column: "ComoLeadNosEncontrouId",
                principalSchema: "geral",
                principalTable: "comoleadnosencontrou",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_estadocivil_Qualificacao_EstadoCivilId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_EstadoCivilId",
                principalSchema: "geral",
                principalTable: "estadocivil",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_municipio_Qualificacao_NaturalidadeId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_NaturalidadeId",
                principalSchema: "geral",
                principalTable: "municipio",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_nacionalidade_Qualificacao_NacionalidadeId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_NacionalidadeId",
                principalSchema: "geral",
                principalTable: "nacionalidade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_profissao_Qualificacao_ProfissaoId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_ProfissaoId",
                principalSchema: "geral",
                principalTable: "profissao",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_sexo_SexoId",
                schema: "geral",
                table: "lead",
                column: "SexoId",
                principalSchema: "geral",
                principalTable: "sexo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_lead_tipoescolaridade_Qualificacao_EscolaridadeId",
                schema: "geral",
                table: "lead",
                column: "Qualificacao_EscolaridadeId",
                principalSchema: "geral",
                principalTable: "tipoescolaridade",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_pessoaarquivounico_ComprovanteResidencialId",
                schema: "geral",
                table: "pessoa",
                column: "ComprovanteResidencialId",
                principalSchema: "geral",
                principalTable: "pessoaarquivounico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_pessoaarquivounico_FotoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa",
                column: "FotoDocumentoPessoaId",
                principalSchema: "geral",
                principalTable: "pessoaarquivounico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_pessoaarquivounico_SelfieDocumentoId",
                schema: "geral",
                table: "pessoa",
                column: "SelfieDocumentoId",
                principalSchema: "geral",
                principalTable: "pessoaarquivounico",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pessoa_pessoaarquivounico_VersoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa",
                column: "VersoDocumentoPessoaId",
                principalSchema: "geral",
                principalTable: "pessoaarquivounico",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lead_comoleadcontactou_ComoLeadContactouId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_lead_comoleadnosencontrou_ComoLeadNosEncontrouId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_lead_estadocivil_Qualificacao_EstadoCivilId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_lead_municipio_Qualificacao_NaturalidadeId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_lead_nacionalidade_Qualificacao_NacionalidadeId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_lead_profissao_Qualificacao_ProfissaoId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_lead_sexo_SexoId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_lead_tipoescolaridade_Qualificacao_EscolaridadeId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_pessoaarquivounico_ComprovanteResidencialId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_pessoaarquivounico_FotoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_pessoaarquivounico_SelfieDocumentoId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropForeignKey(
                name: "FK_pessoa_pessoaarquivounico_VersoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropTable(
                name: "leaddocumento",
                schema: "geral");

            migrationBuilder.DropTable(
                name: "pessoaarquivounico",
                schema: "geral");

            migrationBuilder.DropIndex(
                name: "IX_pessoa_ComprovanteResidencialId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropIndex(
                name: "IX_pessoa_FotoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropIndex(
                name: "IX_pessoa_SelfieDocumentoId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropIndex(
                name: "IX_pessoa_VersoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropIndex(
                name: "IX_lead_Qualificacao_EscolaridadeId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropIndex(
                name: "IX_lead_Qualificacao_EstadoCivilId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropIndex(
                name: "IX_lead_Qualificacao_NacionalidadeId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropIndex(
                name: "IX_lead_Qualificacao_NaturalidadeId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropIndex(
                name: "IX_lead_Qualificacao_ProfissaoId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropIndex(
                name: "IX_lead_SexoId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Conjuge_Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoaprefeitura");

            migrationBuilder.DropColumn(
                name: "Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoaprefeitura");

            migrationBuilder.DropColumn(
                name: "ComprovanteResidencialId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "Conjuge_Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "FotoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "JuridicaResponsavel_Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "RendaMensal",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "SelfieDocumentoId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "SiteDaPessoa",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoPessoa",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "VersoDocumentoPessoaId",
                schema: "geral",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "Bairro",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Cep",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Complemento",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "DataExpedicao",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Numero",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "OrgaoExpedido",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Qualificacao_EscolaridadeId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Qualificacao_EstadoCivilId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Qualificacao_NacionalidadeId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Qualificacao_NaturalidadeId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Qualificacao_ProfissaoExtra",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Qualificacao_ProfissaoId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Qualificacao_RendaBruta",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Qualificacao_RendaLiquida",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Qualificacao_Susep",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "Rg",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "SexoId",
                schema: "geral",
                table: "lead");

            migrationBuilder.DropColumn(
                name: "QuantidadeParcela",
                schema: "clientes",
                table: "contratocorretor");

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

            migrationBuilder.AlterColumn<int>(
                name: "ComoLeadNosEncontrouId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComoLeadContactouId",
                schema: "geral",
                table: "lead",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lead_comoleadcontactou_ComoLeadContactouId",
                schema: "geral",
                table: "lead",
                column: "ComoLeadContactouId",
                principalSchema: "geral",
                principalTable: "comoleadcontactou",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_lead_comoleadnosencontrou_ComoLeadNosEncontrouId",
                schema: "geral",
                table: "lead",
                column: "ComoLeadNosEncontrouId",
                principalSchema: "geral",
                principalTable: "comoleadnosencontrou",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

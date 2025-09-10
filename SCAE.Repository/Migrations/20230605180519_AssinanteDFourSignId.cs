using Microsoft.EntityFrameworkCore.Migrations;

namespace SCAE.Data.Migrations
{
    public partial class AssinanteDFourSignId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Responsavel_CodigoZoop",
                schema: "base",
                table: "assinante",
                type: "character varying(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DFourSignSafeId",
                schema: "base",
                table: "assinante",
                type: "text",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DFourSignSafeId",
                schema: "base",
                table: "assinante");

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel_CodigoZoop",
                schema: "base",
                table: "assinante",
                type: "character varying(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(45)",
                oldMaxLength: 45,
                oldNullable: true);
        }
    }
}

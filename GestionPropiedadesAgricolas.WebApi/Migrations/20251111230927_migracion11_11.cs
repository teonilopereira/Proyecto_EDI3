using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPropiedadesAgricolas.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class migracion11_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreCompleto",
                table: "Trabajadores",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Trabajadores",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Trabajadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Parcelas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Trabajadores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Trabajadores");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Trabajadores",
                newName: "NombreCompleto");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Parcelas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPropiedadesAgricolas.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RamaValidacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CultivoPorParcela_Cultivo_CultivoId",
                table: "CultivoPorParcela");

            migrationBuilder.DropForeignKey(
                name: "FK_CultivoPorParcela_Parcela_ParcelaId",
                table: "CultivoPorParcela");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcela_PropiedadesAgricolas_PropiedadAgricolaId",
                table: "Parcela");

            migrationBuilder.DropForeignKey(
                name: "FK_PropiedadesAgricolas_Propietario_PropietarioId",
                table: "PropiedadesAgricolas");

            migrationBuilder.DropForeignKey(
                name: "FK_PropiedadesAgricolas_Ubicacion_UbicacionId",
                table: "PropiedadesAgricolas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorPorPropiedadAgricola_PropiedadesAgricolas_PropiedadAgricolaId",
                table: "ProveedorPorPropiedadAgricola");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedorPorPropiedadAgricola_Proveedor_ProveedorId",
                table: "ProveedorPorPropiedadAgricola");

            migrationBuilder.DropForeignKey(
                name: "FK_Trabajador_PropiedadesAgricolas_PropiedadAgricolaId",
                table: "Trabajador");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UsuarioPorPropiedadAgricola");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ubicacion",
                table: "Ubicacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trabajador",
                table: "Trabajador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProveedorPorPropiedadAgricola",
                table: "ProveedorPorPropiedadAgricola");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Propietario",
                table: "Propietario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropiedadesAgricolas",
                table: "PropiedadesAgricolas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcela",
                table: "Parcela");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CultivoPorParcela",
                table: "CultivoPorParcela");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cultivo",
                table: "Cultivo");

            migrationBuilder.RenameTable(
                name: "Ubicacion",
                newName: "Ubicacions");

            migrationBuilder.RenameTable(
                name: "Trabajador",
                newName: "Trabajadores");

            migrationBuilder.RenameTable(
                name: "ProveedorPorPropiedadAgricola",
                newName: "ProveedoresPorPropiedadAgricolas");

            migrationBuilder.RenameTable(
                name: "Proveedor",
                newName: "Proveedores");

            migrationBuilder.RenameTable(
                name: "Propietario",
                newName: "Propietarios");

            migrationBuilder.RenameTable(
                name: "PropiedadesAgricolas",
                newName: "PropiedadAgricola");

            migrationBuilder.RenameTable(
                name: "Parcela",
                newName: "Parcelas");

            migrationBuilder.RenameTable(
                name: "CultivoPorParcela",
                newName: "CultivosPorParcelas");

            migrationBuilder.RenameTable(
                name: "Cultivo",
                newName: "Cultivos");

            migrationBuilder.RenameIndex(
                name: "IX_Trabajador_PropiedadAgricolaId",
                table: "Trabajadores",
                newName: "IX_Trabajadores_PropiedadAgricolaId");

            migrationBuilder.RenameIndex(
                name: "IX_ProveedorPorPropiedadAgricola_ProveedorId",
                table: "ProveedoresPorPropiedadAgricolas",
                newName: "IX_ProveedoresPorPropiedadAgricolas_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProveedorPorPropiedadAgricola_PropiedadAgricolaId",
                table: "ProveedoresPorPropiedadAgricolas",
                newName: "IX_ProveedoresPorPropiedadAgricolas_PropiedadAgricolaId");

            migrationBuilder.RenameIndex(
                name: "IX_PropiedadesAgricolas_UbicacionId",
                table: "PropiedadAgricola",
                newName: "IX_PropiedadAgricola_UbicacionId");

            migrationBuilder.RenameIndex(
                name: "IX_PropiedadesAgricolas_PropietarioId",
                table: "PropiedadAgricola",
                newName: "IX_PropiedadAgricola_PropietarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcela_PropiedadAgricolaId",
                table: "Parcelas",
                newName: "IX_Parcelas_PropiedadAgricolaId");

            migrationBuilder.RenameIndex(
                name: "IX_CultivoPorParcela_ParcelaId",
                table: "CultivosPorParcelas",
                newName: "IX_CultivosPorParcelas_ParcelaId");

            migrationBuilder.RenameIndex(
                name: "IX_CultivoPorParcela_CultivoId",
                table: "CultivosPorParcelas",
                newName: "IX_CultivosPorParcelas_CultivoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ubicacions",
                table: "Ubicacions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trabajadores",
                table: "Trabajadores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProveedoresPorPropiedadAgricolas",
                table: "ProveedoresPorPropiedadAgricolas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Propietarios",
                table: "Propietarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropiedadAgricola",
                table: "PropiedadAgricola",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcelas",
                table: "Parcelas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CultivosPorParcelas",
                table: "CultivosPorParcelas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cultivos",
                table: "Cultivos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CultivosPorParcelas_Cultivos_CultivoId",
                table: "CultivosPorParcelas",
                column: "CultivoId",
                principalTable: "Cultivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CultivosPorParcelas_Parcelas_ParcelaId",
                table: "CultivosPorParcelas",
                column: "ParcelaId",
                principalTable: "Parcelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcelas_PropiedadAgricola_PropiedadAgricolaId",
                table: "Parcelas",
                column: "PropiedadAgricolaId",
                principalTable: "PropiedadAgricola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropiedadAgricola_Propietarios_PropietarioId",
                table: "PropiedadAgricola",
                column: "PropietarioId",
                principalTable: "Propietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropiedadAgricola_Ubicacions_UbicacionId",
                table: "PropiedadAgricola",
                column: "UbicacionId",
                principalTable: "Ubicacions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedoresPorPropiedadAgricolas_PropiedadAgricola_PropiedadAgricolaId",
                table: "ProveedoresPorPropiedadAgricolas",
                column: "PropiedadAgricolaId",
                principalTable: "PropiedadAgricola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedoresPorPropiedadAgricolas_Proveedores_ProveedorId",
                table: "ProveedoresPorPropiedadAgricolas",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trabajadores_PropiedadAgricola_PropiedadAgricolaId",
                table: "Trabajadores",
                column: "PropiedadAgricolaId",
                principalTable: "PropiedadAgricola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CultivosPorParcelas_Cultivos_CultivoId",
                table: "CultivosPorParcelas");

            migrationBuilder.DropForeignKey(
                name: "FK_CultivosPorParcelas_Parcelas_ParcelaId",
                table: "CultivosPorParcelas");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcelas_PropiedadAgricola_PropiedadAgricolaId",
                table: "Parcelas");

            migrationBuilder.DropForeignKey(
                name: "FK_PropiedadAgricola_Propietarios_PropietarioId",
                table: "PropiedadAgricola");

            migrationBuilder.DropForeignKey(
                name: "FK_PropiedadAgricola_Ubicacions_UbicacionId",
                table: "PropiedadAgricola");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedoresPorPropiedadAgricolas_PropiedadAgricola_PropiedadAgricolaId",
                table: "ProveedoresPorPropiedadAgricolas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProveedoresPorPropiedadAgricolas_Proveedores_ProveedorId",
                table: "ProveedoresPorPropiedadAgricolas");

            migrationBuilder.DropForeignKey(
                name: "FK_Trabajadores_PropiedadAgricola_PropiedadAgricolaId",
                table: "Trabajadores");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ubicacions",
                table: "Ubicacions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trabajadores",
                table: "Trabajadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProveedoresPorPropiedadAgricolas",
                table: "ProveedoresPorPropiedadAgricolas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Propietarios",
                table: "Propietarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropiedadAgricola",
                table: "PropiedadAgricola");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parcelas",
                table: "Parcelas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CultivosPorParcelas",
                table: "CultivosPorParcelas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cultivos",
                table: "Cultivos");

            migrationBuilder.RenameTable(
                name: "Ubicacions",
                newName: "Ubicacion");

            migrationBuilder.RenameTable(
                name: "Trabajadores",
                newName: "Trabajador");

            migrationBuilder.RenameTable(
                name: "ProveedoresPorPropiedadAgricolas",
                newName: "ProveedorPorPropiedadAgricola");

            migrationBuilder.RenameTable(
                name: "Proveedores",
                newName: "Proveedor");

            migrationBuilder.RenameTable(
                name: "Propietarios",
                newName: "Propietario");

            migrationBuilder.RenameTable(
                name: "PropiedadAgricola",
                newName: "PropiedadesAgricolas");

            migrationBuilder.RenameTable(
                name: "Parcelas",
                newName: "Parcela");

            migrationBuilder.RenameTable(
                name: "CultivosPorParcelas",
                newName: "CultivoPorParcela");

            migrationBuilder.RenameTable(
                name: "Cultivos",
                newName: "Cultivo");

            migrationBuilder.RenameIndex(
                name: "IX_Trabajadores_PropiedadAgricolaId",
                table: "Trabajador",
                newName: "IX_Trabajador_PropiedadAgricolaId");

            migrationBuilder.RenameIndex(
                name: "IX_ProveedoresPorPropiedadAgricolas_ProveedorId",
                table: "ProveedorPorPropiedadAgricola",
                newName: "IX_ProveedorPorPropiedadAgricola_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProveedoresPorPropiedadAgricolas_PropiedadAgricolaId",
                table: "ProveedorPorPropiedadAgricola",
                newName: "IX_ProveedorPorPropiedadAgricola_PropiedadAgricolaId");

            migrationBuilder.RenameIndex(
                name: "IX_PropiedadAgricola_UbicacionId",
                table: "PropiedadesAgricolas",
                newName: "IX_PropiedadesAgricolas_UbicacionId");

            migrationBuilder.RenameIndex(
                name: "IX_PropiedadAgricola_PropietarioId",
                table: "PropiedadesAgricolas",
                newName: "IX_PropiedadesAgricolas_PropietarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Parcelas_PropiedadAgricolaId",
                table: "Parcela",
                newName: "IX_Parcela_PropiedadAgricolaId");

            migrationBuilder.RenameIndex(
                name: "IX_CultivosPorParcelas_ParcelaId",
                table: "CultivoPorParcela",
                newName: "IX_CultivoPorParcela_ParcelaId");

            migrationBuilder.RenameIndex(
                name: "IX_CultivosPorParcelas_CultivoId",
                table: "CultivoPorParcela",
                newName: "IX_CultivoPorParcela_CultivoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ubicacion",
                table: "Ubicacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trabajador",
                table: "Trabajador",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProveedorPorPropiedadAgricola",
                table: "ProveedorPorPropiedadAgricola",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Propietario",
                table: "Propietario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropiedadesAgricolas",
                table: "PropiedadesAgricolas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parcela",
                table: "Parcela",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CultivoPorParcela",
                table: "CultivoPorParcela",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cultivo",
                table: "Cultivo",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RolGlobal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimoAcceso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPorPropiedadAgricola",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropiedadAgricolaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PuedeEditar = table.Column<bool>(type: "bit", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPorPropiedadAgricola", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioPorPropiedadAgricola_PropiedadesAgricolas_PropiedadAgricolaId",
                        column: x => x.PropiedadAgricolaId,
                        principalTable: "PropiedadesAgricolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPorPropiedadAgricola_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPorPropiedadAgricola_PropiedadAgricolaId",
                table: "UsuarioPorPropiedadAgricola",
                column: "PropiedadAgricolaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPorPropiedadAgricola_UsuarioId",
                table: "UsuarioPorPropiedadAgricola",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_CultivoPorParcela_Cultivo_CultivoId",
                table: "CultivoPorParcela",
                column: "CultivoId",
                principalTable: "Cultivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CultivoPorParcela_Parcela_ParcelaId",
                table: "CultivoPorParcela",
                column: "ParcelaId",
                principalTable: "Parcela",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parcela_PropiedadesAgricolas_PropiedadAgricolaId",
                table: "Parcela",
                column: "PropiedadAgricolaId",
                principalTable: "PropiedadesAgricolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropiedadesAgricolas_Propietario_PropietarioId",
                table: "PropiedadesAgricolas",
                column: "PropietarioId",
                principalTable: "Propietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropiedadesAgricolas_Ubicacion_UbicacionId",
                table: "PropiedadesAgricolas",
                column: "UbicacionId",
                principalTable: "Ubicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorPorPropiedadAgricola_PropiedadesAgricolas_PropiedadAgricolaId",
                table: "ProveedorPorPropiedadAgricola",
                column: "PropiedadAgricolaId",
                principalTable: "PropiedadesAgricolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProveedorPorPropiedadAgricola_Proveedor_ProveedorId",
                table: "ProveedorPorPropiedadAgricola",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trabajador_PropiedadesAgricolas_PropiedadAgricolaId",
                table: "Trabajador",
                column: "PropiedadAgricolaId",
                principalTable: "PropiedadesAgricolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

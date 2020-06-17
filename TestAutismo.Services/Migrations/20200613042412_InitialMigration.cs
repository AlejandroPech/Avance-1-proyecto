using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestAutismo.Services.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentroEducativos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Update = table.Column<DateTime>(nullable: true),
                    NombreCentro = table.Column<string>(nullable: true),
                    DireccionCentro = table.Column<string>(nullable: true),
                    ClaveCentro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroEducativos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Update = table.Column<DateTime>(nullable: true),
                    CorreoElectronico = table.Column<string>(nullable: true),
                    Contraseña = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plantillas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Update = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantillas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Update = table.Column<DateTime>(nullable: true),
                    NombreTutor = table.Column<string>(nullable: false),
                    ApellidosTutor = table.Column<string>(nullable: false),
                    CurpTutor = table.Column<string>(nullable: true),
                    FechaNacimientoT = table.Column<DateTime>(nullable: false),
                    DireccionT = table.Column<string>(nullable: true),
                    CuentaId = table.Column<int>(nullable: false),
                    NacionalidadT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tutores_Cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Update = table.Column<DateTime>(nullable: true),
                    Tipo = table.Column<bool>(nullable: false),
                    PreguntaRealizada = table.Column<string>(nullable: true),
                    PlantillaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preguntas_Plantillas_PlantillaId",
                        column: x => x.PlantillaId,
                        principalTable: "Plantillas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ninios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Update = table.Column<DateTime>(nullable: true),
                    NombreNinio = table.Column<string>(nullable: false),
                    ApellidosNinio = table.Column<string>(nullable: false),
                    CurpNinio = table.Column<string>(nullable: true),
                    Nacionalidad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    FechaNacimientoN = table.Column<DateTime>(nullable: false),
                    Fotografia = table.Column<string>(nullable: true),
                    TutorId = table.Column<int>(nullable: false),
                    CentroEducativoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ninios_CentroEducativos_CentroEducativoId",
                        column: x => x.CentroEducativoId,
                        principalTable: "CentroEducativos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ninios_Tutores_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Update = table.Column<DateTime>(nullable: true),
                    ValorRespuesta = table.Column<bool>(nullable: true),
                    PreguntaId = table.Column<int>(nullable: false),
                    NinioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuestas_Ninios_NinioId",
                        column: x => x.NinioId,
                        principalTable: "Ninios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respuestas_Preguntas_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Preguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ninios_CentroEducativoId",
                table: "Ninios",
                column: "CentroEducativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ninios_TutorId",
                table: "Ninios",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_PlantillaId",
                table: "Preguntas",
                column: "PlantillaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_NinioId",
                table: "Respuestas",
                column: "NinioId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_PreguntaId",
                table: "Respuestas",
                column: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tutores_CuentaId",
                table: "Tutores",
                column: "CuentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Ninios");

            migrationBuilder.DropTable(
                name: "Preguntas");

            migrationBuilder.DropTable(
                name: "CentroEducativos");

            migrationBuilder.DropTable(
                name: "Tutores");

            migrationBuilder.DropTable(
                name: "Plantillas");

            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}

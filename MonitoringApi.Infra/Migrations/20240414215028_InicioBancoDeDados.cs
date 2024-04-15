using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MonitoringApi.Infra.Migrations
{
    public partial class InicioBancoDeDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SetorEquipamentoId = table.Column<int>(type: "integer", nullable: true),
                    Codigo = table.Column<string>(type: "text", nullable: true),
                    ValorEsperado = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetorEquipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetorEquipamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SensorId = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicao_Sensores_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicao_SensorId",
                table: "Medicao",
                column: "SensorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicao");

            migrationBuilder.DropTable(
                name: "SetorEquipamentos");

            migrationBuilder.DropTable(
                name: "Sensores");
        }
    }
}

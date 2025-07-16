using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgenda.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBContato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compromisso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeOcorrencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraDeInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraDeTermino = table.Column<TimeSpan>(type: "time", nullable: false),
                    TipoCompromisso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContatoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compromisso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compromisso_contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compromisso_ContatoId",
                table: "Compromisso",
                column: "ContatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compromisso");

            migrationBuilder.DropTable(
                name: "contatos");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgenda.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compromisso_contatos_ContatoId",
                table: "Compromisso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compromisso",
                table: "Compromisso");

            migrationBuilder.RenameTable(
                name: "Despesas",
                newName: "despesas");

            migrationBuilder.RenameTable(
                name: "Compromisso",
                newName: "compromissos");

            migrationBuilder.RenameIndex(
                name: "IX_Compromisso_ContatoId",
                table: "compromissos",
                newName: "IX_compromissos_ContatoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_despesas",
                table: "despesas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_compromissos",
                table: "compromissos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Concluida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaDespesa",
                columns: table => new
                {
                    CategoriasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DespesasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaDespesa", x => new { x.CategoriasId, x.DespesasId });
                    table.ForeignKey(
                        name: "FK_CategoriaDespesa_categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaDespesa_despesas_DespesasId",
                        column: x => x.DespesasId,
                        principalTable: "despesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensTarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Concluido = table.Column<bool>(type: "bit", nullable: false),
                    TarefaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensTarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensTarefa_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaDespesa_DespesasId",
                table: "CategoriaDespesa",
                column: "DespesasId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensTarefa_TarefaId",
                table: "ItensTarefa",
                column: "TarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_compromissos_contatos_ContatoId",
                table: "compromissos",
                column: "ContatoId",
                principalTable: "contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compromissos_contatos_ContatoId",
                table: "compromissos");

            migrationBuilder.DropTable(
                name: "CategoriaDespesa");

            migrationBuilder.DropTable(
                name: "ItensTarefa");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_despesas",
                table: "despesas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_compromissos",
                table: "compromissos");

            migrationBuilder.RenameTable(
                name: "despesas",
                newName: "Despesas");

            migrationBuilder.RenameTable(
                name: "compromissos",
                newName: "Compromisso");

            migrationBuilder.RenameIndex(
                name: "IX_compromissos_ContatoId",
                table: "Compromisso",
                newName: "IX_Compromisso_ContatoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compromisso",
                table: "Compromisso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compromisso_contatos_ContatoId",
                table: "Compromisso",
                column: "ContatoId",
                principalTable: "contatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

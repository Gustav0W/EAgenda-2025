using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgenda.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
               name: "TarefaId",
               table: "ItensTarefa",
               type: "uniqueidentifier",
               nullable: false,
               defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_ItensTarefa_TarefaId",
                table: "ItensTarefa",
                column: "TarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensTarefa_Tarefas_TarefaId",
                table: "ItensTarefa",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_ItensTarefa_Tarefas_TarefaId",
               table: "ItensTarefa");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropIndex(
                name: "IX_ItensTarefa_TarefaId",
                table: "ItensTarefa");

            migrationBuilder.DropColumn(
                name: "TarefaId",
                table: "ItensTarefa");
        }
    }
}

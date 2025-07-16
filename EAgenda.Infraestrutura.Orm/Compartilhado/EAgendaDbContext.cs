using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloCompromisso;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Dominio.ModuloDespesa;
using EAgenda.Dominio.ModuloTarefa;
using EAgenda.Infraestrutura.Orm.ModuloContato;
using Microsoft.EntityFrameworkCore;

namespace EAgenda.Infraestrutura.Orm.Compartilhado;

public class EAgendaDbContext : DbContext
{
    public DbSet<Contato> contatos { get; set; }
    public DbSet<Compromisso> compromissos { get; set; }
    public DbSet<Categoria> categorias {  get; set; }
    public DbSet<Despesa> despesas { get; set; }
    public DbSet<ItemTarefa> ItensTarefa { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public EAgendaDbContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MapeadorContatoEmOrm());

        base.OnModelCreating(modelBuilder);
    }
}

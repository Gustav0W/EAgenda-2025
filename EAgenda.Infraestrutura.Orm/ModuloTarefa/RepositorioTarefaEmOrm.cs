using EAgenda.Dominio.ModuloTarefa;
using EAgenda.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace EAgenda.Infraestrutura.Orm.ModuloTarefa;

    public class RepositorioTarefaEmOrm : RepositorioBaseEmOrm<Tarefa>, IRepositorioTarefa
    {
        private readonly DbSet<Tarefa> tarefas;
        private readonly DbSet<ItemTarefa> itensTarefa;
        public RepositorioTarefaEmOrm(EAgendaDbContext contexto) : base(contexto)
        {
            tarefas = contexto.Tarefas;
            itensTarefa = contexto.ItensTarefa;
        }

        public void AdicionarItem(ItemTarefa item)
        {
            itensTarefa.Add(item);
        }

        public bool AtualizarItem(ItemTarefa itemAtualizado)
        {
            throw new NotImplementedException();
        }

        public bool RemoverItem(ItemTarefa item)
        {
            if (item == null)
                return false;
            else
            {
                itensTarefa.Remove(item);
                return true;
            }
        }

        public List<Tarefa> SelecionarTarefasConcluidas()
        {
            return tarefas
                .Where(x => x.Concluida)
                .ToList();
        }

        public List<Tarefa> SelecionarTarefasPendentes()
        {
            return tarefas
                .Where(x => !x.Concluida)
                .ToList();
        }

        public override Tarefa? SelecionarRegistroPorId(Guid idRegistro)
        {
            return tarefas
                .Include(t => t.Itens)
                .FirstOrDefault(x => x.Id.Equals(idRegistro));

        }
    }
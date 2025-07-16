using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Infraestrutura.Orm.Compartilhado;

namespace EAgenda.Infraestrutura.Orm.ModuloCategoria;

public class RepositorioCategoriaEmOrm : IRepositorioCategoria
{
    public readonly EAgendaDbContext contexto;

    public RepositorioCategoriaEmOrm(EAgendaDbContext contexto) 
    {
        this.contexto = contexto;
    }

    public void CadastrarRegistro(Categoria novoRegistro)
    {
        throw new NotImplementedException();
    }

    public bool EditarRegistro(Guid idRegistro, Categoria registroEditado)
    {
        throw new NotImplementedException();
    }

    public bool ExcluirRegistro(Guid idRegistro)
    {
        throw new NotImplementedException();
    }

    public Categoria SelecionarRegistroPorId(Guid idRegistro)
    {
        throw new NotImplementedException();
    }

    public List<Categoria> SelecionarRegistros()
    {
        throw new NotImplementedException();
    }
}

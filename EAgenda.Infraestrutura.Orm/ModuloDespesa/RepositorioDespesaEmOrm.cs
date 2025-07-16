using EAgenda.Dominio.ModuloDespesa;
using EAgenda.Infraestrutura.Orm.Compartilhado;

namespace EAgenda.Infraestrutura.Orm.ModuloDespesa;

public class RepositorioDespesaEmOrm
{
    public readonly EAgendaDbContext contexto;

    public RepositorioDespesaEmOrm(EAgendaDbContext contexto)
    {
        this.contexto = contexto;
    }

    public void CadastrarRegistro(Despesa novoRegistro)
    {
        contexto.despesas.Add(novoRegistro);
    }

    public bool EditarRegistro(Guid idRegistro, Despesa registroEditado)
    {
        var registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado is null)
            return false;

        registroSelecionado.AtualizarRegistro(registroEditado);

        return true;
    }

    public bool ExcluirRegistro(Guid idRegistro)
    {
        var registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado is null)
            return false;

        contexto.despesas.Remove(registroSelecionado);

        return true;
    }

    public Despesa SelecionarRegistroPorId(Guid idRegistro)
    {
        return contexto.despesa.FirstOrDefault(x => x.Id.Equals(idRegistro))!;
    }

    public List<Despesa> SelecionarRegistros()
    {
        return contexto.despesas.ToList();
    }
}

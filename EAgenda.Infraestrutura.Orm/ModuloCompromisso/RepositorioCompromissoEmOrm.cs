using EAgenda.Dominio.ModuloCompromisso;
using EAgenda.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace EAgenda.Infraestrutura.Orm.ModuloCompromisso;

public class RepositorioCompromissoEmOrm : RepositorioBaseEmOrm<Compromisso>, IRepositorioCompromisso
{
    public RepositorioCompromissoEmOrm(EAgendaDbContext contexto) : base(contexto)
    {

    }

    public override Compromisso? SelecionarRegistroPorId(Guid idRegistro)
    {
        return registros
            .Include(x => x.Contato)
            .FirstOrDefault(x => x.Id.Equals(idRegistro));
    }
}

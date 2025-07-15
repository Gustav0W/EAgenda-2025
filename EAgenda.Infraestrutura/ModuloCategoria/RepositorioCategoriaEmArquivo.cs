using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Infraestrutura.Compartilhado;

namespace EAgenda.Infraestrutura.ModuloCategoria;

public class RepositorioCategoriaEmArquivo : RepositorioBaseEmArquivo<Categoria>, IRepositorioCategoria
{
    public RepositorioCategoriaEmArquivo(ContextoDados contexto) : base(contexto)
    {
    }
    protected override List<Categoria> ObterRegistros()
    {
        return contexto.Categorias;
    }
}
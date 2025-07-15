using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloDespesa;
using EAgenda.WebApp.Models;

namespace EAgenda.WebApp.Extensions;

public static class CategoriaExtensions
{
    public static Categoria ParaEntidade(this FormularioCategoriaViewModel formularioVM)
    {
        return new Categoria(formularioVM.Titulo);
    }
    public static DetalhesCategoriaViewModel ParaDetalhesVM(this Categoria categoria)
    {

        return new DetalhesCategoriaViewModel(
                categoria.Id,
                categoria.Titulo,
                categoria.Despesas
        );
    }
}


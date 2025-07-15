using EAgenda.Dominio.ModuloDespesa;
using EAgenda.WebApp.Models;

namespace EAgenda.WebApp.Extensions;

public static class DespesaExtensions
{
    public static Despesa ParaEntidade(this FormularioDespesaViewModel formularioVM)
    {
        return new Despesa(
            formularioVM.Descricao,
            formularioVM.Valor,
            formularioVM.DataOcorrencia,
            formularioVM.FormaPagamento
        );
    }

    public static DetalhesDespesaViewModel ParaDetalhesVM(this Despesa despesa)
    {
        return new DetalhesDespesaViewModel(
                despesa.Id,
                despesa.Descricao,
                despesa.Valor,
                despesa.DataOcorrencia,
                despesa.FormaPagamento,
                despesa.Categorias
        );
    }
}

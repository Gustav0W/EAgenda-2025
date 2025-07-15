using EAgenda.Dominio.ModuloCompromisso;
using EAgenda.Dominio.ModuloContato;
using EAgenda.WebApp.Models;

namespace EAgenda.WebApp.Extensions;
public static class CompromissoExtensions
{
    public static Compromisso ParaEntidade(this FormularioCompromissoViewModel formularioVM, List<Contato> contatosDisponiveis)
    {
        var contato = contatosDisponiveis.FirstOrDefault(c => c.Id == formularioVM.Contato);

        return new Compromisso(formularioVM.Assunto, formularioVM.DataDeOcorrencia, formularioVM.HoraDeInicio, formularioVM.HoraDeTermino, formularioVM.TipoCompromisso,
            formularioVM.Local, formularioVM.Link, contato);
    }

    public static DetalhesCompromissoViewModel ParaDetalhesVM(this Compromisso compromisso)
    {
        return new DetalhesCompromissoViewModel
        {
            Id = compromisso.Id,
            Assunto = compromisso.Assunto,
            DataDeOcorrencia = compromisso.DataDeOcorrencia,
            HoraDeInicio = compromisso.HoraDeInicio,
            HoraDeTermino = compromisso.HoraDeTermino,
            TipoCompromisso = compromisso.TipoCompromisso,
            Local = compromisso.Local,
            Link = compromisso.Link,
            NomeContato = compromisso.Contato?.Nome
        };
    }
}


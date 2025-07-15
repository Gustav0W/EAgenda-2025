using EAgenda.WebApp.Models;
using EAgenda.Dominio.ModuloContato;

namespace EAgenda.WebApp.Extensions;

public static class ContatoExtensions
{
    public static Contato ParaEntidade(this FormularioContatoViewModel formularioVM)
    {
        return new Contato(formularioVM.Nome, formularioVM.Email, formularioVM.Telefone, formularioVM.Empresa, formularioVM.Cargo);
    }
    public static DetalhesContatoViewModel ParaDetalhesVM(this Contato contato)
    {
        return new DetalhesContatoViewModel
        {
            Id = contato.Id,
            Nome = contato.Nome,
            Email = contato.Email,
            Telefone = contato.Telefone,
            Empresa = contato.Empresa,
            Cargo = contato.Cargo,
        };
    }
}

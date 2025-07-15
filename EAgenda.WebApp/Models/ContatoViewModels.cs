using EAgenda.Dominio.ModuloContato;
using EAgenda.WebApp.Extensions;
using System.ComponentModel.DataAnnotations;

namespace EAgenda.WebApp.Models;

public class FormularioContatoViewModel
{
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    [MinLength(3, ErrorMessage = "O campo \"Nome\" deve ter no mínimo 3 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Nome\" deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo \"Email\" é obrigatório.")]
    [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo \"Telefone\" é obrigatório.")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Informe um telefone válido.")]
    public string Telefone { get; set; }
    public string? Cargo { get; set; }
    public string? Empresa { get; set; }
}

public class CadastrarContatoViewModel : FormularioContatoViewModel
{
    public CadastrarContatoViewModel() { }

    public CadastrarContatoViewModel(string nome, string email, string telefone, string cargo, string empresa) : this()
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Cargo = cargo;
        Empresa = empresa;
    }
}

public class EditarContatoViewModel : FormularioContatoViewModel
{
    [Required(ErrorMessage = "O campo \"Id\" é obrigatório.")]
    public Guid Id { get; set; }
    public EditarContatoViewModel() { }
    public EditarContatoViewModel(Guid id, string nome, string email, string telefone, string cargo, string empresa)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Cargo = cargo;
        Empresa = empresa;
    }
}

public class ExcluirContatoViewModel
{
    [Required(ErrorMessage = "O campo \"Id\" é obrigatório.")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    public string Nome { get; set; }
    public ExcluirContatoViewModel() { }
    public ExcluirContatoViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarContatoViewModel
{
    public List<DetalhesContatoViewModel> Registros { get; set; }

    public VisualizarContatoViewModel(List<Contato> contatos)
    {
        Registros = new List<DetalhesContatoViewModel>();

        foreach (var contato in contatos)
        {
            Registros.Add(contato.ParaDetalhesVM());
        }
    }
}

public class DetalhesContatoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cargo { get; set; }
    public string Empresa { get; set; }
    public List<string> Compromissos { get; set; } = new List<string>();

    public DetalhesContatoViewModel() { }

    public DetalhesContatoViewModel(Guid id, string nome, string email, string telefone, string cargo, string empresa)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Cargo = cargo;
        Empresa = empresa;
    }
    public DetalhesContatoViewModel(Guid id, string nome, string email, string telefone, string cargo, string empresa, List<string> compromissos)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Cargo = cargo;
        Empresa = empresa;
        Compromissos = compromissos ?? new List<string>();
    }
}

public class SelecionarContatoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public SelecionarContatoViewModel() { }
    public SelecionarContatoViewModel(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

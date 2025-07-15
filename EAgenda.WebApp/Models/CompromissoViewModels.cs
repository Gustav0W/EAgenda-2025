using EAgenda.Dominio.ModuloCompromisso;
using EAgenda.Dominio.ModuloContato;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EAgenda.WebApp.Models;

public class FormularioCompromissoViewModel
{
    [Required(ErrorMessage = "O campo \"Assunto\" é obrigatório.")]
    [MinLength(2, ErrorMessage = "O campo \"Assunto\" deve ter no mínimo 2 caracteres.")]
    [MaxLength(100, ErrorMessage = "O campo \"Assunto\" deve ter no máximo 100 caracteres.")]
    public string Assunto { get; set; }

    [Required(ErrorMessage = "O campo \"Data de Ocorrência\" é obrigatório.")]
    public DateTime DataDeOcorrencia { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "O campo \"Hora de Início\" é obrigatório.")]
    [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]

    public TimeSpan HoraDeInicio { get; set; }

    [Required(ErrorMessage = "O campo \"Hora de Término\" é obrigatório.")]
    [DisplayFormat(DataFormatString = @"{0:hh\:mm}", ApplyFormatInEditMode = true)]

    public TimeSpan HoraDeTermino { get; set; }

    [Required(ErrorMessage = "O campo \"Tipo de Compromisso\" é obrigatório.")]
    public string TipoCompromisso { get; set; }
    public string? Local { get; set; }
    public string? Link { get; set; }
    public List<SelectListItem>? ContatosDisponiveis { get; set; }
    public Guid? Contato { get; set; }
}

public class CadastrarCompromissoViewModel : FormularioCompromissoViewModel
{
    public CadastrarCompromissoViewModel()
    {
        ContatosDisponiveis = new List<SelectListItem>();
    }

    public CadastrarCompromissoViewModel(List<Contato> contatos) : this()
    {
        foreach (var contato in contatos)
        {
            ContatosDisponiveis.Add(new SelectListItem
            {
                Value = contato.Id.ToString(),
                Text = contato.Nome
            });
        }
    }
    public CadastrarCompromissoViewModel(string assunto, DateTime dataDeOcorrencia, TimeSpan horaDeInicio, TimeSpan horaDeTermino, string tipoCompromisso, string? local, string? link, Guid? contato)
    {
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoCompromisso = tipoCompromisso;
        Local = local;
        Link = link;
        Contato = contato;
        ContatosDisponiveis = new List<SelectListItem>();
    }
}

public class EditarCompromissoViewModel : FormularioCompromissoViewModel
{
    [Required(ErrorMessage = "O campo \"Id\" é obrigatório.")]
    public Guid Id { get; set; }

    public EditarCompromissoViewModel() { }

    public EditarCompromissoViewModel(Guid id, string assunto, DateTime dataDeOcorrencia, TimeSpan horaDeInicio, TimeSpan horaDeTermino, string tipoCompromisso, string? local, string? link, Guid? contato)
    {
        Id = id;
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoCompromisso = tipoCompromisso;
        Local = local;
        Link = link;
        Contato = contato;
    }
}

public class ExcluirCompromissoViewModel
{
    [Required(ErrorMessage = "O campo \"Id\" é obrigatório.")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "O campo \"Assunto\" é obrigatório.")]
    public string Assunto { get; set; }

    public ExcluirCompromissoViewModel() { }

    public ExcluirCompromissoViewModel(Guid id, string assunto)
    {
        Id = id;
        Assunto = assunto;
    }
}

public class VisualizarCompromissoViewModel
{
    public List<DetalhesCompromissoViewModel> Registros { get; set; }

    public VisualizarCompromissoViewModel(List<Compromisso> compromissos)
    {
        Registros = new List<DetalhesCompromissoViewModel>();

        foreach (var compromisso in compromissos)
        {
            Registros.Add(compromisso.ParaDetalhesVM());
        }
    }
}


public class DetalhesCompromissoViewModel
{
    public Guid Id { get; set; }
    public string Assunto { get; set; }
    public DateTime DataDeOcorrencia { get; set; }
    public TimeSpan HoraDeInicio { get; set; }
    public TimeSpan HoraDeTermino { get; set; }
    public string TipoCompromisso { get; set; }
    public string? Local { get; set; }
    public string? Link { get; set; }
    public string? NomeContato { get; set; }

    public DetalhesCompromissoViewModel() { }

    public DetalhesCompromissoViewModel(Guid id, string assunto, DateTime dataDeOcorrencia, TimeSpan horaDeInicio, TimeSpan horaDeTermino, string tipoCompromisso, string? local, string? link, string? nomeContato)
    {
        Id = id;
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoCompromisso = tipoCompromisso;
        Local = local;
        Link = link;
        NomeContato = nomeContato;
    }

    public DetalhesCompromissoViewModel(Guid id, string assunto, DateTime dataDeOcorrencia, TimeSpan horaDeInicio, TimeSpan horaDeTermino, string tipoCompromisso, string? local, string? link)
    {
        Id = id;
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoCompromisso = tipoCompromisso;
        Local = local;
        Link = link;
    }
}

public class SelecionarCompromissoViewModel
{
    public Guid Id { get; set; }
    public string Assunto { get; set; }
    public SelecionarCompromissoViewModel() { }
    public SelecionarCompromissoViewModel(Guid id, string assunto)
    {
        Id = id;
        Assunto = assunto;
    }
}

using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.ModuloContato;

namespace EAgenda.Dominio.ModuloCompromisso;

public class Compromisso : EntidadeBase<Compromisso>
{
    public string Assunto { get; set; }
    public DateTime DataDeOcorrencia { get; set; }
    public TimeSpan HoraDeInicio { get; set; }
    public TimeSpan HoraDeTermino { get; set; }
    public string TipoCompromisso { get; set; }
    public string Local { get; set; }
    public string Link { get; set; }
    public Contato Contato { get; set; }

    public Compromisso()
    {
    }

    public Compromisso(string assunto, DateTime dataDeOcorrencia, TimeSpan horaDeInicio, TimeSpan horaDeTermino, string tipoCompromisso, string local, string link, Contato contato) : this()
    {
        Id = Guid.NewGuid();
        Assunto = assunto;
        DataDeOcorrencia = dataDeOcorrencia;
        HoraDeInicio = horaDeInicio;
        HoraDeTermino = horaDeTermino;
        TipoCompromisso = tipoCompromisso;
        Local = local;
        Link = link;
        Contato = contato;
    }
    public override void AtualizarRegistro(Compromisso registroEditado)
    {
        Assunto = registroEditado.Assunto;
        DataDeOcorrencia = registroEditado.DataDeOcorrencia;
        HoraDeInicio = registroEditado.HoraDeInicio;
        HoraDeTermino = registroEditado.HoraDeTermino;
        TipoCompromisso = registroEditado.TipoCompromisso;
        Local = registroEditado.Local;
        Link = registroEditado.Link;
        Contato = registroEditado.Contato;
    }
}

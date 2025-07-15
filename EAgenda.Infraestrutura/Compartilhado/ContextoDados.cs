using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloCompromisso;
using EAgenda.Dominio.ModuloContato;
using EAgenda.Dominio.ModuloDespesa;
using EAgenda.Dominio.ModuloTarefa;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EAgenda.Infraestrutura.Compartilhado;

public class ContextoDados
{
    private string pastaArmazenamento = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eAgenda");
    private string arquivoArmazenamento = "dados-e-agenda.json";

    public List<Contato> Contatos { get; set; }
    public List<Compromisso> Compromissos { get; set; }
    public List<Categoria> Categorias { get; set; }
    public List<Despesa> Despesas { get; set; }
    public List<Tarefa> Tarefas { get; set; }
    public ContextoDados()
    {
        Contatos = new List<Contato>();
        Compromissos = new List<Compromisso>();
        Categorias = new List<Categoria>();
        Despesas = new List<Despesa>();
        Tarefas = new List<Tarefa>();
    }

    public ContextoDados(bool carregarDados) : this()
    {
        if (carregarDados)
            Carregar();
    }

    public void Salvar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.WriteIndented = true;
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        string json = JsonSerializer.Serialize(this, jsonOptions);

        if (!Directory.Exists(pastaArmazenamento))
            Directory.CreateDirectory(pastaArmazenamento);

        File.WriteAllText(caminhoCompleto, json);
    }

    public void Carregar()
    {
        string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

        if (!File.Exists(caminhoCompleto)) return;

        string json = File.ReadAllText(caminhoCompleto);

        if (string.IsNullOrWhiteSpace(json)) return;

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(
            json,
            jsonOptions
        )!;

        if (contextoArmazenado == null) return;

        Contatos = contextoArmazenado.Contatos;
        Compromissos = contextoArmazenado.Compromissos;
        Categorias = contextoArmazenado.Categorias;
        Despesas = contextoArmazenado.Despesas;
        Tarefas = contextoArmazenado.Tarefas;
    }
}

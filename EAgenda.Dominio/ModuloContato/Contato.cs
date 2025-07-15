using EAgenda.Dominio.Compartilhado;
using EAgenda.Dominio.ModuloCompromisso;

namespace EAgenda.Dominio.ModuloContato
{
    public class Contato : EntidadeBase<Contato>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string? Empresa { get; set; }
        public string? Cargo { get; set; }
        public List<Compromisso> Compromissos { get; set; }
        public Contato()
        {
        }
        public Contato(string nome, string email, string telefone, string empresa, string cargo) : this()
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
            Compromissos = new List<Compromisso>();
        }

        public override void AtualizarRegistro(Contato registroEditado)
        {
            Nome = registroEditado.Nome;
            Email = registroEditado.Email;
            Telefone = registroEditado.Telefone;
            Empresa = registroEditado.Empresa;
            Cargo = registroEditado.Cargo;
        }
    }
}

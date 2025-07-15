using EAgenda.Dominio.ModuloContato;
using EAgenda.Dominio.ModuloCompromisso;
using EAgenda.WebApp.Models;
using EAgenda.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;
using EAgenda.Infraestrutura.Orm.Compartilhado;

namespace EAgenda.WebApp.Controllers;

[Route("contatos")]
public class ContatoController : Controller
{
    private readonly EAgendaDbContext contexto;
    private readonly IRepositorioContato repositorioContato;
    private readonly IRepositorioCompromisso repositorioCompromisso;

    public ContatoController(EAgendaDbContext contexto, IRepositorioContato repositorioContato)
    {
        this.contexto = contexto;
        this.repositorioContato = repositorioContato;
    }

    public IActionResult Index()
    {
        var registros = repositorioContato.SelecionarRegistros();

        var visualizarVM = new VisualizarContatoViewModel(registros);

        return View(visualizarVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarContatoViewModel();

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarContatoViewModel cadastrarVM)
    {
        var registros = repositorioContato.SelecionarRegistros();

        foreach (var item in registros)
        {
            if (item.Email.Equals(cadastrarVM.Email))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe um contato com esse email registrado.");
                break;
            }

            if (item.Telefone.Equals(cadastrarVM.Telefone))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe um contato com esse telefone registrado");
                break;
            }
        }

        if (!ModelState.IsValid)
            return View(cadastrarVM);

        var entidade = cadastrarVM.ParaEntidade();

        var transacao = contexto.Database.BeginTransaction();
        try
        {
            repositorioContato.CadastrarRegistro(entidade);

            contexto.SaveChanges();
            transacao.Commit();
        }
        catch (Exception)
        {
            transacao.Rollback();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public ActionResult Editar(Guid id)
    {
        var registroSelecionado = repositorioContato.SelecionarRegistroPorId(id);

        var editarVM = new EditarContatoViewModel(
                id,
                registroSelecionado.Nome,
                registroSelecionado.Email,
                registroSelecionado.Telefone,
                registroSelecionado.Cargo,
                registroSelecionado.Empresa
            );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    [ValidateAntiForgeryToken]
    public ActionResult Editar(Guid id, EditarContatoViewModel editarVM)
    {
        var registros = repositorioContato.SelecionarRegistros();

        foreach (var item in registros)
        {
            if (!item.Id.Equals(id) && item.Email.Equals(editarVM.Email))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe um contato com esse email.");
                break;
            }

            if (!item.Id.Equals(id) && item.Telefone.Equals(editarVM.Telefone))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe um contato com esse telefone");
                break;
            }
        }

        if (!ModelState.IsValid)
            return View(editarVM);

        var entidadeEditada = editarVM.ParaEntidade();

        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioContato.EditarRegistro(id, entidadeEditada);

            contexto.SaveChanges();
            transacao.Commit();
        }
        catch (Exception)
        {
            transacao.Rollback();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var registroSelecionado = repositorioContato.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirContatoViewModel(registroSelecionado.Id, registroSelecionado.Nome);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    public IActionResult ExcluirConfirmado(Guid id)
    {
        var compromissos = repositorioCompromisso.SelecionarRegistros();

        foreach (var compromisso in compromissos)
        {
            if (compromisso.Contato.Id == id)
            {
                ModelState.AddModelError("ContatoVinculado", "Não é possível excluir o contato, pois ele está vinculado a um compromisso.");
                break;
            }
        }

        if (!ModelState.IsValid)
        {
            var registroSelecionado = repositorioContato.SelecionarRegistroPorId(id);
            var excluirVM = new ExcluirContatoViewModel(registroSelecionado.Id, registroSelecionado.Nome);
            return View("Excluir", excluirVM);
        }

        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioContato.ExcluirRegistro(id);

            contexto.SaveChanges();
            transacao.Commit();
        }
        catch (Exception)
        {
            transacao.Rollback();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("detalhes/{id:guid}")]
    public IActionResult Detalhes(Guid id)
    {
        var registroSelecionado = repositorioContato.SelecionarRegistroPorId(id);

        var detalhesVM = new DetalhesContatoViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Email,
            registroSelecionado.Telefone,
            registroSelecionado.Cargo,
            registroSelecionado.Empresa
            );

        return View(detalhesVM);
    }
}

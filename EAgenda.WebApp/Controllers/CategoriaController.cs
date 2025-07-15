using EAgenda.Dominio.ModuloCategoria;
using EAgenda.WebApp.Extensions;
using EAgenda.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using EAgenda.Infraestrutura.Orm.Compartilhado;

namespace EAgenda.WebApp.Controllers;

[Route("categorias")]
public class CategoriaController : Controller
{
    private readonly EAgendaDbContext contexto;
    private readonly IRepositorioCategoria repositorioCategoria;

    public CategoriaController(EAgendaDbContext contexto, IRepositorioCategoria repositorioCategoria)
    {
        this.contexto = contexto;
        this.repositorioCategoria = repositorioCategoria;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var registros = repositorioCategoria.SelecionarRegistros();

        var visualizarVM = new VisualizarCategoriasViewModel(registros);

        return View(visualizarVM);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarCategoriaViewModel();

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(CadastrarCategoriaViewModel cadastrarVM)
    {
        var registros = repositorioCategoria.SelecionarRegistros();

        foreach (var item in registros)
        {
            if (item.Titulo.Equals(cadastrarVM.Titulo))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe uma categoria registrada com este título.");
                return View(cadastrarVM);
            }
        }

        var entidade = cadastrarVM.ParaEntidade();

        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioCategoria.CadastrarRegistro(entidade);

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
        var registroSelecionado = repositorioCategoria.SelecionarRegistroPorId(id);

        var editarVM = new EditarCategoriaViewModel(
            id,
            registroSelecionado.Titulo
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    [ValidateAntiForgeryToken]
    public ActionResult Editar(Guid id, EditarCategoriaViewModel editarVM)
    {
        var registros = repositorioCategoria.SelecionarRegistros();

        foreach (var item in registros)
        {
            if (!item.Id.Equals(id) && item.Titulo.Equals(editarVM.Titulo))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe uma categoria registrada com este título.");
                return View(editarVM);

            }
        }

        var entidadeEditada = editarVM.ParaEntidade();

        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioCategoria.EditarRegistro(id, entidadeEditada);

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
        var registroSelecionado = repositorioCategoria.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirCategoriaViewModel(registroSelecionado.Id, registroSelecionado.Titulo);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult ExcluirConfirmado(Guid id)
    {
        var transacao = contexto.Database.BeginTransaction();
        try
        {
            repositorioCategoria.ExcluirRegistro(id);

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
        var registroSelecionado = repositorioCategoria.SelecionarRegistroPorId(id);

        var detalhesVM = new DetalhesCategoriaViewModel(
            id,
            registroSelecionado.Titulo,
            registroSelecionado.Despesas
        );

        return View(detalhesVM);
    }
}

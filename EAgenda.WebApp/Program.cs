using EAgenda.Dominio.ModuloCategoria;
using EAgenda.Dominio.ModuloDespesa;
using EAgenda.Dominio.ModuloTarefa;
using EAgenda.Infraestrutura.Compartilhado;
using EAgenda.Infraestrutura.Orm.Compartilhado;
using EAgenda.Infraestrutura.Orm.ModuloContato;
using EAgenda.Dominio.ModuloCompromisso;
using EAgenda.Dominio.ModuloContato;
using EAgenda.WebApp.ActionFilters;
using EAgenda.WebApp.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using EAgenda.Infraestrutura.Orm.ModuloCompromisso;
using EAgenda.Infraestrutura.Orm.ModuloCategoria;
using EAgenda.Infraestrutura.Orm.ModuloDespesa;
using EAgenda.Infraestrutura.Orm.ModuloTarefa;

namespace EAgenda.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped(_ => new ContextoDados(true));
            builder.Services.AddScoped<IRepositorioContato, RepositorioContatoEmOrm>();
            //builder.Services.AddScoped<IRepositorioCompromisso, RepositorioCompromissoEmOrm>();
            //builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmOrm>();
            //builder.Services.AddScoped<IRepositorioDespesa, RepositorioDespesaEmOrm>();
            //builder.Services.AddScoped<IRepositorioTarefa, RepositorioTarefaEmOrm>();

            builder.Services.AddEntityFrameworkConfig(builder.Configuration);
            builder.Services.AddSerilogConfig(builder.Logging);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseAntiforgery();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}

using AccesoDatos.EF;
using Dominio.Repositorios;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServiciosDeAplicacion.Comandos;
using ServiciosDeDominio;
using ServiciosDeDominio.Interfaces;

namespace ServiciosDeAplicacion
{
    public static class ConfiguracionServiciosExtensiones
    {
        public static void ConfigurarServiciosDeAplicacion(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ListarNotasHandler));

            services.AddScoped<IActualizacionAnclajeNota, NotasService>();
            services.AddScoped<IActualizacionNota, NotasService>();
            services.AddScoped<IBusquedaNotas, NotasService>();
            services.AddScoped<ICreacionNota, NotasService>();
            services.AddScoped<IEliminacionNota, NotasService>();
            services.AddScoped<IListadoNotas, NotasService>();

            services.AddScoped<INotasRepositorio, NotasRepositorio>();
        }
    }
}

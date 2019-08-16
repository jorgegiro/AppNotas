using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using ServiciosDeAplicacion.ViewModels;
using ServiciosDeDominio.Interfaces;

namespace ServiciosDeAplicacion.Comandos
{
    public class BuscarNotasHandler : RequestHandler<BuscarNotasCommand, ListadoNotasVM>
    {
        protected  IBusquedaNotas BusquedaNotas { get; set; }

        public BuscarNotasHandler(IBusquedaNotas busquedaNotas)
        {
            if (busquedaNotas == null)
            {
                throw new ArgumentNullException(nameof(busquedaNotas));
            }

            BusquedaNotas = busquedaNotas;
        }

        protected override ListadoNotasVM Handle(BuscarNotasCommand request)
        {
            var notas = BusquedaNotas.BuscarNotas(request.UsuarioId,
                                                  request.TextoABuscar).ToList();
            
            var listadoNotasVM = new ListadoNotasVM().Map(notas);

            return listadoNotasVM;
        }
    }
}

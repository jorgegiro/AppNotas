using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using ServiciosDeAplicacion.ViewModels;
using ServiciosDeDominio.Interfaces;

namespace ServiciosDeAplicacion.Comandos
{
    public class ListarNotasHandler : RequestHandler<ListarNotasCommand, ListadoNotasVM>
    {
        protected IListadoNotas ListadoNotas { get; set; }

        public ListarNotasHandler(IListadoNotas listadoNotas)
        {
            if (listadoNotas == null)
            {
                throw new ArgumentNullException(nameof(listadoNotas));
            }

            ListadoNotas = listadoNotas;
        }

        protected override ListadoNotasVM Handle(ListarNotasCommand request)
        {
            var notas = ListadoNotas.ListarNotas(request.UsuarioId).ToList();                

            ListadoNotasVM listadoNotasVM = new ListadoNotasVM().Map(notas);

            return listadoNotasVM;
        }
    }
}

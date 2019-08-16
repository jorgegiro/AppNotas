using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ServiciosDeAplicacion.ViewModels;
using ServiciosDeDominio.Interfaces;

namespace ServiciosDeAplicacion.Comandos
{
    public class BuscarNotaParaEditarHandler : RequestHandler<BuscarNotaParaEditarCommand, NotaExistenteVM>
    {
        public IBusquedaNotas BusquedaNotas { get; set; }

        public BuscarNotaParaEditarHandler(IBusquedaNotas busquedaNotas)
        {
            if (busquedaNotas == null)
            {
                throw new ArgumentNullException(nameof(busquedaNotas));
            }

            BusquedaNotas = busquedaNotas;
        }

        protected override NotaExistenteVM Handle(BuscarNotaParaEditarCommand request)
        {
            var nota = BusquedaNotas.BuscarNota(request.Id);

            var notaExistente = new NotaExistenteVM();

            return (NotaExistenteVM)notaExistente.Map(nota);
        }
    }
}

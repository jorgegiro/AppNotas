using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using ServiciosDeDominio.Interfaces;

namespace ServiciosDeAplicacion.Comandos
{
    public class EditarNotaHandler : RequestHandler<EditarNotaCommand>
    {
        protected IActualizacionNota ActualizacionNotaService { get; set; }

        public EditarNotaHandler(IActualizacionNota actualizacionNotaService)
        {
            if (actualizacionNotaService == null)
            {
                throw new ArgumentNullException(nameof(actualizacionNotaService));
            }

            ActualizacionNotaService = actualizacionNotaService;
        }

        protected override void Handle(EditarNotaCommand request)
        {
            ActualizacionNotaService.ActualizarNota(new Nota
            {
                ID = request.Id,
                Titulo = request.Titulo,
                ContenidoHtml = request.Contenido
            });
        }
    }
}

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
    public class CrearNotaHandler : RequestHandler<CrearNotaCommand>
    {
        protected ICreacionNota CreacionNotasService { get; set; }

        public CrearNotaHandler(ICreacionNota creacionNotas)
        {
            if (creacionNotas == null)
            {
                throw new ArgumentNullException(nameof(creacionNotas));
            }

            CreacionNotasService = creacionNotas;
        }

        protected override void Handle(CrearNotaCommand request)
        {
            CreacionNotasService.CrearNota(request.UsuarioId, request.Titulo, request.Contenido);
        }
    }
}

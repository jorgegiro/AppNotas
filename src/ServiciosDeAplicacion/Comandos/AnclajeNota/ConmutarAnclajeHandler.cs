using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ServiciosDeDominio.Interfaces;

namespace ServiciosDeAplicacion.Comandos
{
    public class ConmutarAnclajeHandler : RequestHandler<ConmutarAnclajeCommand>
    {
        protected IActualizacionAnclajeNota ActualizacionAnclaje { get; set; }

        public ConmutarAnclajeHandler(IActualizacionAnclajeNota actualizacionAnclaje)
        {
            if (actualizacionAnclaje == null)
            {
                throw new ArgumentNullException(nameof(actualizacionAnclaje));
            }

            ActualizacionAnclaje = actualizacionAnclaje;
        }

        protected override void Handle(ConmutarAnclajeCommand request)
        {
            ActualizacionAnclaje.ConmutarAnclajeNota(request.Id);
        }
    }
}

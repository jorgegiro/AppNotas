using ServiciosDeDominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ServiciosDeAplicacion.Comandos
{
    public class BorrarNotaHandler : RequestHandler<BorrarNotaCommand>
    {
        protected IEliminacionNota EliminacionNotasService { get; set; }

        public BorrarNotaHandler(IEliminacionNota eliminacionNotasService)
        {
            if (eliminacionNotasService == null)
            {
                throw new ArgumentNullException(nameof(eliminacionNotasService));
            }

            EliminacionNotasService = eliminacionNotasService;
        }

        protected override void Handle(BorrarNotaCommand request)
        {
            EliminacionNotasService.EliminarNota(request.Id);
        }
    }
}

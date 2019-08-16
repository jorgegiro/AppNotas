using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ServiciosDeAplicacion.ViewModels;

namespace ServiciosDeAplicacion.Comandos
{
    public class BuscarNotaParaEditarCommand : IRequest<NotaExistenteVM>
    {
        public int Id { get; internal set; }

        public BuscarNotaParaEditarCommand(int id)
        {
            Id = id;
        }
    }
}

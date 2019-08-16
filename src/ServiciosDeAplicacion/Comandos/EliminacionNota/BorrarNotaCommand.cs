using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ServiciosDeAplicacion.Comandos
{
    public class BorrarNotaCommand : IRequest
    {
        public int Id { get; internal set; }

        public BorrarNotaCommand(int id)
        {
            Id = id;
        }
    }
}

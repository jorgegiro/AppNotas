using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ServiciosDeAplicacion.Comandos
{
    public class ConmutarAnclajeCommand : IRequest
    {
        public int Id { get; internal set; }

        public ConmutarAnclajeCommand(int id)
        {
            Id = id;
        }
    }
}

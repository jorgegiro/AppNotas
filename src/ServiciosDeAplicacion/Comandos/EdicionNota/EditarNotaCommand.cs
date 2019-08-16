using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ServiciosDeAplicacion.Comandos
{
    public class EditarNotaCommand : IRequest
    {
        public int Id { get; internal set; }
        public string Titulo { get; internal set; }
        public string Contenido { get; internal set; }

        public EditarNotaCommand(int id, string titulo, string contenido)
        {
            Id = id;
            Titulo = titulo;
            Contenido = contenido;
        }
    }
}

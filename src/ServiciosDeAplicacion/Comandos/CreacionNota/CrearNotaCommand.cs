using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ServiciosDeAplicacion.Comandos
{
    public class CrearNotaCommand : IRequest
    {
        public string Titulo { get; internal set; }
        public string Contenido { get; internal set; }
        public int UsuarioId { get; internal set; }

        public CrearNotaCommand(int usuarioId, string titulo, string contenido)
        {
            UsuarioId = usuarioId;
            Titulo = titulo;
            Contenido = contenido;
        }
    }
}

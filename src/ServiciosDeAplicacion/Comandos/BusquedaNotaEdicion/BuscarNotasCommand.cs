using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ServiciosDeAplicacion.ViewModels;

namespace ServiciosDeAplicacion.Comandos
{
    public class BuscarNotasCommand : IRequest<ListadoNotasVM>
    {
        public int UsuarioId { get; set; }
        public string TextoABuscar { get; internal set; }
        public int Pagina { get; internal set; }

        public BuscarNotasCommand(int usuarioId, string texto, int pagina)
        {
            UsuarioId = usuarioId;
            TextoABuscar = texto;
            Pagina = pagina;
        }
    }
}

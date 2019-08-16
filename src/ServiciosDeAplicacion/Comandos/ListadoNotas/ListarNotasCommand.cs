using MediatR;
using ServiciosDeAplicacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosDeAplicacion.Comandos
{
    public class ListarNotasCommand : IRequest<ListadoNotasVM>
    {
        public int UsuarioId { get; internal set; }
        public int Pagina { get; internal set; }

        public ListarNotasCommand(int usuarioId, int pagina)
        {
            UsuarioId = usuarioId;
            Pagina = pagina;
        }
    }
}

using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosDeDominio.Interfaces
{
    public interface ICreacionNota
    {
        Nota CrearNota(int idUsuario, string titulo, string contenidoHtml);
    }
}

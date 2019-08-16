using Dominio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosDeDominio.Interfaces
{
    public interface IBusquedaNotas
    {
        IQueryable<Nota> BuscarNotas(int idUsuario, string textoABuscar);
        Nota BuscarNota(int id);
    }
}

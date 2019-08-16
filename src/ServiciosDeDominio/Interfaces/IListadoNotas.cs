using Dominio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosDeDominio.Interfaces
{
    public interface IListadoNotas
    {
        IQueryable<Nota> ListarNotas(int idUsuario);
    }
}

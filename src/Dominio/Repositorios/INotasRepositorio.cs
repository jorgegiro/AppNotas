using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface INotasRepositorio
    {
        Nota GetNota(int id);
        IQueryable<Nota> GetNotasByUsuario(int idUsuario);
        IQueryable<Nota> BuscarNotas(int idUsuario, string textoABuscar);
        void EliminarNota(Nota nota);
        void GuardarNota(Nota nota);
        void ConmutarAnclada(Nota nota);
    }
}

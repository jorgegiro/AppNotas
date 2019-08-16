using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.EF
{
    public class NotasRepositorio : INotasRepositorio
    {
        protected ApplicationDbContext Contexto{ get; set; }

        public NotasRepositorio(ApplicationDbContext contexto)
        {
            if (contexto == null)
            {
                throw new ArgumentNullException(nameof(contexto));
            }

            Contexto = contexto;
        }

        public IQueryable<Nota> BuscarNotas(int idUsuario, string textoABuscar)
        {
            return GetNotasByUsuario(idUsuario)
                       .Where(n => (n.Titulo ?? string.Empty).Contains(textoABuscar, 
                                                     StringComparison.OrdinalIgnoreCase) ||
                                    n.ContenidoSoloTexto.Contains(textoABuscar, 
                                                                  StringComparison.OrdinalIgnoreCase));
        }

        public void EliminarNota(Nota nota)
        {
            Contexto.Notas.Remove(nota);
            Contexto.SaveChanges();
        }

        public void GuardarNota(Nota nota)
        {            
            if (nota.EsNueva)
            {
                Contexto.Notas.Add(nota);
            }
            else
            {
                Contexto.Notas.Update(nota);
            }

            Contexto.SaveChanges();
        }

        public IQueryable<Nota> GetNotasByUsuario(int idUsuario)
        {
            return Contexto.Notas.Where(n => n.UsuarioId == idUsuario)
                                 .OrderByDescending(n => n.Anclada)
                                 .ThenByDescending(n => n.FechaActualizacion);
        }

        public void ConmutarAnclada(Nota nota)
        {
            GuardarNota(nota);
        }

        public Nota GetNota(int id)
        {
            return Contexto.Notas.Where(n => n.ID == id).SingleOrDefault();
        }
    }
}

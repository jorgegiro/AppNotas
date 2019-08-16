using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Repositorios;
using ServiciosDeDominio.Excepciones;
using ServiciosDeDominio.Interfaces;

namespace ServiciosDeDominio
{
    public class NotasService : IActualizacionAnclajeNota, 
                                IActualizacionNota, 
                                IBusquedaNotas, 
                                ICreacionNota, 
                                IEliminacionNota,
                                IListadoNotas
    {
        protected INotasRepositorio RepositorioNotas { get; set; }
        
        public NotasService(INotasRepositorio repoNotas)
        {
            if (repoNotas == null)
            {
                throw new ArgumentNullException(nameof(repoNotas));
            }

            RepositorioNotas = repoNotas;
        }

        public Nota CrearNota(int idUsuario, string titulo, string contenidoHtml)
        {
            var nuevaNota = new Nota(idUsuario, titulo);
            nuevaNota.ContenidoHtml = contenidoHtml;
            

            RepositorioNotas.GuardarNota(nuevaNota);

            return nuevaNota;
        }

        public IQueryable<Nota> ListarNotas(int idUsuario)
        {
            var listadoNotas = RepositorioNotas.GetNotasByUsuario(idUsuario);
            return listadoNotas;
        }

        public IQueryable<Nota> BuscarNotas(int idUsuario, string textoABuscar)
        {
            var listadoNotasEcontradas = RepositorioNotas.BuscarNotas(idUsuario, textoABuscar ?? string.Empty);
            return listadoNotasEcontradas;
        }

        public void EliminarNota(int id)
        {
            var nota = RepositorioNotas.GetNota(id);

            if (nota == null)
            {
                throw new NotaNoEncontradaException(id);
            }
            
            RepositorioNotas.EliminarNota(nota);
        }

        public void ActualizarNota(Nota nota)
        {            
            var notaAActualizar = RecuperarNota(nota);

            notaAActualizar.Titulo = nota.Titulo;
            notaAActualizar.ContenidoHtml = nota.ContenidoHtml;
            notaAActualizar.FechaActualizacion = DateTime.Now;

            RepositorioNotas.GuardarNota(notaAActualizar);
        }

        public void ConmutarAnclajeNota(int id)
        {
            var notaAAnclar = BuscarNota(id);

            if (notaAAnclar == null)
            {
                throw new NotaNoEncontradaException(id);
            }

            notaAAnclar.ConmutarAnclaje();

            RepositorioNotas.ConmutarAnclada(notaAAnclar);
        }

        public Nota BuscarNota(int id)
        {
            return RepositorioNotas.GetNota(id);
        }

        protected Nota RecuperarNota(Nota nota)
        {
            if (nota.EsNueva)
            {
                throw new ArgumentException("No se puede recuperar una nota sin ID");
            }

            var notaRecuperada = BuscarNota(nota.ID);

            if (notaRecuperada == null)
            {
                throw new NotaNoEncontradaException(nota.ID);
            }

            return notaRecuperada;
        }
    }
}

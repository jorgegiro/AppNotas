using Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Nota
    {
        //public int? _id;
        public int ID { get; set; }

        public string Titulo { get; set; }

        private string _contenidoHtml;
        public string ContenidoHtml
        {
            get
            {
                return _contenidoHtml;
            }
            set
            {
                if (value != null)
                {
                    ContenidoSoloTexto = LimpiadorTextoHtml.Limpiar(value);
                }

                _contenidoHtml = value;
            }
        }

        public string ContenidoSoloTexto { get; internal set; }
        public bool Anclada { get; internal set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int UsuarioId { get; set; }
        public bool EsNueva => ID == 0;

        public Nota()
        { }

        public Nota(int idUsuario, string titulo)
        {
            UsuarioId = idUsuario;
            Titulo = titulo;
            Anclada = false;
            FechaCreacion = DateTime.Now;
            FechaActualizacion = FechaCreacion;
        }

        public void ConmutarAnclaje()
        {
            Anclada = !Anclada;
        }
    }
}

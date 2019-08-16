using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosDeAplicacion.ViewModels
{
    public class NotaListadoVM
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string CssAnclada { get; set; }
        public string TextoTituloAnclada { get; set; }
        public string FechaActualizacion { get; set; }

        public NotaListadoVM Map(Nota nota)
        {
            Id = nota.ID;
            Titulo = nota.Titulo;
            Contenido = nota.ContenidoHtml;
            CssAnclada = nota.Anclada ? "fas fa-circle" : "far fa-circle";
            TextoTituloAnclada = nota.Anclada ? "Desanclar" : "Anclar";
            FechaActualizacion = nota.FechaActualizacion.ToString("dd/MM/yyyy hh:mm");

            return this;
        }
    }
}

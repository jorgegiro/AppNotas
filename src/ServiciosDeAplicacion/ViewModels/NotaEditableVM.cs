using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosDeAplicacion.ViewModels
{
    public class NotaEditableVM
    {
        public string Titulo { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Contenido { get; set; }

        public virtual NotaEditableVM Map(Nota nota)
        {
            this.Titulo = nota.Titulo;
            this.Contenido = nota.ContenidoHtml;

            return this;
        }
    }
}

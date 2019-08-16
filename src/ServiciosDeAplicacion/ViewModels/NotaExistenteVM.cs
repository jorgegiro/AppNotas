using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosDeAplicacion.ViewModels
{
    public class NotaExistenteVM : NotaEditableVM
    {
        public int Id { get; set; }

        public override NotaEditableVM Map(Nota nota)
        {
            base.Map(nota);

            this.Id = nota.ID;

            return this;
        }
    }
}

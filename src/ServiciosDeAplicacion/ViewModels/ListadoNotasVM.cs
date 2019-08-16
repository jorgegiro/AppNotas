using Dominio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosDeAplicacion.ViewModels
{
    public class ListadoNotasVM
    {
        public ReadOnlyCollection<NotaListadoVM> NotasAncladas { get; set; }
        public ReadOnlyCollection<NotaListadoVM> NotasSinAnclar { get; set; }
        public bool ExistenNotas => NotasAncladas.Count > 0 || NotasSinAnclar.Count > 0;

        public ListadoNotasVM Map(IList<Nota> notas)
        {
            var notasConvertidas = notas.Where(n=>n.Anclada)
                                        .Select(n => new NotaListadoVM().Map(n)).ToList();
            this.NotasAncladas = new ReadOnlyCollection<NotaListadoVM>(notasConvertidas);

            notasConvertidas = notas.Where(n=> !n.Anclada)
                                        .Select(n => new NotaListadoVM().Map(n)).ToList();
            this.NotasSinAnclar = new ReadOnlyCollection<NotaListadoVM>(notasConvertidas);

            return this;
        }
    }
}

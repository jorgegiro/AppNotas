using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosDeDominio.Excepciones
{
    public class NotaNoEncontradaException : Exception
    {
        
        public NotaNoEncontradaException(int id) : base($"No se ha encontrado la nota con el id '{id}'")
        {
        }
    }
}

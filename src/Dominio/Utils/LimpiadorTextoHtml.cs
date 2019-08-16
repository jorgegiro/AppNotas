using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Dominio.Utils
{
    public static class LimpiadorTextoHtml
    {
        public static string Limpiar(string textoALimpiar)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(textoALimpiar);

            string textoLimpio = htmlDoc.DocumentNode.InnerText;

            return textoLimpio;
        }
    }
}

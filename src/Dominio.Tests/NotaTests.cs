using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Tests
{
    [TestClass]
    public class NotaTests
    {
        [TestMethod]
        public void SetContenidoHtml_ConTextoConEtiquetasHtml_ContenidoSoloTextoDevuelveTextoSinHtml()
        {
            //ARRANGE
            string textoHtml = "<b>En lugar</b> de la <span>mancha</span> de cuyo nombre no quiero acordarme...";
            var nota = new Nota(0, string.Empty);
            //ACT
            nota.ContenidoHtml = textoHtml;

            //ASSERT
            string textoEsperado = "En lugar de la mancha de cuyo nombre no quiero acordarme...";
            Assert.AreEqual(textoEsperado, nota.ContenidoSoloTexto);
        }

        [TestMethod]
        public void ConmutarAnclaje_CambiaEstadoAnclada()
        {
            //ARRANGE            
            var nota = new Nota(0, string.Empty);
            bool estadoInicial = nota.Anclada;

            //ACT
            nota.ConmutarAnclaje();

            //ASSERT
            bool estadoEsperado = !estadoInicial;
            Assert.AreEqual(estadoEsperado, nota.Anclada);
        }
    }
}

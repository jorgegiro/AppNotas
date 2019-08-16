using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Utils;

namespace Dominio.Tests.Utils
{
    [TestClass]
    public class LimpiadorTextoHtmlTests
    {
        [TestMethod]
        public void Limpiar_TextoSinHtml_DevuelveMismoTexto()
        {
            //ARRANGE
            string textoALimpiar = "En lugar de la mancha de cuyo nombre no quiero acordarme...";

            //ACT
            string textoLimpio = LimpiadorTextoHtml.Limpiar(textoALimpiar);

            //ASSERT
            Assert.AreEqual(textoALimpiar, textoLimpio);
        }

        [TestMethod]
        public void Limpiar_TextoConHtmlBienFormadoSinEntities_DevuelveSoloTextoSinEtiquetasHtml()
        {
            //ARRANGE
            string textoALimpiar = "<b>En lugar</b> de la <span>mancha</span> de cuyo nombre no quiero acordarme...";

            //ACT
            string textoLimpio = LimpiadorTextoHtml.Limpiar(textoALimpiar);

            //ASSERT
            string textoEsperado = "En lugar de la mancha de cuyo nombre no quiero acordarme...";
            Assert.AreEqual(textoEsperado, textoLimpio);
        }

        [TestMethod]
        public void Limpiar_TextoConHtmlBienFormadoConEntities_DevuelveSoloTextoSinEtiquetasHtmlYEntidadesConvertidas()
        {
            //ARRANGE
            string textoALimpiar = "<b>&aacute;&eacute;&iacute;&oacute;&uacute;</b>";

            //ACT
            string textoLimpio = LimpiadorTextoHtml.Limpiar(textoALimpiar);

            //ASSERT
            string textoEsperado = "áéíóú";
            Assert.AreEqual(textoEsperado, textoLimpio);
        }

        [TestMethod]
        public void Limpiar_TextoConHtmlMalFormado_DevuelveSoloTextoSinEtiquetasHtml()
        {
            //ARRANGE
            string textoALimpiar = "<b>En lugar de la <span>mancha</span> de cuyo nombre no quiero acordarme...</div>";

            //ACT
            string textoLimpio = LimpiadorTextoHtml.Limpiar(textoALimpiar);

            //ASSERT
            string textoEsperado = "En lugar de la mancha de cuyo nombre no quiero acordarme...";
            Assert.AreEqual(textoEsperado, textoLimpio);
        }
    }
}

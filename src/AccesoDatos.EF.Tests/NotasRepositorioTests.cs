using Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatos.EF.Tests
{
    [TestClass]
    public class NotasRepositorioTests
    {
        public IdentityUser<int> Usuario { get; set; } = new IdentityUser<int>("prueba@prueba.com");

        
        [TestMethod]
        public async Task BuscarNotas_BuscarNotaExistente_DevuelveListadoConNotas()
        {
            //ARRANGE
            var sut = CrearSUT();

            //ACT
            var notasBuscadas = await sut.BuscarNotas(Usuario.Id, "Nota 1").ToListAsync();

            //ASSERT            
            Assert.IsNotNull(notasBuscadas);
            Assert.IsTrue(notasBuscadas.Count > 0);
        }

        [TestMethod]
        public async Task BuscarNotas_BuscarNotaNoExiste_NoDevuelveNada()
        {
            //ARRANGE
            var sut = CrearSUT();

            //ACT
            var notaBuscada = await sut.BuscarNotas(Usuario.Id, "Nota 1000").SingleOrDefaultAsync();

            //ASSERT
            Assert.IsNull(notaBuscada);
        }

        [TestMethod]
        public async Task EliminarNota_EliminaNota()
        {
            //ARRANGE
            var sut = CrearSUT();
            var notaAEliminar = await sut.GetNotasByUsuario(Usuario.Id).Where(n => n.ID == 1).SingleOrDefaultAsync();

            //ACT
            sut.EliminarNota(notaAEliminar);
            var notaBuscada = await sut.GetNotasByUsuario(Usuario.Id).Where(n => n.ID == 1).SingleOrDefaultAsync();

            //ASSERT
            Assert.IsNull(notaBuscada);
        }

        [TestMethod]
        public async Task GuardarNota_NotaNueva_InsertaNota()
        {
            //ARRANGE
            var sut = CrearSUT();
            var notaAInsertar = new Nota(Usuario.Id, "Nota Nueva");

            //ACT
            sut.GuardarNota(notaAInsertar);            

            //ASSERT
            Assert.IsTrue(notaAInsertar.ID > 0);
        }

        [TestMethod]
        public async Task GuardarNota_NotaExistente_ModificaDatos()
        {
            //ARRANGE
            var sut = CrearSUT();
            string nuevoTitulo = "Nota Modificada";
            string nuevoContenido = "Contenido Nota modificada";
            var notaAActualizar = await sut.GetNotasByUsuario(Usuario.Id).Where(n => n.ID == 1).SingleOrDefaultAsync();

            //ACT
            notaAActualizar.Titulo = nuevoTitulo;
            notaAActualizar.ContenidoHtml = nuevoContenido;

            sut.GuardarNota(notaAActualizar);

            var notaBuscada = await sut.GetNotasByUsuario(Usuario.Id).Where(n => n.ID == 1).SingleOrDefaultAsync();

            //ASSERT
            Assert.AreEqual(nuevoTitulo, notaBuscada.Titulo);
            Assert.AreEqual(nuevoContenido, notaBuscada.ContenidoHtml);
        }


        [TestMethod]
        public async Task GetNota_NotaExistente_DevuelveNotaBuscada()
        {
            //ARRANGE
            var sut = CrearSUT();

            //ACT
            var notaBuscada = sut.GetNota(1);

            //ASSERT
            int idEsperado = 1;
            Assert.AreEqual(idEsperado, notaBuscada.ID);
        }

        protected ApplicationDbContext CrearContexto()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "TestDb")
                            .Options;

            var dbContext = new ApplicationDbContext(dbOptions);

            dbContext.Add(Usuario);
            dbContext.SaveChanges();
            // Rellenar
            for (int i = 0; i < 11; i++)
            {
                var nota = new Nota(Usuario.Id, $"Nota {i}");
                nota.ContenidoHtml = $"Texto nota {i}";
                dbContext.Add(nota);
            }

            dbContext.SaveChanges();

            return dbContext;
        }

        protected NotasRepositorio CrearSUT()
        {
            return new NotasRepositorio(CrearContexto());
        }
    }
}

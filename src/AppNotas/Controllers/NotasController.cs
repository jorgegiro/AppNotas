using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ServiciosDeAplicacion.Comandos;
using Microsoft.AspNetCore.Identity;
using ServiciosDeAplicacion.ViewModels;
using ServiciosDeDominio.Excepciones;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppNotas.Controllers
{
    public class NotasController : BaseController
    {
        protected IMediator Mediator { get; set; }
        public NotasController(UserManager<IdentityUser<int>> userManager, IMediator mediator):base(userManager)
        {
            if (mediator == null)
            {
                throw new ArgumentNullException(nameof(mediator));
            }

            Mediator = mediator;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(int pagina = 0, string textoBuscado = "")
        {
            int usuarioId = (await GetCurrentUser()).Id;

            IRequest<ListadoNotasVM> peticion;

            if (textoBuscado != string.Empty)
            {
                peticion = new BuscarNotasCommand(usuarioId, textoBuscado, pagina);
            }
            else
            {
                peticion = new ListarNotasCommand(usuarioId, pagina);
            }

            var notas = await Mediator.Send(peticion);

            if (notas.ExistenNotas)
            {
                return View(notas);
            }

            return View("ListadoNotasVacio");
        }

        [HttpGet]
        public async Task<IActionResult> BuscarNotas(string text, int pagina=0)
        {
            int usuarioId = (await GetCurrentUser()).Id;
            var notas = await Mediator.Send(new BuscarNotasCommand(usuarioId, text, pagina));

            if (notas.ExistenNotas)
            {
                return PartialView("_ListadoNotas", notas);
            }

            return PartialView("_BusquedaNotasVacia");
        }

        [HttpGet]
        public IActionResult Nueva()
        {
            return View("Editar", new NotaEditableVM());
        }

        [HttpPost]
        public async Task<IActionResult> Nueva(NotaEditableVM nota)
        {
            if(ModelState.IsValid)
            {
                int usuarioId = (await GetCurrentUser()).Id;

                var notas = await Mediator.Send(new CrearNotaCommand(usuarioId, nota.Titulo, nota.Contenido));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ConmutarAnclaje(int id)
        {
            try
            {
                var notas = await Mediator.Send(new ConmutarAnclajeCommand(id));

                return RedirectToAction(nameof(Index));
            }
            catch (NotaNoEncontradaException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            try
            {                
                var nota = await Mediator.Send(new BuscarNotaParaEditarCommand(id));
                

                return View("Editar", nota);
            }
            catch (NotaNoEncontradaException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, NotaExistenteVM nota)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var notas = await Mediator.Send(new EditarNotaCommand(nota.Id, nota.Titulo, nota.Contenido));
                }

                return RedirectToAction(nameof(Index));
            }
            catch (NotaNoEncontradaException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Borrar(int id)
        {
            try
            {
                var notas = await Mediator.Send(new BorrarNotaCommand(id));

                return RedirectToAction(nameof(Index));
            }
            catch(NotaNoEncontradaException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

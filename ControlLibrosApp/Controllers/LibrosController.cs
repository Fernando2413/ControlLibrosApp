using Microsoft.AspNetCore.Mvc;
using Negocio;
using Entidad;

namespace ControlLibrosApp.Controllers
{
    public class LibrosController : Controller
    {
        private readonly LibrosService _service;

        public LibrosController(LibrosService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var libros = _service.ObtenerTodos();
            return View(libros);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _service.Agregar(libro);
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        public IActionResult Edit(int id)
        {
            var libro = _service.ObtenerPorId(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _service.Actualizar(libro);
                return RedirectToAction(nameof(Index));
            }

            return View(libro);
        }

        public IActionResult Delete(int id)
        {

            var libro = _service.ObtenerPorId(id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(int id)
        {
            var libro = _service.ObtenerPorId(id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }
    }
}

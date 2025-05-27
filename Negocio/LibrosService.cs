using Entidad;
using Modelo;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class LibrosService
    {
        private readonly LibrosContext _context;

        public LibrosService(LibrosContext context)
        {
            _context = context;
        }

        public IEnumerable<Libro> ObtenerTodos()
        {
            return _context.Libros.ToList();
        }

        public Libro? ObtenerPorId(int id)
        {
            return _context.Libros.FirstOrDefault(l => l.IdLibro == id);
        }

        public void Agregar(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }
        public void Actualizar(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var libro = _context.Libros.Find(id);
            if(libro != null)
            {
                _context.Libros.Remove(libro);
                _context.SaveChanges();
            }
        }
    }
}

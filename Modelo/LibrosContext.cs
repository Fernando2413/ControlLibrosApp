using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Modelo;

public class LibrosContext : DbContext
{
    public LibrosContext(DbContextOptions<LibrosContext> options) : base(options) { }

    public DbSet<Libro> Libros { get; set; }

}

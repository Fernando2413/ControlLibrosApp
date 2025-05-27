using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad;

public class Libro
{
    [Key]
    public int IdLibro { get; set; }

    public string TituloLibro { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Autor { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public DateOnly? FechaPublicacion { get; set; } = null!;
}

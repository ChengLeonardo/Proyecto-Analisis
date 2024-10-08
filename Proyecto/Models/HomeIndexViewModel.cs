namespace Proyecto.Models;

public class HomeIndexViewModel
{
    public bool Administrador { get; set; }
    public List<Libro> LibrosPopulares { get; set; }
    public List<Libro> LibrosNuevos { get; set; }
    public List<Libro> LibrosElegidos { get; set; }
    public List<Genero> Generos { get; set; }
    public bool EsOperador { get; set; }  // Agregar esta propiedad
}

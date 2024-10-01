namespace Proyecto.Models;

public class HomeIndexViewModel
{
    public List<Genero> Generos { get; set; }
    public List<Libro> LibrosPopulares { get; set; }
    public List<Libro> LibrosNuevos { get; set; }
    public List<Libro> LibrosElegidos { get; set; }
    public bool Administrador { get; set; } = false;
}

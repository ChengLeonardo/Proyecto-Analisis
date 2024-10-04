using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Interfaces;
using Proyecto.Models;
using Microsoft.EntityFrameworkCore;


namespace Proyecto.Controllers;

public class HomeController : Controller
{
    private IRepoOperador _repoOperador;
    private IRepoLibro _repoLibro;
    private IRepoGenero _repoGenero;
    private IRepoEjemplar _repoEjemplar;
    private IRepoPrestamo _repoPrestamo;

    public HomeController(IRepoOperador repoOperador, IRepoGenero repoGenero, IRepoEjemplar repoEjemplar, IRepoLibro repoLibro, IRepoPrestamo repoPrestamo)
    {
        _repoOperador = repoOperador;
        _repoLibro = repoLibro;
        _repoGenero = repoGenero;
        _repoEjemplar = repoEjemplar;
        _repoPrestamo = repoPrestamo;
    }

    [HttpGet]
    public IActionResult Login()
    {
        
        if (!User.Identity.IsAuthenticated)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        if (!User.Identity.IsAuthenticated)
        {
            return View();
        }
        else
        {
            return RedirectToAction("Index", "Home");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Register(Operador model)
    {
        if (ModelState.IsValid)
        {
            var mailExistente = _repoOperador.SelectWhere(u => u.Usuario == model.Usuario).FirstOrDefault();
            if(mailExistente != null)
            {
                ModelState.AddModelError("Usuario", "El usuario ya está en uso. Por favor, elige otro.");
                return View(model);
            }
            else
            { 
                var operador = new Operador
                {
                    Email = model.Email,
                    Pass = BCrypt.Net.BCrypt.HashPassword(model.Pass),
                    Apellido = model.Apellido,
                    Nombre = model.Nombre,
                    Usuario = model.Usuario,
                    IdOperador = 0
                };

                var idAutoIncrementado = _repoOperador.Insert(operador, "IdOperador");
                operador.IdOperador = idAutoIncrementado;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, operador.IdOperador.ToString()),
                };

                // Crear la identidad y el principal
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);    
                return RedirectToAction("Index", "Home");
            }
        }
        else
        {
            return View(model);
        }
        
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if(ModelState.IsValid)
        {
            var usuarioExistente = _repoOperador.SelectWhere(o => o.Usuario == model.Usuario).FirstOrDefault();

            if(usuarioExistente != null)
            {
                if(BCrypt.Net.BCrypt.Verify(model.Pass, usuarioExistente.Pass))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuarioExistente.IdOperador.ToString())
                    };

                    // Crear la identidad y el principal
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Nombre usuario o Pass incorrecta.");
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Home");
    }
    public IActionResult Index()
    {
        HomeIndexViewModel model = new HomeIndexViewModel();
        if(Convert.ToUInt16(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value) == 1)
        {
            model.Administrador = true;
        }

        var prestamos = _repoPrestamo.Select().Include(p => p.Ejemplar).ToList();

        var librosMasPrestados = prestamos
            .GroupBy(p => p.Ejemplar.IdLibro) // Agrupar por idLibro
            .Select(g => new
            {
                IdLibro = g.Key,
                CantidadPrestamos = g.Count() // Contar cuántos préstamos hay por libro
            })
            .OrderByDescending(x => x.CantidadPrestamos) // Ordenar por cantidad de préstamos
            .Take(10) // Limitar a los 10 libros más prestados (puedes cambiar el número según lo necesites)
            .ToList();

        var LibrosNuevos = _repoLibro.Select().Include(x => x.Editorial).Include(x => x.Titulo).OrderByDescending(x => x.FechaAgregada) // Ordenar por cantidad de préstamos
            .Take(10)
            .ToList(); // Limitar a los 10 libros más prestados (puedes cambiar el número según lo necesites)

        model.LibrosNuevos = LibrosNuevos;
        var idsLibrosMasPrestados = librosMasPrestados.Select(l => l.IdLibro).ToList();

        model.LibrosPopulares = _repoLibro.SelectWhere(libro => idsLibrosMasPrestados.Contains(libro.IdLibro)).Include(libro => libro.Titulo).Include(libro => libro.Editorial).ToList();
        
        var librosElegidos = _repoLibro.Select().OrderByDescending(x => x.Calificacion).Take(10).ToList();
        model.LibrosElegidos = librosElegidos;

        var generos = _repoGenero.Select().ToList();

        model.Generos = generos;

        return View(model);
    }

    public IActionResult ModificarLibro()
    {
        return View();
    }
    public IActionResult ModificarGenero()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

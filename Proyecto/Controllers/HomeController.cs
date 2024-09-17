using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Interfaces;
using Proyecto.Models;

namespace Proyecto.Controllers;

public class HomeController : Controller
{
    private IRepoOperador _repoOperador;

    public HomeController(IRepoOperador repoOperador)
    {
        _repoOperador = repoOperador;
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

    [HttpPost]
    public async Task<IActionResult> Login(Operador model)
    {
        if(ModelState.IsValid)
        {
            var usuarioExistente = _repoOperador.SelectWhere(o => o.NombreUsuario == model.NombreUsuario).FirstOrDefault();

            if(usuarioExistente != null)
            {
                if(BCrypt.Net.BCrypt.Verify(model.Contrasena, usuarioExistente.Contrasena))
                {
                    var rol = _repoRolUsuario.IdSelect(usuarioExistente.IdRol);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuarioExistente.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Name, usuarioExistente.NombreUsuario),
                        new Claim(ClaimTypes.Email, usuarioExistente.Email),
                        new Claim(ClaimTypes.Role, rol.Descripcion)
                    };

                    // Crear la identidad y el principal
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Nombre usuario o contrasena incorrecta.");
        }

        return View(model);
    }

    public IActionResult Index()
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

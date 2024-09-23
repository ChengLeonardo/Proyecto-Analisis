using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            var usuarioExistente = _repoOperador.SelectWhere(o => o.Nombre == model.Usuario).FirstOrDefault();

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

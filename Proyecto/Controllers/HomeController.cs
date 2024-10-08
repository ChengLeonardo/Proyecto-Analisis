using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Interfaces;
using Proyecto.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;
using System.Security.Cryptography;
using System.Text;

namespace Proyecto.Controllers;

public class HomeController : Controller
{
    private IRepoOperador _repoOperador;
    private IRepoLibro _repoLibro;
    private IRepoGenero _repoGenero;
    private IRepoEjemplar _repoEjemplar;
    private IRepoPrestamo _repoPrestamo;
    private readonly IWebHostEnvironment _environment;
    private readonly IRepoEditorial _repoEditorial;
    private readonly IRepoTitulo _repoTitulo;
    private readonly IRepoSocio _repoSocio;
    private readonly IRepoUsuario _repoUsuario;
    public HomeController(IRepoOperador repoOperador, IRepoSocio repoSocio, IRepoGenero repoGenero, IRepoEjemplar repoEjemplar, IRepoLibro repoLibro, IRepoPrestamo repoPrestamo, IWebHostEnvironment environment, IRepoEditorial repoEditorial, IRepoTitulo repoTitulo, IRepoUsuario repoUsuario)
    {
        _repoOperador = repoOperador;
        _repoLibro = repoLibro;
        _repoGenero = repoGenero;
        _repoEjemplar = repoEjemplar;
        _repoPrestamo = repoPrestamo;
        _environment = environment;
        _repoEditorial = repoEditorial;
        _repoTitulo = repoTitulo;
        _repoSocio = repoSocio;
        _repoUsuario = repoUsuario;
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
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var usuarioExistente = await _repoUsuario.SelectWhere(u => u.NombreUsuario == model.Usuario)
                .FirstOrDefaultAsync();

            if (usuarioExistente != null)
            {
                ModelState.AddModelError("Usuario", "Nombre de usuario ya existe, use otro.");
                return View(model);
            }

            if (model.TipoUsuario == TipoUsuario.Operador && model.CodigoOperador != "CodigoSecreto123")
            {
                ModelState.AddModelError("CodigoOperador", "Código de registro de operador inválido.");
                return View(model);
            }

            var nuevoUsuario = new Usuario
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Email = model.Email,
                NombreUsuario = model.Usuario,
                Pass = BCrypt.Net.BCrypt.HashPassword(model.Pass),
                TipoUsuario = model.TipoUsuario
            };

            if (model.TipoUsuario == TipoUsuario.Operador)
            {
                var operador = new Operador { Usuario = nuevoUsuario };
                _repoOperador.Insert(operador, "IdOperador");
            }
            else
            {
                var socio = new Socio 
                { 
                    Usuario = nuevoUsuario,
                    // 如果需要，可以在这里添加 Telefono 和 FechaNacimiento
                };
                _repoSocio.Insert(socio, "IdSocio");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, nuevoUsuario.IdUsuario.ToString(), ClaimValueTypes.String),
                new Claim(ClaimTypes.Role, nuevoUsuario.TipoUsuario.ToString(), ClaimValueTypes.String)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);    
            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var usuario = _repoUsuario.SelectWhere(usuario => usuario.NombreUsuario == model.Usuario).FirstOrDefault();


            if (usuario != null && BCrypt.Net.BCrypt.Verify(model.Pass, usuario.Pass))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString(), ClaimValueTypes.String)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Nombre de usuario o contraseña incorrectos.");
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
        if (!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Home");
        }

        HomeIndexViewModel model = new HomeIndexViewModel();
        if(HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Operador")
        {
            model.Administrador = true;
        }

        var prestamos = _repoPrestamo.Select().Include(p => p.Ejemplar).ToList();

        // Obtener los libros más prestados, agrupando por ID de libro
        var librosMasPrestados = prestamos
            .GroupBy(p => p.Ejemplar.IdLibro) // Agrupar por IdLibro
            .Select(g => new
            {
                IdLibro = g.Key,
                CantidadPrestamos = g.Count() // Contar los préstamos por libro
            })
            .OrderByDescending(x => x.CantidadPrestamos) // Ordenar por cantidad de préstamos (ascendente)
            .Take(10) // Limitar a los 10 libros más prestados
            .ToList();

        System.Console.WriteLine(librosMasPrestados.Count());

        // Obtener los libros nuevos, ordenando por fecha agregada de forma descendente
        var LibrosNuevos = _repoLibro.Select()
            .Include(x => x.Editorial)
            .Include(x => x.Titulo)
            .OrderByDescending(x => x.FechaAgregada) // Ordenar por fecha de agregación
            .Take(10) // Limitar a los 10 libros más nuevos
            .ToList();

        // Asignar los libros nuevos al modelo
        model.LibrosNuevos = LibrosNuevos;

        // Obtener los IDs de los libros más prestados
        var idsLibrosMasPrestados = librosMasPrestados.Select(l => l.IdLibro).ToList();

        // Obtener los libros populares basados en los IDs de libros más prestados
        model.LibrosPopulares = _repoLibro.SelectWhere(libro => idsLibrosMasPrestados.Contains(libro.IdLibro))
            .Include(libro => libro.Titulo)
            .Include(libro => libro.Editorial)
            .ToList();

        var librosElegidos = _repoLibro.Select().OrderByDescending(x => x.Calificacion).Take(10).ToList();
        model.LibrosElegidos = librosElegidos;

        var generos = _repoGenero.Select().ToList();

        model.Generos = generos;

        return View(model);
    }

    public IActionResult ModificarLibro(int id)
    {
        var libro = _repoLibro.SelectWhere(x => x.IdLibro == id).Include(x => x.Editorial).Include(x => x.Titulo).FirstOrDefault();

        ModificarLibroViewModel model = new ModificarLibroViewModel{IdLibro = libro.IdLibro, Calificacion = libro.Calificacion, Editorial = libro.Editorial.editorial, FechaAgregada = libro.FechaAgregada, ISBN = libro.ISBN, RutaFoto = libro.RutaFoto, Titulo = libro.Titulo.titulo};

        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> ModificarLibro(ModificarLibroViewModel model)
    {
        if (ModelState.IsValid)
        {
            if(model.Calificacion < 0 || model.Calificacion > 5)
            {
                ModelState.AddModelError("Calificacion", "La calificación debe estar entre 0 y 5.");
                return View(model);
            }
            string uniqueFileName = null;

            var Editorial = _repoEditorial.SelectWhere(x => x.editorial == model.Editorial).FirstOrDefault();
            if (Editorial == null)
            {
                ModelState.AddModelError("Editorial", "Editorial no existe");
                return View(model);
            }

            // Obtener el libro actual de la base de datos
            var libro = _repoLibro.SelectWhere(l => l.IdLibro == model.IdLibro)
                     .Include(l => l.Titulo)  // Incluye la relación Titulo
                     .FirstOrDefault();

            var Titulo = _repoTitulo.SelectWhere(x => x.titulo == model.Titulo).Include(x => x.Generos).Include(x => x.Autores).Include(x => x.Libros).FirstOrDefault();
            if (Titulo == null)
            {
                var autor = _repoLibro.Select()
                    .Where(libro => libro.IdLibro == model.IdLibro)
                    .SelectMany(libro => libro.Titulo.Autores)
                    .FirstOrDefault();

                List<Genero> generos = _repoLibro.Select()
                    .Where(libro => libro.IdLibro == model.IdLibro)
                    .SelectMany(libro => libro.Titulo.Generos)
                    .ToList();

                Titulo titulo = new Titulo
                {
                    Autores = new List<Autor> { autor },
                    Generos = generos,
                    IdTitulo = 0,
                    Libros = new List<Libro>(),
                    titulo = model.Titulo
                };
                libro.Titulo = titulo;
            }
            else
            {
                libro.Titulo = Titulo;
            }

            // Si hay una nueva foto, manejar la subida
            if (model.Foto != null)
            {
                // Eliminar la foto anterior si existe
                if (!string.IsNullOrEmpty(libro.RutaFoto))
                {
                    string previousFilePath = Path.Combine(_environment.WebRootPath, "images", libro.RutaFoto);
                    if (System.IO.File.Exists(previousFilePath))
                    {
                        System.IO.File.Delete(previousFilePath);
                    }
                }

                // Guardar la nueva foto
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Foto.CopyToAsync(fileStream);
                }

                libro.RutaFoto = uniqueFileName;
            }

            // Actualizar los demás campos del libro
            libro.ISBN = model.ISBN;
            libro.FechaAgregada = model.FechaAgregada;
            libro.Calificacion = model.Calificacion;
            libro.Editorial = Editorial;

            _repoLibro.Update(libro);

            return RedirectToAction("DetalleLibro", "Home", new { id = libro.IdLibro });
        }
        // if (!ModelState.IsValid)
        // {
        //     foreach (var state in ModelState)
        //     {
        //         foreach (var error in state.Value.Errors)
        //         {
        //             Console.WriteLine($"Error en el campo {state.Key}: {error.ErrorMessage}");
        //         }
        //     }
        //     return View(model);
        // }


        return View(model);
    }


    public IActionResult ModificarGenero(uint IdGenero)
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

    public IActionResult DetalleLibro(int id)
    {
        var libro = _repoLibro.SelectWhere(l => l.IdLibro == id)
            .Include(l => l.Editorial)
            .Include(l => l.Titulo)
                .ThenInclude(t => t.Autores)
            .Include(l => l.Titulo)
                .ThenInclude(t => t.Generos)    
            .FirstOrDefault();

        if (libro == null)
        {
            return NotFound();
        }

        var ejemplares = _repoEjemplar.SelectWhere(e => e.IdLibro == id).ToList();

        var viewModel = new DetalleLibroViewModel
        {
            IdLibro = libro.IdLibro,
            Titulo = libro.Titulo.titulo,
            ISBN = libro.ISBN,
            RutaFoto = libro.RutaFoto,
            FechaAgregada = libro.FechaAgregada,
            Calificacion = libro.Calificacion,
            Editorial = libro.Editorial.editorial,
            NombreAutor = libro.Titulo.Autores.FirstOrDefault()?.Nombre ?? "",
            ApellidoAutor = libro.Titulo.Autores.FirstOrDefault()?.Apellido ?? "",
            Genero = libro.Titulo.Generos.FirstOrDefault()?.genero ?? "",
            Stock = ejemplares.Count,
            // 注意：价格和描述字段在当前模型中不存在，您可能需要添加这些字段或从其他地方获取
            Precio = 0, // 临时设置为0
            Descripcion = "描述暂缺" // 临时设置
        };

        return View(viewModel);
    }

    public IActionResult BuscarLibro(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return View(new List<Libro>());
        }

        // 首先从数据库获取所有书籍和标题
        var librosConTitulos = _repoLibro.Select()
            .Include(l => l.Titulo)
            .Include(l => l.Editorial)
            .AsEnumerable() // 将查询结果加载到内存中
            .Select(l => new
            {
                Libro = l,
                Similitud = CalcularSimilitud(query, l.Titulo.titulo)
            })
            .Where(x => x.Similitud >= 0.7) // 在内存中进行过滤
            .OrderByDescending(x => x.Similitud)
            .Select(x => x.Libro)
            .ToList();

        return View(librosConTitulos);
    }


    private double CalcularSimilitud(string s, string t)
    {
        int n = s.Length;
        int m = t.Length;
        int[,] d = new int[n + 1, m + 1];

        if (n == 0) return m;
        if (m == 0) return n;

        for (int i = 0; i <= n; d[i, 0] = i++) { }
        for (int j = 0; j <= m; d[0, j] = j++) { }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                d[i, j] = Math.Min(
                    Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                    d[i - 1, j - 1] + cost);
            }
        }

        return 1.0 - ((double)d[n, m] / Math.Max(s.Length, t.Length));
    }

}
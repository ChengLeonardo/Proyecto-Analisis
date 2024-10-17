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
    private readonly IRepoAutor _repoAutor;
    public HomeController(IRepoOperador repoOperador, IRepoSocio repoSocio, IRepoGenero repoGenero, IRepoEjemplar repoEjemplar, IRepoLibro repoLibro, IRepoPrestamo repoPrestamo, IWebHostEnvironment environment, IRepoEditorial repoEditorial, IRepoTitulo repoTitulo, IRepoUsuario repoUsuario, IRepoAutor repoAutor)
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
        _repoAutor = repoAutor;
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
            model.EsOperador = true;
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

    [HttpGet]
    public IActionResult ModificarLibro(int id)
    {
        if(!User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Login", "Home");
        }
        
        var libro = _repoLibro.SelectWhere(x => x.IdLibro == id)
            .Include(x => x.Editorial)
            .Include(x => x.Titulo)
            .ThenInclude(t => t.Generos)
            .FirstOrDefault();

        if (libro == null)
        {
            return NotFound();
        }

        var model = new ModificarLibroViewModel
        {
            // ... otros campos ...
            GenerosSeleccionados = libro.Titulo.Generos.Select(g => g.IdGenero).ToList(),
            Editoriales = _repoEditorial.Select().ToList(),
            Generos = _repoGenero.Select().ToList(),
            IdLibro = libro.IdLibro,
            Titulo = libro.Titulo.titulo,
            ISBN = libro.ISBN,
            RutaFoto = libro.RutaFoto,
            FechaAgregada = libro.FechaAgregada,
            Calificacion = libro.Calificacion,
            IdEditorial = libro.Editorial.IdEditorial,
        };

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

            var editorial = _repoEditorial.SelectWhere(x => x.IdEditorial == model.IdEditorial).FirstOrDefault();
            if (editorial == null)
            {
                ModelState.AddModelError("IdEditorial", "Editorial no existe");
                return View(model);
            }

            // Obtener el libro actual de la base de datos
            var libro = _repoLibro.SelectWhere(l => l.IdLibro == model.IdLibro)
                     .Include(l => l.Titulo)
                        .ThenInclude(t => t.Generos)
                     .Include(l => l.Titulo)
                        .ThenInclude(t => t.Autores)
                     .FirstOrDefault();

            // Actualizar el título si ha cambiado
            if (libro.Titulo.titulo != model.Titulo)
            {
                var tituloExistente = _repoTitulo.SelectWhere(x => x.titulo == model.Titulo).FirstOrDefault();
                if (tituloExistente == null)
                {
                    libro.Titulo.titulo = model.Titulo;
                }
                else
                {
                    libro.Titulo = tituloExistente;
                }
            }

            // Actualizar géneros
            var generosSeleccionados = await _repoGenero.SelectWhere(g => model.GenerosSeleccionados.Contains(g.IdGenero)).ToListAsync();
            libro.Titulo.Generos.Clear();
            foreach (var genero in generosSeleccionados)
            {
                libro.Titulo.Generos.Add(genero);
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
            libro.Editorial = editorial;

            _repoLibro.Update(libro);

            return RedirectToAction("DetalleLibro", new { id = libro.IdLibro });
        }

        // Si el modelo no es válido, volver a cargar las listas de editoriales y géneros
        model.Editoriales = _repoEditorial.Select().ToList();
        model.Generos = _repoGenero.Select().ToList();
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
            Genero = libro.Titulo.Generos.Select(g => g.genero).ToList(),
            Stock = ejemplares.Count,
        };

        return View(viewModel);
    }

    public IActionResult BuscarLibro(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return View(new List<Libro>());
        }

        // 首先从数据库获取所有书籍和题
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

    public IActionResult DetalleGenero(int id)
    {
        var genero = _repoGenero.SelectWhere(g => g.IdGenero == id)
            .Include(g => g.Titulos)
                .ThenInclude(t => t.Libros)
                    .ThenInclude(l => l.Editorial)
            .FirstOrDefault();

        if (genero == null)
        {
            return NotFound();
        }

        var viewModel = new DetalleGeneroViewModel
        {
            IdGenero = genero.IdGenero,
            NombreGenero = genero.genero,
            RutaFoto = genero.RutaFoto,
            Libros = genero.Titulos.SelectMany(t => t.Libros).ToList(),
            EsOperador = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Operador"
        };

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult AgregarLibro()
    {
        if (HttpContext.User.FindFirst(ClaimTypes.Role)?.Value != "Operador")
        {
            return Forbid();
        }

        var generos = _repoGenero.Select().ToList();

        var viewModel = new AgregarLibroViewModel
        {
            Editoriales = _repoEditorial.Select().ToList(),
            Generos = generos,
            GenerosSeleccionados = generos.Select(g => g.IdGenero).ToList(),  
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AgregarLibro(AgregarLibroViewModel model)
    {
        if (HttpContext.User.FindFirst(ClaimTypes.Role)?.Value != "Operador")
        {
            return Forbid();
        }

        if (ModelState.IsValid)
        {
            var editorial = await _repoEditorial.SelectWhere(e => e.IdEditorial == model.IdEditorial).FirstOrDefaultAsync();
            var generos = await _repoGenero.SelectWhere(g => model.GenerosSeleccionados.Contains(g.IdGenero)).ToListAsync();

            if (editorial == null || generos == null)
            {
                ModelState.AddModelError("", "Editorial o género no válido");
                model.Editoriales = _repoEditorial.Select().ToList();
                model.Generos = _repoGenero.Select().ToList();
                return View(model);
            }

            var tituloExistente = _repoTitulo.SelectWhere(t => t.titulo == model.Titulo).FirstOrDefault();
            Titulo titulo;
            if(tituloExistente != null)
            {
                titulo = tituloExistente;
            }
            else
            {
                titulo = new Titulo
                {
                titulo = model.Titulo,
                Generos = generos
                };
            }

            var autorExistente = _repoAutor.SelectWhere(a => a.Nombre == model.NombreAutor && a.Apellido == model.ApellidoAutor).FirstOrDefault();
            Autor autor;
            if(autorExistente != null)
            {
                autor = autorExistente;
            }
            else
            {
                autor = new Autor
                {
                Nombre = model.NombreAutor,
                Apellido = model.ApellidoAutor
                };
            }

            titulo.Autores = new List<Autor> { autor };

            var libro = new Libro
            {
                ISBN = model.ISBN,
                FechaAgregada = DateTime.Now,
                Calificacion = model.Calificacion,
                Editorial = editorial,
                Titulo = titulo
            };

            if (model.Foto != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Foto.CopyToAsync(fileStream);
                }

                libro.RutaFoto = uniqueFileName;
            }

            _repoLibro.Insert(libro, "IdLibro");

            return RedirectToAction("Index", "Home");
        }

        model.Editoriales = _repoEditorial.Select().ToList();
        model.Generos = _repoGenero.Select().ToList();
        return View(model);
    }

    public IActionResult AgregarGenero()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AgregarGenero(AgregarGeneroViewModel model)
    {
        if (ModelState.IsValid)
        {
            string uniqueFileName = null;
            if (model.Foto != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Foto.CopyToAsync(fileStream);
                }
            }

            var genero = new Genero
            {
                genero = model.NombreGenero,
                RutaFoto = uniqueFileName
            };

            _repoGenero.Insert(genero, "IdGenero");
            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult ModificarGenero(int id)
    {
        var genero = _repoGenero.SelectWhere(g => g.IdGenero == id).FirstOrDefault();
        if (genero == null)
        {
            return NotFound();
        }

        var viewModel = new ModificarGeneroViewModel
        {
            IdGenero = genero.IdGenero,
            NombreGenero = genero.genero,
            RutaFoto = genero.RutaFoto
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> ModificarGenero(ModificarGeneroViewModel model)
    {
        if (ModelState.IsValid)
        {
            string uniqueFileName = null;
            if (model.Foto != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Foto.CopyToAsync(fileStream);
                }

                model.RutaFoto = uniqueFileName;
            }
            var genero = _repoGenero.SelectWhere(g => g.IdGenero == model.IdGenero).FirstOrDefault();
            if (genero == null)
            {
                return NotFound();
            }

            genero.genero = model.NombreGenero;
            genero.RutaFoto = model.RutaFoto;

            _repoGenero.Update(genero);
            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult HacerPrestamo(int idLibro)
    {
        if (HttpContext.User.FindFirst(ClaimTypes.Role)?.Value != "Socio")
        {
            return Forbid();
        }

        if (ModelState.IsValid)
        {
            var ejemplar = _repoEjemplar.SelectWhere(e => e.IdLibro == idLibro && e.Disponible).FirstOrDefault();
            if (ejemplar == null)
            {
                ModelState.AddModelError("", "No hay ejemplares disponibles de este libro.");
                return RedirectToAction("DetalleLibro", new { id = idLibro });
            }
            var idUsuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var socio = _repoSocio.SelectWhere(s => s.IdUsuario == idUsuario).FirstOrDefault();
            if (socio == null)
            {
                throw new Exception("No se encontró el socio asociado a este usuario.");
            }
            var prestamo = new Prestamo
            {
                IdEjemplar = ejemplar.IdEjemplar,
                IdSocio = socio.IdSocio,
                Salida = DateTime.Now,
                Recibido = false,
                Socio = socio
            };

            _repoPrestamo.Insert(prestamo, "IdPrestamo");

            return RedirectToAction("Prestamos", "Home", new { socioId = socio.IdSocio });
        }

        return RedirectToAction("DetalleLibro", new { id = idLibro });
    }

    public IActionResult Prestamos(uint? socioId)
    {
        var model = new PrestamosViewModel();
        List<Prestamo> prestamos = new List<Prestamo>();
        if (HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Operador" || HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Administrador")
        {
            prestamos = BuscarSocioPrestamos(socioId);
            model = new PrestamosViewModel
            {
                Prestamos = prestamos,
                EsSocio = false,
                EsOperador = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Operador",
                EsAdministrador = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Administrador"
            };
            return View(model);
        }

        var idUsuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var socio = _repoSocio.SelectWhere(s => s.IdUsuario == idUsuario).FirstOrDefault();
        if (socio == null)
        {
            throw new Exception("No se encontró el socio asociado a este usuario.");
        }
        prestamos = _repoPrestamo.SelectWhere(p => p.IdSocio == socio.IdSocio).Include(p => p.OperadorEntrega).Include(p => p.OperadorRegreso).ToList();
        foreach(Prestamo prestamo in prestamos)
        {
            Console.WriteLine(prestamo.IdPrestamo);
            var ejemplar = _repoEjemplar.SelectWhere(e => e.IdEjemplar == prestamo.IdEjemplar).FirstOrDefault();
            var libro = _repoLibro.SelectWhere(l => l.IdLibro == ejemplar.IdLibro).FirstOrDefault();
            var titulo = _repoTitulo.SelectWhere(t => t.IdTitulo == libro.IdTitulo).FirstOrDefault();
            Console.WriteLine(titulo.titulo);
            prestamo.Ejemplar.Libro.Titulo.titulo = titulo.titulo;
        }
        model = new PrestamosViewModel
        {
            Prestamos = prestamos,
            EsSocio = true,
            EsOperador = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Operador",
            EsAdministrador = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Administrador"
        };
        return View(model);
    }

    public async Task<IActionResult> EntregarLibro(int idPrestamo)
    {
        try
        {
            Console.WriteLine(HttpContext.User.FindFirst(ClaimTypes.Role)?.Value);
            var prestamo = _repoPrestamo.SelectWhere(p => p.IdPrestamo == idPrestamo).Include(p => p.Socio).FirstOrDefault();
            if (prestamo == null)
            {
                return NotFound();
            }
            var idUsuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var operador = _repoOperador.SelectWhere(o => o.IdUsuario == idUsuario).FirstOrDefault();
            if(HttpContext.User.FindFirst(ClaimTypes.Role)?.Value == "Operador")
            {
                prestamo.EntregadoPorOperador = true;
            }
            else
            {
                return Forbid();
            }
            prestamo.OperadorEntrega = operador;
            _repoPrestamo.Update(prestamo);
    
            return RedirectToAction("Prestamos", "Home", new { socioId = prestamo.Socio.IdSocio });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Error al entregar el libro");
        }
    }

    public IActionResult ConfirmarRecibo(int idPrestamo)
    {
        var prestamo = _repoPrestamo.SelectWhere(p => p.IdPrestamo == idPrestamo).Include(p => p.Socio).FirstOrDefault();
        if (prestamo == null)
        {
            return NotFound();
        }
        prestamo.Recibido = true;
        prestamo.RecibidoConfirmadoPorSocio = true;
        prestamo.Salida = DateTime.Now;
        _repoPrestamo.Update(prestamo);
        return RedirectToAction("Prestamos", "Home", new { socioId = prestamo.Socio.IdSocio });
    }

    public IActionResult CancelarPrestamo(int idPrestamo)
    {
        var prestamo = _repoPrestamo.SelectWhere(p => p.IdPrestamo == idPrestamo).Include(p => p.Socio).FirstOrDefault();
        if (prestamo == null)
        {
            return NotFound();
        }
        prestamo.Cancelado = true;
        _repoPrestamo.Update(prestamo);
        return RedirectToAction("Prestamos", "Home", new { socioId = prestamo.Socio.IdSocio });
    }

    public IActionResult DevolverLibro(int idPrestamo)
    {
        var prestamo = _repoPrestamo.SelectWhere(p => p.IdPrestamo == idPrestamo).Include(p => p.Socio).FirstOrDefault();
        if (prestamo == null)
        {
            return NotFound();
        }
        prestamo.DevueltoPorSocio = true;
        _repoPrestamo.Update(prestamo);
        return RedirectToAction("Prestamos", "Home", new { socioId = prestamo.Socio.IdSocio });
    }

    public IActionResult ConfirmarDevolucion(int idPrestamo)
    {
        var prestamo = _repoPrestamo.SelectWhere(p => p.IdPrestamo == idPrestamo).Include(p => p.Socio).FirstOrDefault();
        if (prestamo == null)
        {
            return NotFound();
        }
        prestamo.DevolucionConfirmadaPorOperador = true;
        prestamo.Regreso = DateTime.Now;
        var idUsuario = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        var operador = _repoOperador.SelectWhere(o => o.IdUsuario == idUsuario).FirstOrDefault();
        prestamo.OperadorRegreso = operador;
        _repoPrestamo.Update(prestamo);
        return RedirectToAction("Prestamos", "Home", new { socioId = prestamo.Socio.IdSocio });
    }


    public List<Prestamo> BuscarSocioPrestamos(uint? socioId)
    {
        var resultado = _repoPrestamo.SelectWhere(p => p.IdSocio == socioId).Include(p => p.OperadorEntrega).Include(p => p.OperadorRegreso).ToList();
        foreach(Prestamo prestamo in resultado)
        {
            var ejemplar = _repoEjemplar.SelectWhere(e => e.IdEjemplar == prestamo.IdEjemplar).FirstOrDefault();
            var libro = _repoLibro.SelectWhere(l => l.IdLibro == ejemplar.IdLibro).FirstOrDefault();
            var titulo = _repoTitulo.SelectWhere(t => t.IdTitulo == libro.IdTitulo).FirstOrDefault();
            prestamo.Ejemplar.Libro.Titulo.titulo = titulo.titulo;
        }
        return resultado;
    }

    public IActionResult BuscarSocio(string query)
    {
        var resultado = _repoSocio.SelectWhere(s => s.Usuario.Nombre.Contains(query) || s.Usuario.Apellido.Contains(query) || s.Usuario.Email == query || s.Usuario.NombreUsuario == query).Include(s => s.Usuario).ToList();
        return View(resultado);
    }
}

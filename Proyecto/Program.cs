using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Data.Repositorios;
using Proyecto.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProyectoDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));
builder.Services.AddScoped<IRepoAutor, RepoAutor>();
builder.Services.AddScoped<IRepoEditorial, RepoEditorial>();
builder.Services.AddScoped<IRepoEjemplar, RepoEjemplar>();
builder.Services.AddScoped<IRepoLibro, RepoLibro>();
builder.Services.AddScoped<IRepoOperador, RepoOperador>();
builder.Services.AddScoped<IRepoPrestamo, RepoPrestamo>();
builder.Services.AddScoped<IRepoSocio, RepoSocio>();
builder.Services.AddScoped<IRepoTitulo, RepoTitulo>();
builder.Services.AddScoped<IRepoGenero, RepoGenero>();
builder.Services.AddScoped<IRepoUsuario, RepoUsuario>();

var options = new DbContextOptionsBuilder<ProyectoDbContext>()
    .UseMySql(connectionString, serverVersion)
    .Options;

var context = new ProyectoDbContext(options);

context.Database.EnsureCreated();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Login/Login"; // Ruta a la página de inicio de sesión
            options.LogoutPath = "/Home/Logout"; // Ruta a la acción de cierre de sesión
        });
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var repoOperador = services.GetRequiredService<IRepoOperador>();
    var repoSocio = services.GetRequiredService<IRepoSocio>();
    var repoLibro = services.GetRequiredService<IRepoLibro>();
    var repoPrestamo = services.GetRequiredService<IRepoPrestamo>();
    var repoEjemplar = services.GetRequiredService<IRepoEjemplar>();
    var repoEditorial = services.GetRequiredService<IRepoEditorial>();
    var repoAutor = services.GetRequiredService<IRepoAutor>();
    var repoTitulo = services.GetRequiredService<IRepoTitulo>();
    var repoGenero = services.GetRequiredService<IRepoGenero>();
    var repoUsuario = services.GetRequiredService<IRepoUsuario>();

    SeedData.Initialize(repoOperador, repoEjemplar, repoPrestamo, repoSocio, repoLibro, repoEditorial, repoAutor, repoTitulo, repoGenero, repoUsuario);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();

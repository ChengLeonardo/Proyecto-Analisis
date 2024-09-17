using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Data.Repositorios;
using Proyecto.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProyectoDbContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion));
builder.Services.AddScoped<IRepoAutor, RepoAutor>();
builder.Services.AddScoped<IRepoAutorTitulo, RepoAutorTitulo>();
builder.Services.AddScoped<IRepoEditorial, RepoEditorial>();
builder.Services.AddScoped<IRepoEjemplar, RepoEjemplar>();
builder.Services.AddScoped<IRepoGeneroTitulo, RepoGeneroTitulo>();
builder.Services.AddScoped<IRepoLibro, RepoLibro>();
builder.Services.AddScoped<IRepoOperador, RepoOperador>();
builder.Services.AddScoped<IRepoPrestamo, RepoPrestamo>();
builder.Services.AddScoped<IRepoSocio, RepoSocio>();
builder.Services.AddScoped<IRepoTitulo, RepoTitulo>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var repoOperador = services.GetRequiredService<IRepoOperador>();
    SeedData.Initialize(repoOperador);
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

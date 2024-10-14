<h1 align="center"> "Documentación Técnica" </h1>

## 1. Descripción del Proyecto
Este proyecto consiste en el desarrollo de un sistema de gestión de bibliotecas que permite a los usuarios realizar el préstamo y devolución de libros, gestionar catálogos y consultar el estado de los libros disponibles. El sistema está desarrollado utilizando una arquitectura web con backend en **C# (ASP.NET Core)**, frontend en **HTML, CSS y JavaScript**, y una base de datos **MySQL** para la persistencia de datos.

## 2. Arquitectura del Sistema
El sistema sigue un modelo **MVC (Model-View-Controller)**, lo cual permite la separación lógica entre la interfaz de usuario (Views), la lógica de negocio (Controllers), y la capa de acceso a datos (Models).

### 2.1 Backend
- **Lenguaje**: C# 
- **Framework**: ASP.NET Core MVC
- **Patrón de Diseño**: MVC
- **Persistencia**: Entity Framework Core (ORM) para interactuar con la base de datos MySQL.
- **Dependencias/Paquetes**: 
  - `Microsoft.EntityFrameworkCore` para la interacción con la base de datos.
  - `Swashbuckle.AspNetCore` para la generación de documentación Swagger.

### 2.2 Frontend
- **Lenguajes**: HTML5, CSS3, JavaScript
- **Frameworks y Librerías**:
  - **Bootstrap**: para el diseño responsive y componentes de interfaz.
  - **JavaScript**: utilizado para mejorar la experiencia de usuario con validaciones en el frontend y algunas interacciones dinámicas.

### 2.3 Base de Datos
- **Motor de Base de Datos**: MySQL
- **Herramienta de Modelado**: MySQL Workbench, donde se diseñaron los esquemas y relaciones de las tablas.
- **Modelo Relacional**: El sistema tiene tablas para gestionar libros, usuarios, préstamos, devoluciones, y el estado de los libros. La base de datos sigue un modelo relacional, donde las entidades clave incluyen:
  - **Libros**: Detalles de los libros disponibles en la biblioteca.
  - **Usuarios**: Información de las personas que pueden pedir prestados los libros.
  - **Préstamos y Devoluciones**: Registro de los préstamos y devoluciones de libros.

## 3. Configuraciones Importantes

### 3.1 Conexión a la Base de Datos
En el archivo `appsettings.json`, se define la cadena de conexión a la base de datos MySQL:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=biblioteca;User=root;Password=yourpassword;"
}
```
Es fundamental modificar esta cadena con los credenciales correctos del entorno de despliegue para garantizar la correcta conexión con MySQL.

### 3.2 Servicios y Dependencias
En el archivo `Startup.cs`, se configuran los servicios necesarios para el funcionamiento del sistema, como la inyección de dependencias para los controladores y la base de datos:
```csharp
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
services.AddControllersWithViews();
```

### 3.3 Swagger
Se ha configurado **Swagger** para documentar automáticamente los endpoints de la API. Esto facilita a los desarrolladores externos la interacción con la API mediante una interfaz gráfica que muestra los detalles de cada endpoint.

## 4. Herramientas Utilizadas
- **Visual Studio Code/Visual Studio**: Para la codificación del backend en C#.
- **MySQL Workbench**: Para el modelado y administración de la base de datos.
- **Postman**: Para la prueba de los endpoints del API.
- **Swagger**: Para la documentación automática de la API.
- **Git**: Para el control de versiones, junto con GitHub para el almacenamiento y la colaboración en el código.

## 5. Despliegue
El sistema puede ser desplegado en un servidor con soporte para **ASP.NET Core** y una base de datos **MySQL**. Las configuraciones de entorno deben ser actualizadas en el archivo `appsettings.json` para apuntar a las instancias correctas de base de datos en producción.

## 6. Mantenimiento y Escalabilidad
El sistema está diseñado para ser fácilmente escalable, con una separación clara de las capas (frontend, backend y base de datos). El uso de **Entity Framework** permite que el sistema maneje cambios en la base de datos de manera más eficiente, facilitando la migración de esquemas. Las futuras mejoras pueden incluir:
- Implementación de un sistema de autenticación más robusto.
- Mejora en la interfaz de usuario para mayor accesibilidad.

---

Este es un ejemplo inicial de la **Documentación Técnica**. ¿Te gustaría agregar o modificar alguna sección?
<h1 align="center"> E.T. Nº12 D.E. 1º "Libertador Gral. José de San Martín" </h1>
<p align="center">
  <img src="https://et12.edu.ar/imgs/et12.svg">
</p>

## Computación : 2024

**Asignatura**: Análisis de Sistemas

**Nombre TP**: Biblioteca Web

**Apellido y Nombre Alumno**: Leonardo Cheg, Josu Duran, Ruben Torren, Luz Ibarra, Diego Quintero, Julio Martinez, Mario Rojas

**Curso**: 5 ° 7

# Biblioteca Web 2024

_Acá va un parrafo que describa lo que es el proyecto._

## Comenzando 🚀

Clonar el repositorio github, desde Github Desktop o ejecutar en la terminal o CMD:

```
https://github.com/ChengLeonardo/Proyecto-Analisis.git
```


## Construido con 🛠️

_Las siguientes herramientas y tecnologías fueron utilizadas para crear este proyecto:_

* [.NET 8](https://dotnet.microsoft.com/es-es/download/dotnet/8.0) - Framework de desarrollo
* [ASP.NET Core](https://docs.microsoft.com/es-es/aspnet/core/) - Framework web
* [MySQL](https://www.mysql.com/) - Sistema de gestión de bases de datos
* [Visual Studio Code](https://code.visualstudio.com/) - Editor de código


## Autores ✒️


* **Leonardo Cheg** - *Desarrollo* - [Leonardo](https://github.com/ChengLeonardo)

* **Miguel Verdugues** - *Desarrollo* - [Miguel2433](https://github.com/miguel2433)

* **Josu Duran** - *Documentación* - [Magician](https://github.com/JosuGuzman)



# Manual de Usuario del Sistema de Gestión de Biblioteca

## Índice
1. [Introducción](#introducción)
2. [Requisitos del Sistema](#requisitos-del-sistema)
3. [Instalación y Configuración](#instalación-y-configuración)
4. [Funcionalidades Principales](#funcionalidades-principales)
5. [Guía de Uso](#guía-de-uso)
   - [Inicio de Sesión](#inicio-de-sesión)
   - [Préstamo de Libros](#préstamo-de-libros)
   - [Devolución de Libros](#devolución-de-libros)
6. [Preguntas Frecuentes](#preguntas-frecuentes)
7. [Soporte Técnico](#soporte-técnico)

## Introducción
Este manual tiene como objetivo guiar a los usuarios en el uso del **Sistema de Gestión de Biblioteca**. El sistema permite a los usuarios gestionar préstamos y devoluciones de libros, consultar el catálogo disponible y revisar el historial de transacciones.

## Requisitos del Sistema
Para utilizar este sistema, se deben cumplir los siguientes requisitos:
- Navegador web moderno (Chrome, Firefox, Edge).
- Conexión a internet.
- Acceso a una cuenta de usuario del sistema.

## Instalación y Configuración
1. **Descarga del Proyecto**: Clona el repositorio desde [GitHub](https://github.com/ChengLeonardo/Proyecto-Analisis).
2. **Configuración de la Base de Datos**: Asegúrate de tener una instancia de **MySQL** configurada. Edita el archivo `appsettings.json` para incluir la cadena de conexión a tu base de datos.
3. **Ejecución del Proyecto**: Usa un entorno de desarrollo como **Visual Studio** o **Visual Studio Code** para compilar y ejecutar el sistema.

## Funcionalidades Principales
El sistema ofrece las siguientes funcionalidades:
- **Gestión de usuarios**: Permite agregar, editar y eliminar usuarios del sistema.
- **Préstamo de libros**: Posibilidad de realizar préstamos y registrar devoluciones de libros.
- **Consulta de catálogos**: Ver la disponibilidad y detalles de los libros.
- **Historial de transacciones**: Visualización de préstamos pasados y devoluciones.

## Guía de Uso

### Inicio de Sesión
1. Accede a la página de inicio del sistema.
2. Introduce tus credenciales (usuario y contraseña).
3. Haz clic en "Iniciar Sesión".

### Préstamo de Libros
1. En el menú principal, selecciona la opción **Préstamos**.
2. Busca el libro deseado utilizando el buscador de catálogos.
3. Selecciona el libro y presiona el botón **Prestar**.
4. Confirma el préstamo.

### Devolución de Libros
1. En el menú principal, selecciona la opción **Devoluciones**.
2. Introduce el código del libro o búscalo en tu historial.
3. Selecciona el libro y presiona **Devolver**.

## Preguntas Frecuentes

### ¿Cómo puedo recuperar mi contraseña?
Si has olvidado tu contraseña, puedes hacer clic en el enlace "¿Olvidaste tu contraseña?" en la página de inicio de sesión. Se enviarán instrucciones a tu correo electrónico registrado.

### ¿Cómo puedo ver mi historial de préstamos?
En el menú principal, selecciona **Historial de Préstamos** para ver todos los libros que has pedido prestados y las fechas de devolución.

## Soporte Técnico
Si encuentras algún problema técnico o tienes preguntas adicionales, puedes ponerte en contacto con el equipo de soporte de las siguientes maneras:

- **Correo Electrónico**: Envíanos un mensaje a `soporte@biblioteca.com` describiendo el problema que enfrentaste. Incluye detalles como capturas de pantalla, pasos para reproducir el error, y la versión del sistema que estás utilizando.
  
- **Teléfono**: Llama al número de soporte técnico disponible: `+1 800-555-1234`. Horario de atención de lunes a viernes, de 9:00 AM a 6:00 PM.

- **Documentación y Recursos**: Consulta la sección de preguntas frecuentes y la documentación en línea para encontrar respuestas rápidas a problemas comunes. Puedes acceder a estos recursos en nuestra página web oficial.

### Reporte de Errores
Para reportar un error, sigue estos pasos:
1. Asegúrate de que el problema persiste después de reiniciar el sistema.
2. Verifica que tu navegador y el sistema estén actualizados a la última versión.
3. En caso de continuar con el error, envía un correo a soporte con la siguiente información:
   - Descripción detallada del problema.
   - Versión del sistema operativo y navegador utilizado.
   - Acciones realizadas antes de que ocurriera el problema.

Nuestro equipo técnico trabajará para resolver los problemas en el menor tiempo posible.

##
  ```json
appsettings.json configuration
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
      "DefaultConnection" : "server=localhost;user=username;password=userpass;database=5to_Biblioteca"
  }
}
```
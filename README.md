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

Este proyecto consiste en el desarrollo de un sistema de gestión de bibliotecas que permite a los usuarios realizar el préstamo y devolución de libros, gestionar catálogos y consultar el estado de los libros disponibles. El sistema está desarrollado utilizando una arquitectura web con backend en **C# (ASP.NET Core)**, frontend en **HTML, CSS y JavaScript**, y una base de datos **MySQL** para la persistencia de datos.

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



# Manual de Usuario

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

### ¿Cómo puedo ver mi historial de préstamos?
En el menú principal, selecciona **Historial de Préstamos** para ver todos los libros que has pedido prestados y las fechas de devolución.

## Soporte Técnico
Si encuentras algún problema técnico o tienes preguntas adicionales, puedes ponerte en contacto con el equipo de soporte de las siguientes maneras:

- **Documentación y Recursos**: Consulta la sección de preguntas frecuentes y la documentación en línea para encontrar respuestas rápidas a problemas comunes. Puedes acceder a estos recursos en nuestra página web oficial.


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
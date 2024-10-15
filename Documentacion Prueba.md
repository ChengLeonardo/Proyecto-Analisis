# **_Documentación de pruebas_** 

## **_Análisis de Pruebas_**

**_Registro de Libros_**

**_Funcionales_**:

+ El sistema debe permitir a los administradores añadir nuevos libros al catálogo con detalles como título, autor, ISBN, género y año de publicación.
+ El sistema debe permitir a los administradores editar los detalles de los libros existentes.
+ El sistema debe permitir a los administradores eliminar libros del catálogo.
+ El sistema debe mostrar una confirmación después de registrar, editar o eliminar un libro.

**_En proceso_**:

+ La interfaz de usuario debe ser intuitiva y permitir la entrada de datos de manera rápida y eficiente.
+ El sistema debe validar que los campos obligatorios (título, autor, ISBN) no estén vacíos.

**_No Funcionales_**:

+ La operación de registrar, editar o eliminar un libro debe completarse en menos de 2 segundos.
+ Los datos de los libros deben almacenarse de manera segura en la base de datos.

## **_Registro de Usuario_**

**_Funcionales_**:

+ El sistema debe permitir a nuevos usuarios registrarse proporcionando detalles como nombre, dirección de correo electrónico, y contraseña.
+ El sistema debe permitir a los usuarios registrados actualizar sus detalles de perfil.

      
**_En proceso_**:

+ El sistema debe permitir a los administradores eliminar usuarios.


**_No Funcionales_**:

+ La contraseña del usuario debe estar encriptada antes de almacenarse en la base de datos.
+ La interfaz de registro debe ser fácil de usar y accesible.
La disponibilidad del sistema de registro debe ser del 99.9%

## **_Búsqueda de Libros_**

**_Funcionales_**:

+ El sistema debe permitir a los usuarios buscar libros por título, autor, género o ISBN.
+ El sistema debe mostrar los resultados de búsqueda en una lista con detalles relevantes de cada libro.
+ El sistema debe permitir a los usuarios filtrar y ordenar los resultados de búsqueda.

**_No Funcionales_**:

+ La interfaz de búsqueda debe ser intuitiva y fácil de usar.
+ El sistema debe manejar correctamente las búsquedas sin resultados.
+ Los resultados de búsqueda deben ser precisos y relevantes.

## **_Registro de Préstamos y Devoluciones_**

**_Funcionales_**:

+ El sistema debe registrar la fecha de préstamo y la fecha de devolución estimada.
+ El sistema debe permitir a los usuarios registrar la devolución de libros.

**_En proceso_**:

+ El sistema debe cambiar el estado del libro a "disponible" una vez que se registre su devolución.
+ El sistema debe generar informes detallados de préstamos y devoluciones, incluyendo fechas, usuarios y libros involucrados.
+ El sistema debe permitir a los usuarios solicitar el préstamo de libros disponibles.

**_No Funcionales_**:

+ El sistema debe procesar las solicitudes de préstamo en menos de 2 segundos 
+ El sistema debe actualizar el estado del libro inmediatamente después de la devolución.
+ Los informes de préstamos y devoluciones deben generarse en menos de 5 segundos.
+ La interfaz para el registro de préstamos y devoluciones debe ser fácil de usar y accesible.

## **_Registrar un Administrador_**
**_Funcionales:_**

+ El sistema debe permitir a los administradores registrar nuevos administradores.
+ El sistema debe permitir a los administradores promover usuarios regulares a administradores.
+ El sistema debe permitir a los administradores restringir o castigar a usuarios que no devuelvan libros después de una semana del plazo establecido.

**_En proceso_**:

+ La interfaz para administrar usuarios y enviar avisos debe ser fácil de usar y eficiente.

**_No Funcionales_**:

+ La promoción de un usuario a administrador debe reflejarse en el sistema en menos de 1 segundo.
+ Los avisos de atraso deben enviarse automáticamente a las 24 horas de detectado el atraso.
+ Los datos de administración y usuario deben ser manejados con altos estándares de seguridad para prevenir accesos no autorizados.














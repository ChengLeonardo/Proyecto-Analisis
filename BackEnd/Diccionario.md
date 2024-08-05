Aquí tienes las tablas en formato Markdown:

### Tabla `Editorial`

| Nombre de la Fila | Descripción                     | Tipo de Dato | Funcionalidad                                |
|-------------------|---------------------------------|--------------|---------------------------------------------|
| `idEditorial`     | Identificador único de la editorial | INT          | Clave primaria, identifica de forma única a la editorial |
| `Editorial`       | Nombre de la editorial          | VARCHAR(45)  | Almacena el nombre de la editorial          |

### Tabla `Autor`

| Nombre de la Fila | Descripción                       | Tipo de Dato | Funcionalidad                                |
|-------------------|-----------------------------------|--------------|---------------------------------------------|
| `idAutor`         | Identificador único del autor     | INT          | Clave primaria, identifica de forma única al autor |
| `nombre`          | Nombre del autor                  | VARCHAR(45)  | Almacena el nombre del autor                |
| `apellido`        | Apellido del autor                | VARCHAR(45)  | Almacena el apellido del autor              |

### Tabla `Socio`

| Nombre de la Fila   | Descripción                       | Tipo de Dato | Funcionalidad                                |
|---------------------|-----------------------------------|--------------|---------------------------------------------|
| `idSocio`           | Identificador único del socio     | INT          | Clave primaria, identifica de forma única al socio |
| `nombre`            | Nombre del socio                  | VARCHAR(45)  | Almacena el nombre del socio                |
| `apellido`          | Apellido del socio                | VARCHAR(45)  | Almacena el apellido del socio              |
| `email`             | Correo electrónico del socio      | VARCHAR(45)  | Almacena el correo electrónico del socio    |
| `telefono`          | Teléfono del socio                | INT(10)      | Almacena el número de teléfono del socio    |
| `fechaNacimiento`   | Fecha de nacimiento del socio     | DATE         | Almacena la fecha de nacimiento del socio   |

### Tabla `Titulo`

| Nombre de la Fila | Descripción                        | Tipo de Dato | Funcionalidad                                |
|-------------------|------------------------------------|--------------|---------------------------------------------|
| `idTitulo`        | Identificador único del título     | INT          | Clave primaria, identifica de forma única al título |
| `titulo`          | Nombre del título                  | VARCHAR(50)  | Almacena el nombre del título               |

### Tabla `Libro`

| Nombre de la Fila | Descripción                        | Tipo de Dato | Funcionalidad                                |
|-------------------|------------------------------------|--------------|---------------------------------------------|
| `idLibro`         | Identificador único del libro      | INT          | Clave primaria, identifica de forma única al libro |
| `idEditorial`     | Identificador de la editorial      | INT          | Clave foránea, referencia a la tabla `Editorial` |
| `idTitulo`        | Identificador del título           | INT          | Clave foránea, referencia a la tabla `Titulo` |
| `ISBN`            | Código ISBN del libro              | VARCHAR(30)  | Almacena el código ISBN del libro            |

### Tabla `AutorTitulo`

| Nombre de la Fila | Descripción                            | Tipo de Dato | Funcionalidad                                |
|-------------------|----------------------------------------|--------------|---------------------------------------------|
| `idAutor`         | Identificador del autor                | INT          | Clave foránea, referencia a la tabla `Autor` |
| `idTitulo`        | Identificador del título               | INT          | Clave foránea, referencia a la tabla `Titulo` |

### Tabla `Ejemplar`

| Nombre de la Fila | Descripción                           | Tipo de Dato     | Funcionalidad                                |
|-------------------|---------------------------------------|------------------|---------------------------------------------|
| `idEjemplar`      | Identificador único del ejemplar      | INT UNSIGNED     | Clave primaria, identifica de forma única al ejemplar |
| `idLibro`         | Identificador del libro               | INT              | Clave foránea, referencia a la tabla `Libro` |
| `nroEjemplar`     | Número de ejemplar                    | INT(3) UNSIGNED  | Almacena el número del ejemplar             |

### Tabla `Operador`

| Nombre de la Fila | Descripción                        | Tipo de Dato | Funcionalidad                                |
|-------------------|------------------------------------|--------------|---------------------------------------------|
| `idOperador`      | Identificador único del operador   | INT          | Clave primaria, identifica de forma única al operador |
| `nombre`          | Nombre del operador                | VARCHAR(45)  | Almacena el nombre del operador             |
| `apellido`        | Apellido del operador              | VARCHAR(45)  | Almacena el apellido del operador           |
| `email`           | Correo electrónico del operador    | VARCHAR(100) | Almacena el correo electrónico del operador |
| `usuario`         | Nombre de usuario del operador     | VARCHAR(45)  | Almacena el nombre de usuario del operador  |
| `pass`            | Contraseña del operador            | CHAR(64)     | Almacena la contraseña del operador         |

### Tabla `Prestamo`

| Nombre de la Fila      | Descripción                          | Tipo de Dato     | Funcionalidad                                |
|------------------------|--------------------------------------|------------------|---------------------------------------------|
| `idPrestamo`           | Identificador único del préstamo     | INT              | Clave primaria, identifica de forma única al préstamo |
| `idEjemplar`           | Identificador del ejemplar           | INT UNSIGNED     | Clave foránea, referencia a la tabla `Ejemplar` |
| `idSocio`              | Identificador del socio              | INT              | Clave foránea, referencia a la tabla `Socio` |
| `salida`               | Fecha y hora de salida               | DATETIME         | Almacena la fecha y hora de salida del préstamo |
| `regreso`              | Fecha y hora de regreso              | DATETIME         | Almacena la fecha y hora de regreso del préstamo |
| `idOperadorEntrega`    | Identificador del operador que entregó | INT              | Clave foránea, referencia a la tabla `Operador` |
| `idOperadorRegreso`    | Identificador del operador que recibió | INT              | Clave foránea, referencia a la tabla `Operador` |

### Tabla `Genero`

| Nombre de la Fila | Descripción                        | Tipo de Dato | Funcionalidad                                |
|-------------------|------------------------------------|--------------|---------------------------------------------|
| `idGenero`        | Identificador único del género     | INT          | Clave primaria, identifica de forma única al género |
| `genero`          | Nombre del género                  | VARCHAR(30)  | Almacena el nombre del género               |

### Tabla `GeneroTitulo`

| Nombre de la Fila | Descripción                            | Tipo de Dato | Funcionalidad                                |
|-------------------|----------------------------------------|--------------|---------------------------------------------|
| `idGenero`        | Identificador del género               | INT          | Clave foránea, referencia a la tabla `Genero` |
| `idTitulo`        | Identificador del título               | INT          | Clave foránea, referencia a la tabla `Titulo` |

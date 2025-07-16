# BibliotecaASP.NET

**¡Bienvenido a BibliotecaASP.NET!**  
Aplicación web construida con ASP.NET Core MVC para gestionar una pequeña biblioteca.  
Demuestra:  
- Modelado de datos con Entity Framework Core  
- Operaciones CRUD para **Autores** y **Libros**  
- Ruteo MVC y validación de datos (cliente/servidor)  
- Interfaz responsiva con Bootstrap 5 y Bootstrap Icons  

---

## 📦 Instalación y Ejecución

Sigue estos pasos para levantar la aplicación en tu máquina:

### 1. Clonar el repositorio

`git clone https://github.com/matibernal/BibliotecaASP.NET.git`<br> 
`cd BibliotecaASP.NET`

### 2. Configurar la Cadena de Conexión

Edita appsettings.json y ajusta ConnectionStrings:DefaultConnection.

Ejemplo usando LocalDB:

*JSON*

`{`<br>  
  `"ConnectionStrings": {`<br>  
    `"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BibliotecaDb;Trusted_Connection=True;"`<br>
  `}`<br>
`}`

### 3. Aplicar Migraciones y Crear la Base de Datos

Usa las herramientas de Entity Framework Core para aplicar las migraciones pendientes y crear el esquema de tu base de datos:

`dotnet tool restore`<br>  
`dotnet ef database update`

### 4. Ejecutar la Aplicación

Finalmente, ejecuta la aplicación:

*Bash*

`dotnet run`

*Una vez que la aplicación se inicie, abre tu navegador y navega a https://localhost:7260 (o al puerto indicado en tu consola).*

✅ Cumplimiento de Requisitos
Este proyecto cumple con una serie de requisitos comunes para aplicaciones web, como se detalla a continuación:

Requisito	Implementación:

1. Modelos de Datos	Author con propiedades para Name, Surname, DateOfBirth, y una colección de Books.<br>Book con propiedades para Title, Summary, PublicationDate, AuthorId, y navegación a Author.
2. CRUD Completo	AuthorsController y BooksController implementan las acciones Index, Details, Create, Edit, y Delete.
3. Las vistas están fuertemente tipadas e incluyen validación tanto del lado del servidor como del cliente.
4. Entity Framework Core	Utiliza ApplicationDbContext con DbSet<Author> y DbSet<Book>.<br>Las migraciones de la base de datos se aplican automáticamente al iniciar la aplicación usando Database.Migrate().
5. Ruteo MVC	Rutas convencionales definidas en Program.cs ({controller=Home}/{action=Index}/{id?}).Enlaces de navegación para Inicio, Autores y Libros están presentes en _Layout.cshtml.
6. Validación de Datos	Emplea Data Annotations ([Required], [StringLength], [DataType(DataType.Date)]) con mensajes de error personalizados.@Html.ValidationSummary y _ValidationScriptsPartial se utilizan para la validación del lado del cliente.
7. Interfaz y Diseño	Construido con Bootstrap 5 y Bootstrap Icons para un diseño responsivo y moderno.
8. Incluye tarjetas estilizadas, tablas (table-striped, table-hover, table-sm), y desplazamiento interno para listas largas.
9. Ordenamiento Dinámico:	Las páginas Index para Autores y Libros incluyen enlaces de ordenamiento en los encabezados de las tablas, permitiendo a los usuarios alternar entre orden ascendente/descendente (gestionado a través de sortOrder en el controlador y ViewData).
10. Usabilidad Extra:	Se aplica desplazamiento interno (max-height + overflow-y: auto) a las tablas de Autores y Libros, así como a la lista de libros para un autor específico.
11. Se incluyen campos adicionales como "Nombre", "Apellido" y "Fecha de nacimiento" en el modelo de Autor para una mejor representación de los datos.

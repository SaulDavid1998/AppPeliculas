# Aplicacion web de peliculas

Aplicación web para gestionar una lista de películas, donde se pueden visualizar detalles completos de cada una, incluyendo título, año de lanzamiento, género, sinopsis y el estudio de produccion. Los usuarios tienen la opción de agregarlas o eliminarlas de su lista personal de **Favoritos** para un acceso rápido posterior.

La aplicación cuenta con un sistema de autenticación que permite crear una cuenta de usuario. Una vez registrado e iniciado sesión, el usuario todavia no  obtiene acceso a la sección **Admin**, donde es posible editar información de la pelicula seleccionada. Esto se debe a que, para acceder a esa parte de la aplicacion, hace falta que el usuario tenga el rol "Administrador", cosa que el usuario creado no tiene, pero se le puede dar en la seccion **Manejar Usuario** dentro de la seccion Admin.
Para poder entrar a la seccion Admin la aplicacion tiene un **usuario por defecto** con el rol de Administrador, las credenciales de este usuario son las siguientes:
- Nombre de Usuario: Administrador
- Contraseña: Admin123

La sección **Favoritos**, visible en la barra de navegación, muestra un contador en tiempo real con la cantidad de películas marcadas como favoritas. Esta sección solo aparece cuando existe al menos una película seleccionada, y desaparece automáticamente si no hay peliculas marcadas como favoritas. El botón para agregar o quitar una película de Favoritos se encuentra en la ventana **Detalles** de cada película, lo que permite una gestión rápida y sencilla de la lista personal.

Entre sus características destacan:

- Interfaz moderna y responsiva gracias a **Bootstrap**.

- Persistencia de datos mediante **Entity Framework Core** y **SQL Server**.

- Validaciones para evitar registros incompletos o datos no validos.

- Posibilidad de filtrar películas por genero o estudio.

**Nota**: El proyecto fue hecho con Ef Core usando localDB. Si se descarga el repositorio de GitHub hay que ejecutar el comando Update-Database en la consola del administrador de paquetes
para crear la base de datos local. De lo contrario la aplicacion mostrara un error y no se ejecutara.

<img width="700" height="700" alt="image" src="https://github.com/user-attachments/assets/2f0a2cc6-0fe1-40f2-9d87-4bb05e8ccf58" />

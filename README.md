# Aplicacion web de peliculas

Aplicación web para gestionar una lista de películas, donde se pueden visualizar detalles completos de cada una, incluyendo título, año de lanzamiento, género, sinopsis y el estudio de produccion. Los usuarios tienen la opción de agregarlas o eliminarlas de su lista personal de **Favoritos** para un acceso rápido posterior.

La aplicación cuenta con un sistema de autenticación que permite crear una cuenta de usuario. Una vez registrado e iniciado sesión, el usuario obtiene acceso a la sección **Admin**, donde es posible editar información de la pelicula seleccionada.

La sección **Favoritos**, visible en la barra de navegación, muestra un contador en tiempo real con la cantidad de películas marcadas como favoritas. Esta sección solo aparece cuando existe al menos una película seleccionada, y desaparece automáticamente si no hay peliculas marcadas como favoritas. El botón para agregar o quitar una película de Favoritos se encuentra en la ventana **Detalles** de cada película, lo que permite una gestión rápida y sencilla de la lista personal.

Entre sus características destacan:

-Interfaz moderna y responsiva gracias a **Bootstrap**.

-Persistencia de datos mediante **Entity Framework Core** y **SQL Server**.

-Validaciones para evitar registros incompletos o datos no validos.

-Posibilidad de filtrar películas por genero o estudio.

# Primera entrega:

**Propuesta Web HADA**

Nombre repositorio GitHub : WebSeries_L17

Nombres miembros grupo

Vicent Caravaca Rostoll (coordinador)

Oliver Vincent Rice

José María Fernández Gil

Turno

Lunes 17-19

**Descripción**

Web corporativa orientada a la venta y alquiler de series en streaming. Esta aplicación web dispondrá de un amplio catálogo de series para ver desde cualquier dispositivo multimedia con acceso a Internet.

**Parte pública:**

- Ofrecer el login -> permitirá al usuario registrarse en la web, o si ya lo está acceder a la parte privada de la misma.

- Mostrar todas las series -> mostrar todas las series sin tener en cuenta su categoría.

- Filtro para las series -> permite filtrar las series de la página web por categorías.

- Mostrar las series una vez filtradas -> una vez que se han filtrado las series se podrían ver todas ellas.

- Buscar una serie -> buscar una serie en concreto en el buscador.

- Ver las series detalladamente -> se puede entrar a ver detalladamente una serie (una breve descripción y su tráiler).

- Añadir series a la cesta -> se pueden añadir series a la cesta, pero solo se podrán comprar si inicias sesión en la web.

Listado EN Pública:

- ENUsuario -> los posibles clientes con toda su información.

- ENSerie -> las series a vender (o alquilar) con todos sus atributos.

- ENCesta -> relación entre ENUsuario y ENLineaCesta.

- ENLineaCesta -> conjunto de series asociadas a una cesta con el método de compra correspondiente (compra o alquiler) de cada una de ellas.

**Parte privada:**

- Comprar las series -> comprar las series que hay en la cesta.

- Añadir series a pendientes -> se podrán añadir series que te interesen a una lista para poder adquirirlas en otro momento.

- Ver mis series -> se podrá ver la lista de series que tiene el usuario para poder reproducirlas cuando se desee.

- Modificar tu perfil de usuario.

Listado EN Privada:

- ENSeriesPendientes -> mostrar series que tengo en la lista de pendientes.

- ENPedido -> registrar el pedido de un usuario.

- ENLineaPedido -> conjunto de series asociadas a un pedido con su precio.

- ENMisSeries -> lista de series que tiene el usuario a su disposición.

- ENUsuario -> los posibles clientes con toda su información.

- ENSerie -> las series a vender (o alquilar) con todos sus atributos.

- ENCesta -> relación entre ENUsuario y ENLineaCesta.

- ENLineaCesta -> conjunto de series asociadas a una cesta con el método de compra correspondiente (compra o alquiler) de cada una de ellas.

**Posibles mejoras:**

- Internacionalización

- Enlace con redes sociales

- Garantizar la accesibilidad del sitio web

# Segunda entrega:

El esquema entidad relación se llama "ERD en WebSeries.png" y está en el directorio raíz del repositorio

# Tercera entrega:

- Base de datos creada y funcional completa con las siguientes tablas:
  - Cestas
  - LineasCesta
  - LineasPedido
  - MisSeries
  - Pedido
  - Series(esta tabla esta rellena con las series que usaremos para la web)
  - SeriesPendientes
  - Usuarios
 - Todos los CAD y los EN están terminados
 - Página maestra creada con asp:Menú(el menú cambia dependiendo de si estás logueado o no)
 - Todas las interfaces están creadas:
    - Biblioteca
   - Cesta
   - CrearUsuario(con controles de validación ASPnet)
   - Info
   - InfoSerie
   - Inicio(con controles de validación ASPnet)
    - MisSeries
    - Modificar Usuario(con controles de validación ASPnet)
    - Pedido
    - Salir
    - SeriesPendientes
    
# Cuarta entrega:
    
**Cambios respecto a la propuesta inicial:**

- Eliminamos la Internacionalización, ya que utilizamos muchos textos y no se podrían traducir las descripciones de las series.

- Añadimos la interfaz Contrasena.aspx para poder recuperar la contraseña de un usuario a partir de su email.

- Añadimos la interfaz EmailNuevoUsuario.aspx que enviará a los nuevos usuarios un correo de bienvenida.

- Añadimos la interfaz Trailer.aspx para poder ver los trailers de las series desde dentro de la web.

- En la página de información añadimos un formulario de contacto que al enviarse envía un e-mail de confirmación de recepción con la copia del mensaje.

- Se modifica la tabla Cesta para indicar que la columna usuario puede ser nula.

- Hemos añadido la columna rol a la tabla usuarios para diferenciar usuarios de la aplicación y administradores.

- Los usuarios administradores pueden listar y modificar todos los usuarios de la aplicación, así como crear nuevas series y visualizar el número de páginas vistas en la aplicación.

**Problemas que han surgido:**

- En general la sincronización entre los componentes del grupo ha sido muy buena.

- Cada uno ha trabajado en su rama e incluso en ocasiones hemos utilizado la rama de un compañero para ver una funcionalidad determinada que aún no estaba lista para subir a la rama develop. 

- Inicialmente no subimos bien todos los ficheros a Git y el proyecto no se desplegaba correctamente cuando hacíamos la mezcla en nuestras ramas.

- Tuvimos que volver a crear el proyecto, copiar todos los ficheros y de esta forma el proyecto se desplegaba de forma correcta y todos podíamos trabajar en nuestra rama.

- El problema descrito anteriormente ocurría porque VisualStudio no generaba y copiaba los ficheros roselyn.exe que se necesitaba para la correcta ejecución.

- También nos encontramos problemas con los ficheros de proyecto .csproj ya que daban conflictos. En algunas ocasiones debíamos añadir los ficheros manualmente con Agregar -> Elemento existente.

- Otros problemas que tuvimos fueron que los ficheros .aspx.cs de otros miembro del grupo no se compilaban en nuestra rama y daban error de que faltaban manejadores de eventos, por lo que debíamos limpiar y recompilar.

- Git al principio nos dió problemas con los ficheros dll y pdb, pero finalmente con un buen .gitignore y la experiencia obtenida, funcionamos de una forma efectiva.

**Si el usuario es de tipo administrador tendrá los siguientes privilegios:**

- Puede añadir series

- Puede ver y modificar usuarios

A continuació te dejamos un usuario normal y uno administrador:

Usuario y contraseña de un usuario

email del usuario: vicentcr991@gmail.com

contraseña del usuario: Vicent1234

Email del usuario con rol administrador:

email: vicentcr99@gmail.com

Contraseña:Vicent1234

**Tareas hechas por cada miembro del grupo:**

| Nombre | Tareas |
| - | - |
| Vicent Caravaca | CADSerie, CADUsuario, ENSerie, ENUsuario, Tablas Series y Usuarios en la BBDD. Contrasena.aspx, CrearUsuario.aspx, EmailNuevoUsuario.aspx, InfoSerie.aspx, Inicio.aspx, ModificarUsuario.aspx, Salir.aspx, Trailer.aspx |
| José María Fernández Gil | ENMisSeries, CADMisSeries, ENCesta, CADCesta, ENLineaCesta, CADLineaCesta. Tablas misseries, cesta y lineacesta en BBDD. Página maestra con asp:menu,, MisSeries.aspx, Cesta.aspx con cookies y/o sesión, TramitarPedido.aspx, Info.aspx, Admin.aspx, ListarUsuarios.aspx, CrearSerie.aspx |
| Oliver Rice |  CADSeriesPendientes, ENSeriesPendientes, CADPedido, ENPedido, Tablas SeriesPendientes y Pedidos en la BBDD. misPedidos.aspx, SeriesPendientes.aspx, Biblioteca.aspx, Pedido.aspx | 

**La presentación se llama "Presentación SeriesPlus HADA.mp4" y está en el directorio raíz del repositorio dentro del comprimido "Presentación SeriesPlus HADA.rar"**

**Hemos subido un zip con los archivos de la BBDD por si tuvieras algun problema con la BBDD**


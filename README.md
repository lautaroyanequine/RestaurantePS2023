# Menú Digital para Restaurante

Este proyecto es el resultado de un trabajo de la materia Proyecto de Software de 3eraño.
Tiene como objetivo desarrollar un sistema integral de menú digital para un restaurante El enfoque principal es reemplazar la carta impresa tradicional con una aplicación web interactiva que no solo muestre el menú, sino que también permita a los clientes realizar pedidos de manera eficiente.

## Características


### Backend

El backend se desarrolló en C# utilizando .NET 6 y se implementó como una API . Siguiendo el principio de arquitectura monolitica y  hexagonal , se dividió en tres capas: Infraestructura, Aplicación y Dominio. 
Se emplearon patrones de diseño como CQRS para facilitar la comunicación con la base de datos y se aplicó la inyección de dependencias para gestionar las relaciones entre los componentes.
Con el fin de respetar lo mas posible los principios SOLID.
La persistencia de datos se logró mediante una base de datos SQL Server. Esta base de datos fue creada utilizando Entity Framework con el enfoque Code First, lo que permitió un modelado eficiente de los datos y una integración perfecta con el dominio de la aplicación.

### Frontend

El frontend de la aplicación se construyó utilizando tecnologías web estándar, incluyendo HTML, CSS y JavaScript puro. La estructura modular del código garantiza un flujo de trabajo organizado y escalable. Se presta especial atención a la interfaz de usuario para ofrecer una experiencia intuitiva y atractiva.



### Comunicación

La comunicación fluida entre el frontend y el backend se estableció a través de APIs. Estas APIs fueron documentadas utilizando OpenAPI para proporcionar una comprensión clara y sencilla de los puntos de entrada y salida.

## Repositorio y Uso

Este repositorio contiene todo el código fuente y los archivos necesarios para el menú digital del restaurante.

## Resultados

Puedes explorar el menú digital implementado en el siguiente enlace: https://restaurantelaff.000webhostapp.com/

Ten en cuenta que el proyecto se encuentra distribuido en diferentes hostings gratuitos para la base de datos, el backend y el frontend, lo que puede llevar a ciertas limitaciones de rendimiento. Si deseas experimentar con el proyecto, clonar el repositorio es una opción recomendada para una experiencia más completa.

El resultado final es un menú digital robusto y moderno que mejora la experiencia del cliente y ayuda al restaurante a adaptarse a las demandas cambiantes del mercado. Este proyecto fue una emocionante oportunidad para aplicar habilidades en desarrollo web, diseño de arquitectura y gestión de bases de datos.

¡Gracias por explorar este proyecto!

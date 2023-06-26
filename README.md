# Photoexpress.api

Se realizó en visual studio 2022

Se utilizaron los siguintes patrones:
- Patron Mediador con MediaTR
- Patron repository
- CQRS

  
Para el anejo de excepciones y mensajes de error se creo un Middleware que captura las excepciones lanzadas controladamente y muestra los mensjaes a los usuarios y ara las excepciones no controladas se guarda a un log la información y se envia a los usuarios un mensaje generico amigable

Las validaciones de los campos se realizó por medio de FluentValidation

En el siguiente enlace se puede ver el funcionamiento d ela aplicación: https://1drv.ms/v/s!AqwAZj3E1Hddi9YN70qCf6JvM88Quw?e=3h4K5x 

# ProyectoDemoCQRS

Contenido del proyecto

Web Api rest en con .Net core 6 (actualmente .Net 6) como backend y Blazor wasm como cliente (front-end)
está desarrollado para la implementación de desarrollar apliaciones que puedan cubrir la necesidad de usar este patrón de diseño CQRS y mediatR
haciendo uso de una arquitectura similar a la lo que se describe como una arquitectura limpia (ojo son mis consideraciones de como bajo mis necesidades lo estoy implementando, un poco principios de Onion y DDD).Intentando hacer uso de algunos principios SOLID para su dicha implementación, así como el patrón repositoio para integrar un mejor apoyo de los commands y queryes.

Dato: ya contiene una carpeta de migración con algunos datos de prueba en el modelbuilder, por lo que solo se requeriria hacer un UPDATE-DATABASE desde la linea de comandos hacia la capa de persistencia. Cambiando de ante mano la cade de conección que se encuentra en la web api en el archivo de appsettings.json

![image](https://user-images.githubusercontent.com/49702705/182452269-b2aa2924-5b72-4ac9-9edc-59c97fe913ef.png)

https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures

paquetes nuggets.
Back-end
Layer Core/Application
Se hace uso de FluentValidation.DependencyInjectionExtensions Version="11.1.0" 
se hace uso de MediatR.Extensions.Microsoft.DependencyInjection" Version="10.0.1"

Layer Infrastructure/Infrastructure.Persistence 
Se hace uso de Microsoft.EntityFrameworkCore Version="6.0.7"
Se hace uso de Microsoft.EntityFrameworkCore.SqlServer Version="6.0.7" 
Se hace uso de Microsoft.EntityFrameworkCore.Tools Version="6.0.7"


Front-End

Se hace uso de FluentValidation.DependencyInjectionExtensions Version="11.1.0" 

 Se hace uso de Microsoft.Extensions.Http" Version="6.0.0" 


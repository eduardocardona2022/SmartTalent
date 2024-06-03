# SmartTalent

PRUEBA TÉCNICA PARA DESARROLLADOR BACK END

Definición

La siguiente es la especificación, en formato de historia de usuario, de la necesidad
planteada por un cliente, a la cual usted deberá brindar solución con el desarrollo de APIs
con el lenguaje de programación C#. En caso de no dominar el lenguaje, puede utilizar su
lenguaje de programación de preferencia.

Requisitos para la entrega

● La aplicación debe ser entregada, desplegada y usable.
● Se debe entregar el código fuente por medio del repositorio de su preferencia.
● Podrá usar cualquier motor de bases de datos para el almacenamiento.


Historias de usuario.
Desarrolle las siguientes historias de usuario.

Nombre Administracion de alojamiento hoteles locales
Descripción Yo como agencia de viajes deseo crear un hotel en mi lista
de hoteles preferidos, con el fin obtener una comisión más
alta.

Criterios de aceptación Dado que yo como agente de viajes inicie sesión en mi
plataforma de viajes y desee gestionar un hotel, entonces:
● El sistema deberá permitir crear un nuevo hotel
● El sistema deberá permitir asignar al hotel cada una
de las habitaciones disponibles para reserva
● El sistema deberá permitir modificar los valores de de
cada habitación
● El sistema deberá permitir modificar los valores de
cada hotel
● El sistema me deberá permitir habilitar o deshabilitar
cada uno de los hoteles
● El sistema me deberá permitir habilitar o deshabilitar
cada una de las habitaciones del hotel
Dado que yo como agente de viajes inicie sesión en mi
plataforma de viajes y desee ver las reservas de hoteles,
entonces
● El sistema deberá listar cada una de las reservas
realizadas en mis hoteles
● El sistema deberá permitir ver el detalle de cada una
de las reservas realizadas
Observaciones ● Cada habitación deberá permitir registrar el costo
base, impuestos y tipo de habitación.
● Cada habitación deberá permitir registrar la ubicación
en que se encuentra




Nombre Reserva de hoteles
Descripción Yo como viajero deseo reservar un hotel en la plataforma
de viajes de mi preferencia, con el fin de obtener un
alojamiento
Criterios de aceptación Dado que yo como viajero esté en el buscador de hoteles,
entonces:
● El sistema me deberá dar la opción de buscar por:
fecha de entrada al alojamiento, fecha de salida del
alojamiento, cantidad de personas que se alojarán y
ciudad de destino.
Dado que yo como viajero entre al sitio de viajes y realice
una búsqueda de hoteles, entonces:
● El sistema me deberá permitir elegir una habitación del
hotel de mi preferencia
Dado que yo como viajero seleccione mi habitación de
preferencia, entonces:
● El sistema me deberá desplegar un formulario de
reserva para ingresar los datos de los huéspedes
● El sistema deberá permitir realizar la reserva de la
habitación.
● El sistema me deberá notificar la reserva por medio de
correo electrónico.
Observaciones Los datos de cada pasajero deben ser:
● Nombres y apellidos
● Fecha de nacimiento
● Género
● Tipo de documento
● Número de documento
● Email
● Teléfono de contacto
La reserva deberá asociar un contacto de emergencia, el
cual debe contener:
● Nombres completos
● Teléfono de contacto



Se valorará como un plus las siguientes especificaciones (los cuales son opcionales):
● Implemente patrones de diseño de software para la elaboración de las soluciones.
● Uso de arquitectura orientada al dominio
● Uso de clean code
Si tiene dudas no dude en expresarlas. ¡Exitos


Cosas a tener en cuenta.
Base de datos
Para utilizar este aplicativo hay que crear una base de datos llamada Hoteldb y luego crear las siguientes tablas en ese orden y luego cambiar en el archivo appsettings.json cambiar ConnectionStrings, en este proyecto se utilizo el patron singleton.

Eduardo Cardona Acevedo (edwarcardona@hotmail.com) @2024 - Medellin - Colombia

CREATE TABLE [dbo].[Passenger] (
    [PassengerID]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]          NVARCHAR (100) NOT NULL,
    [LastName]           NVARCHAR (100) NOT NULL,
    [DateBirth]          DATE           NOT NULL,
    [Gender]             CHAR (1)       NOT NULL,
    [DocumentType]       NVARCHAR (50)  NOT NULL,
    [DocumentNumber]     NVARCHAR (50)  NOT NULL,
    [Email]              NVARCHAR (100) NULL,
    [ContactPhone]       NVARCHAR (15)  NULL,
    [ContactName]        NVARCHAR (100) NULL,
    [ContactPhoneNumber] NVARCHAR (15)  NULL,
    PRIMARY KEY CLUSTERED ([PassengerID] ASC),
    UNIQUE NONCLUSTERED ([DocumentNumber] ASC),
    CHECK ([Gender]='F' OR [Gender]='M')
);



CREATE TABLE [dbo].[Reservation] (
    [Id]              INT           NOT NULL,
    [HotelId]         INT           NOT NULL,
    [RoomId]          INT           NOT NULL,
    [StartDate]       DATETIME      NOT NULL,
    [DateEnd]         DATETIME      NOT NULL,
    [PassengerId]     INT           NOT NULL,
    [NumberOfPeople]  INT           NOT NULL,
    [DestinationCity] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Hotel] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Location]  NVARCHAR (100) NOT NULL,
    [IsEnabled] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Room] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Type]      NVARCHAR (100)  NOT NULL,
    [BaseCost]  DECIMAL (18, 2) NOT NULL,
    [Tax]       DECIMAL (18, 2) NOT NULL,
    [Location]  NVARCHAR (255)  NOT NULL,
    [HotelId]   INT             NULL,
    [IsEnabled] BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([HotelId]) REFERENCES [dbo].[Hotel] ([Id])
);


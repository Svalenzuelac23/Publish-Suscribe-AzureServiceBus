using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Publish.AzureServiceBus.Bus;
using Publish.AzureServiceBus.DTOs;
using Publish.AzureServiceBus.Mapper;
using Publish.AzureServiceBus.Models;
using Publish.AzureServiceBus.Repositories;
using Publish.AzureServiceBus.Repositories.Data;
using System;
using System.Linq;

namespace Publish.AzureServiceBus
{
    class Program
    {
        private static readonly string BusOptions = "Bus";
        static void Main(string[] args)
        {
            //ACA ESTAMOS CREANDO NUESTRO SERVICIO DE CONFIGURACION
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //CREAMOS EL CONTENEDOR DE DEPENDENCIAS, ACA REGISTRAREMOS LAS INSTANCIAS DE NUESTRAS DEPENDENCIAS
            var services = new ServiceCollection();
            services.AddAutoMapper(config =>
            {
                config.AddProfile<MapperProfile>();
            });
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<ISalesOrderRepository, SalesOrderRepository>();
            services.Configure<BusOptions>(configuration.GetSection(BusOptions));
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration["ConnectionStrings"]);
            });
            var serviceProvider = services.BuildServiceProvider(); //LEVANTAMOS EL PROVEEDOR DE DEPENDCIAS CON LAS INSTANCIAS EN MEMORIA

            //SOLICITAR QUE ID DE ORDEN QUIERO OBTENER DE MI BASE DE DATOS
            Console.WriteLine("Digite el numero de orden a publicar, luego presione la tecla enter.");
            var input = Console.ReadLine();

            //OBTENER MI ORDEN SEGUN EL ID QUE DIGITE
            var repository = serviceProvider.GetService<ISalesOrderRepository>(); //ACA PEDIMOS AL PROVEEDOR DE SERVICIOS, UNA INSTANCIA DE NUESTRO SERVICIO
            SalesOrderHeader orden = repository.Get(Int32.Parse(input)).Result;

            //MAPPER EL OBJETO AL TIPO FACTURA QUE SE DEBE DE ENVIAR AL BUS
            var mapper = serviceProvider.GetService<IMapper>();
            InvoiceHeaderRequest invoice = mapper.Map<InvoiceHeaderRequest>(orden);

            //PUBLICAR UN MENSAJE EN AZURE SERVICE BUS
            var eventBus = serviceProvider.GetService<IEventBus>();
            var result = eventBus.PublishMessage(invoice).Result;

            Console.WriteLine($"Cantidad de filas {orden.Details.Count()}");
            Console.WriteLine($"Mensaje Exito : {result}");
        }
    }
}

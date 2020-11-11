using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Suscribe.AzureServiceBus.Bus;
using System;

namespace Suscribe.AzureServiceBus
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
            services.AddScoped<ISubscribeInvoiceError, SubscribeInvoiceError>();            
            services.Configure<BusOptions>(configuration.GetSection(BusOptions));           
            var serviceProvider = services.BuildServiceProvider(); //LEVANTAMOS EL PROVEEDOR DE DEPENDCIAS CON LAS INSTANCIAS EN MEMORIA

            //SOLICITAR QUE ID DE ORDEN QUIERO OBTENER DE MI BASE DE DATOS
            Console.WriteLine("Presione enter para salir...");
            //Console.ReadKey();
            

            //PUBLICAR UN MENSAJE EN AZURE SERVICE BUS
            var subBus = serviceProvider.GetService<ISubscribeInvoiceError>();
            subBus.Process();

            //Console.WriteLine($"Cantidad de filas {orden.Details.Count()}");
            //Console.WriteLine($"Mensaje Exito : {result}");

            Console.ReadKey();
        }
    }
}

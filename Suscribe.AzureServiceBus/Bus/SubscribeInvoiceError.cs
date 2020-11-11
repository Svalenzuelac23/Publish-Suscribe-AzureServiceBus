using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Suscribe.AzureServiceBus.Bus
{
    public class SubscribeInvoiceError : ISubscribeInvoiceError
    {
        private readonly BusOptions _options;
        private readonly SubscriptionClient _subscriptionClient;       

        public SubscribeInvoiceError(
            IOptions<BusOptions> options           
            )
        {
            _options = options.Value;
            _subscriptionClient = new SubscriptionClient(_options.Cn, _options.Topic, _options.SubscriptionErrors);          
        }

        public Task CloseSuscribe()
        {
            throw new NotImplementedException();
        }
        public async Task Process()
        {
            await Task.Run(() =>
            {
                //CONFIGURAMOS NUSETRO MANEJO DE EVENTOS DE MENSAJES
                MessageHandlerOptions messageopt =
               new MessageHandlerOptions(ProcessError)
               {
                   AutoComplete = false,
                   MaxConcurrentCalls = 1
               };

                //REGISTRAMOS CUAL CLASE SERA LA ENCARGADA DE RECIBIR LOS MENSAJES EN LA COLA Y LE PASAMOS LA CONFIGURACION AL CLIENTE
                _subscriptionClient.RegisterMessageHandler(ConsumeMessage, messageopt);
            });
        }
        private Task ProcessError(ExceptionReceivedEventArgs arg)
        {
            //SI AL PROCESAR UN MENSAJE DE LA COLA ESTE FALLA, ENTRARA A ESTE PROCESO EL CUAL SE ENCARGA DE DARLE ALGUN MANEJO A LAS FALLAS
            var contextError = arg.ExceptionReceivedContext;
            return Task.CompletedTask;
        }
        private async Task ConsumeMessage(Message message, CancellationToken token)
        {
            //ESTE ES PROCESO QUE SE ENCARGA DE RECIBIR Y PROCESAR LOS MENSAJES EN LA COLA
            var path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;            
            string data = Encoding.UTF8.GetString(message.Body);

            using (StreamWriter writer = new StreamWriter($@"{path}\Errors\Errors.txt", append: true))
            {
                writer.WriteLine(message.MessageId);
            }

            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }
    }
}

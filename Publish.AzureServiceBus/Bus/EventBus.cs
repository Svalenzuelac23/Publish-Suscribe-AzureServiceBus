using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Publish.AzureServiceBus.DTOs;
using System.Text;
using System.Threading.Tasks;

namespace Publish.AzureServiceBus.Bus
{
    public class EventBus : IEventBus
    {
        private readonly BusOptions options;

        public EventBus(IOptions<BusOptions> options)
        {
            this.options = options.Value;
        }
        public async Task<bool> PublishMessage(InvoiceHeaderRequest request)
        {
            string data = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });
            Message message = new Message(Encoding.UTF8.GetBytes(data));
            TopicClient client = new TopicClient(options.Cn, options.Topic);

            await client.SendAsync(message);
            return true;
        }
    }
}

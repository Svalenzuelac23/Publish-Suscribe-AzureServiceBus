using Publish.AzureServiceBus.DTOs;
using System.Threading.Tasks;

namespace Publish.AzureServiceBus.Bus
{
    public interface IEventBus
    {
        Task<bool> PublishMessage(InvoiceHeaderRequest request);
    }
}

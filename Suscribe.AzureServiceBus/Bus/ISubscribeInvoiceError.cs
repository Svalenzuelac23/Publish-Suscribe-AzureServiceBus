using System.Threading.Tasks;

namespace Suscribe.AzureServiceBus.Bus
{
    public interface ISubscribeInvoiceError
    {
        Task Process();
        Task CloseSuscribe();
    }
}

using Publish.AzureServiceBus.Models;
using System.Threading.Tasks;

namespace Publish.AzureServiceBus.Repositories
{
    public interface ISalesOrderRepository
    {
        Task<SalesOrderHeader> Get(int docEntry);
    }
}

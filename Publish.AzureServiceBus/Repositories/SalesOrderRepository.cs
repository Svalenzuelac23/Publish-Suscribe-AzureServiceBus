using Microsoft.EntityFrameworkCore;
using Publish.AzureServiceBus.Models;
using Publish.AzureServiceBus.Repositories.Data;
using System.Threading.Tasks;

namespace Publish.AzureServiceBus.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly ApplicationDbContext context;

        public SalesOrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Task<SalesOrderHeader> Get(int docEntry)
        {
            var order = context.SalesOrderHeaders.Include(x => x.Details).FirstOrDefaultAsync(x => x.DocEntry == docEntry);
            return order;
        }
    }
}

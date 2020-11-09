using System;
using System.Collections.Generic;

namespace Publish.AzureServiceBus.DTOs
{
    public class InvoiceHeaderRequest
    {        
        public DateTime DocDate { get; set; }
        public string CardCode { get; set; }
        public bool Freight { get; set; }
        public string Comments { get; set; }
        public IEnumerable<InvoiceDetailRequest> Details { get; set; }
        
    }
}

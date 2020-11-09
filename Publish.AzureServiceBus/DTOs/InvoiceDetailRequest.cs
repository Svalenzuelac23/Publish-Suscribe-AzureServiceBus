namespace Publish.AzureServiceBus.DTOs
{
    public class InvoiceDetailRequest
    {
        public int BaseLine { get; set; }
        public int BaseEntry { get; set; }
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
        public int UomEntry { get; set; }
        public decimal DiscPrcnt { get; set; }
        public decimal UnitPrice { get; set; }
        public string WhsCode { get; set; }
        public string ReturnReason { get; set; }
    }
}

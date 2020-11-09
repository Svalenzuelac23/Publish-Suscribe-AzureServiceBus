using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Publish.AzureServiceBus.Models
{
    [Table("RDR1")]
    public class SalesOrderDetail
    {
        public int DocEntry { get; set; }
        public int LineNum { get; set; }
        public int? TargetType { get; set; }
        public int? TrgetEntry { get; set; }
        public string BaseRef { get; set; }
        public int? BaseType { get; set; }
        public int? BaseEntry { get; set; }
        public int? BaseLine { get; set; }
        public string LineStatus { get; set; }
        public string ItemCode { get; set; }
        public string Dscription { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? OpenQty { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscPrcnt { get; set; }
        public decimal? LineTotal { get; set; }
        public string SerialNum { get; set; }
        public string WhsCode { get; set; }
        public int? SlpCode { get; set; }
        public string TreeType { get; set; }
        public decimal? PriceBefDi { get; set; }
        public DateTime? DocDate { get; set; }
        public string CodeBars { get; set; }
        public decimal? GrssProfit { get; set; }
        public int? VisOrder { get; set; }
        public string BackOrdr { get; set; }
        public string FreeTxt { get; set; }
        public decimal? BaseQty { get; set; }
        [Column("unitMsr")]
        public string UnitMsr { get; set; }
        public decimal? NumPerMsr { get; set; }
        public decimal? StockPrice { get; set; }
        public string BasePrice { get; set; }
        public decimal? StockValue { get; set; }
        public int? UomEntry { get; set; }
        public string UomCode { get; set; }
        public decimal? InvQty { get; set; }
        [Column("U_ReturnReason")]
        public string ReturnReason { get; set; }
        [Column("U_Validated")]
        public string Validated { get; set; }
        [Column("DelivrdQty")]
        public decimal DeliveredQty { get; set; }
        public SalesOrderHeader Header { get; set; }
    }
}

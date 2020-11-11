using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Publish.AzureServiceBus.Models
{
    [Table("ORDR")]
    public class SalesOrderHeader
    {
        [Key]
        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        [Column("CANCELED")]
        public string Canceled { get; set; }
        public string Printed { get; set; }
        public string DocStatus { get; set; }
        public string ObjType { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }
        public string CardCode { get; set; }
        public string NumAtCard { get; set; }
        public decimal? DiscPrcnt { get; set; }
        public decimal? DiscSum { get; set; }
        public decimal? DocTotal { get; set; }
        public decimal? PaidToDate { get; set; }
        public decimal? GrosProfit { get; set; }
        public string Ref1 { get; set; }
        public string Comments { get; set; }
        public string JrnlMemo { get; set; }
        public short? DocTime { get; set; }
        public int? SlpCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? TotalExpns { get; set; }
        [Column("POSRcptNo")]
        public int? Blocked { get; set; }
        [Column("U_DeliveryR")]
        public string IdDeliveryRoute { get; set; }
        [Column("U_InvDate")]
        public DateTime? InvDate { get; set; }
        [Column("U_Drivers")]
        public string IdDriver { get; set; }
        [Column("U_Helpers")]     
        public IEnumerable<SalesOrderDetail> Details { get; set; }
    }
}

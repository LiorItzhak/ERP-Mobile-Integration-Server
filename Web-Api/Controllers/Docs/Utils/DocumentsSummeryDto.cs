namespace Web_Api.Controllers.Docs.Utils
{
    public class DocumentsSummeryDto
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public decimal TotalWithVat { get; set; }
        
        public decimal TotalVat { get; set; }
        public decimal TotalToPay { get; set; }

        public decimal TotalGrossProfit { get; set; }

        public int Count { get; set; }
        
        public DocType Type { get; set; }
        
        public enum DocType { Invoice,Order,Quotation,CreditNote,DeliveryNote , DepositNote,Receipt, Other}


    }
}
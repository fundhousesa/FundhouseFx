namespace FundhouseFx.Controllers.ResponseTypes
{
    public class Quote
    {
        public string BaseCurrency { get; set; }
        
        public string QuoteCurrency { get; set; }
        
        public decimal BaseAmount { get; set; }
        
        public decimal ConvertedAmount { get; set; }
    }
}
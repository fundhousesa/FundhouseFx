namespace FundhouseFx.Data.Model
{
    public class SpotRate
    {
        public int SpotRateId { get; set; }
        
        public int BaseCurrencyId { get; set; }
        
        public int QuoteCurrencyId { get; set; }
        
        public int Timestamp { get; set; }
        
        public decimal Value { get; set; }
        
        public virtual Currency BaseCurrency { get; set; }
        
        public virtual Currency QuoteCurrency { get; set; }
    }
}
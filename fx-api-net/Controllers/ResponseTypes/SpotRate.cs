using System;

namespace FundhouseFx.Controllers.ResponseTypes
{
    public class SpotRate
    {
        public DateTimeOffset Timestamp { get; set; }
        
        public decimal Value { get; set; }
    }
}
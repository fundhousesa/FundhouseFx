using System;
using Microsoft.AspNetCore.Mvc;

namespace FundhouseFx.Controllers
{
    [ApiController, Route("[controller]")]
    public class QuotesController : Controller
    {
        [HttpGet, Route("{baseCcy}/{quoteCcy}")]
        public IActionResult GetQuote(string baseCcy, string quoteCcy, [FromQuery] decimal amount)
        {
            // [TODO]: Convert from one currency to another using the latest available spot rate
            throw new NotImplementedException();
        }
    }
}
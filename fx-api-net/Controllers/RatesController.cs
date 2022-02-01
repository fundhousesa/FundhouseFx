using System;
using System.Linq;
using System.Threading.Tasks;
using FundhouseFx.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResponseTypes = FundhouseFx.Controllers.ResponseTypes;

namespace FundhouseFx.Controllers
{
    [Route("[controller]")]
    public class RatesController : Controller
    {
        [HttpGet, Route("{baseCcy}/{quoteCcy}")]
        public async Task<IActionResult> GetSpotRates(string baseCcy, string quoteCcy)
        {
            await using var dbContext = new FxDataContext();
            
            // [TODO]: Validate input parameters and return the appropriate HTTP error response code if invalid
            var @base = await dbContext.Currencies.SingleOrDefaultAsync(_ =>
                _.CurrencyIsoCode == baseCcy.ToUpperInvariant());

            var quote = await dbContext.Currencies.SingleOrDefaultAsync(_ =>
                _.CurrencyIsoCode == quoteCcy.ToUpperInvariant());
            
            /*
             * [TODO]: Cater for the case where we have spot rates for the two selected currencies,
             * but in the wrong direction.
             *
             * The other case is of course where neither of the currencies are ZAR.
             * Is it possible to derive the exchange rate?
             *
             * See the project specification for more information.
             */
            var rates = await dbContext.SpotRates.Where(_ =>
                    _.BaseCurrencyId == @base.CurrencyId && _.QuoteCurrencyId == quote.CurrencyId)
                .OrderByDescending(_ => _.Timestamp)
                .ToListAsync();

            var mapped = rates.Select(_ => new ResponseTypes.SpotRate
            {
                Timestamp = DateTimeOffset.FromUnixTimeSeconds(_.Timestamp),
                Value = _.Value
            });

            return Ok(mapped);
        }
    }
}
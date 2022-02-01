using System.Linq;
using System.Threading.Tasks;
using FundhouseFx.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResponseTypes = FundhouseFx.Controllers.ResponseTypes;

namespace FundhouseFx.Controllers
{
    [ApiController, Route("[controller]")]
    public class CurrenciesController : Controller
    {   
        [HttpGet, Route("")]
        public async Task<IActionResult> GetCurrencies()
        {
            await using var dbContext = new FxDataContext();

            var currencies = await dbContext.Currencies.ToListAsync();

            var mapped = currencies.Select(_ => new ResponseTypes.Currency
            {
                Name = _.CurrencyName,
                Code = _.CurrencyIsoCode,
                Symbol = _.CurrencySymbol
            });
            
            return Ok(mapped);
        }
    }
}
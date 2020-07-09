using System.Threading.Tasks;
using CryptoResearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoResearch.ViewComponents
{
    public class CurrencysViewComponent : ViewComponent
    {
        private readonly MyContext _context;

        public CurrencysViewComponent(MyContext context)
        {
            this._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          return View(await _context.Currencys.ToListAsync());
        }
    }
}
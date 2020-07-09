using System.Threading.Tasks.Dataflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CryptoResearch.Models;

namespace CryptoResearch.Controllers
{
    public class CurrencysController : Controller
    {
        private readonly MyContext _context;

        public CurrencysController(MyContext context)
        {
            _context = context;
        }

        // GET: Currencys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Currencys.ToListAsync());
        }

        // GET: Currencys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Currencys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Currency currency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }

        // GET: Currencys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = await _context.Currencys.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }
            return View(currency);
        }

        // POST: Currencys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity")] Currency currency)
        {
            if (id != currency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await CurrencyExistsAsync(currency.Id))
                    {
                        throw;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }

        private async Task<bool> CurrencyExistsAsync(int id)
        {
            return await _context.Currencys.AnyAsync(e => e.Id == id);
        }

        [HttpGet]
        public async Task<JsonResult> CurrencyExistsAsync(string name)
        {
            bool exists = await _context.Currencys.AnyAsync(e => e.Name == name);

            if (exists)
            {
                return Json("Currency already registered.");
            }

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> SelectCurrencys(List<Currency> currencys)
        {
            foreach (var item in currencys)
            {
                if (item.Checked)
                {
                    var currency = await _context.Currencys.FirstAsync(x => x.Id == item.Id);
                    currency.Quantity++;
                    _context.Update(currency);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public JsonResult ChartData()
        {
            var data = _context.Currencys.Select(x => new { x.Name, x.Quantity });

            return Json(data);
        }
    }
}
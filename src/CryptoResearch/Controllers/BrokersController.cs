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
    public class BrokersController : Controller
    {
        private readonly MyContext _context;

        public BrokersController(MyContext context)
        {
            _context = context;
        }

        // GET: Brokers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Brokers.ToListAsync());
        }

        // GET: Brokers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broker = await _context.Brokers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (broker == null)
            {
                return NotFound();
            }

            return View(broker);
        }

        // GET: Brokers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brokers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Foundation")] Broker broker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(broker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(broker);
        }

        // GET: Brokers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broker = await _context.Brokers.FindAsync(id);
            if (broker == null)
            {
                return NotFound();
            }
            return View(broker);
        }

        // POST: Brokers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Foundation")] Broker broker)
        {
            if (id != broker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(broker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrokerExists(broker.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(broker);
        }

        // GET: Brokers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broker = await _context.Brokers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (broker == null)
            {
                return NotFound();
            }

            return View(broker);
        }

        // POST: Brokers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var broker = await _context.Brokers.FindAsync(id);
            _context.Brokers.Remove(broker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrokerExists(int id)
        {
            return _context.Brokers.Any(e => e.Id == id);
        }
    }
}

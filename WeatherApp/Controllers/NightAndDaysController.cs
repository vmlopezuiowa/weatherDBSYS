using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class NightAndDaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NightAndDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NightAndDays
        public async Task<IActionResult> Index()
        {
            return View(await _context.NightAndDay.ToListAsync());
        }

        // GET: NightAndDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nightAndDay = await _context.NightAndDay
                .SingleOrDefaultAsync(m => m.ZIP == id);
            if (nightAndDay == null)
            {
                return NotFound();
            }

            return View(nightAndDay);
        }

        // GET: NightAndDays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NightAndDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZIP,Date,Sunrise,Sunset,Moonrise,Moonset")] NightAndDay nightAndDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nightAndDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nightAndDay);
        }

        // GET: NightAndDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nightAndDay = await _context.NightAndDay.SingleOrDefaultAsync(m => m.ZIP == id);
            if (nightAndDay == null)
            {
                return NotFound();
            }
            return View(nightAndDay);
        }

        // POST: NightAndDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZIP,Date,Sunrise,Sunset,Moonrise,Moonset")] NightAndDay nightAndDay)
        {
            if (id != nightAndDay.ZIP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nightAndDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NightAndDayExists(nightAndDay.ZIP))
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
            return View(nightAndDay);
        }

        // GET: NightAndDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nightAndDay = await _context.NightAndDay
                .SingleOrDefaultAsync(m => m.ZIP == id);
            if (nightAndDay == null)
            {
                return NotFound();
            }

            return View(nightAndDay);
        }

        // POST: NightAndDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nightAndDay = await _context.NightAndDay.SingleOrDefaultAsync(m => m.ZIP == id);
            _context.NightAndDay.Remove(nightAndDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NightAndDayExists(int id)
        {
            return _context.NightAndDay.Any(e => e.ZIP == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeathersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeathersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Weathers
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["ZIPSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ZIP_desc" : "ZIP";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "day_desc" : "Date";
            var weathers = from w in _context.Weather
                           select w;
            if (!String.IsNullOrEmpty(searchString))
            {
                weathers = weathers.Where(s => s.ZIP.ToString().Contains(searchString)
                                       || s.Date.ToString(CultureInfo.CurrentCulture).Contains(searchString) 
                                       || s.City.ToString().Contains(searchString)
                                       || s.State.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ZIP_desc":
                    weathers = weathers.OrderByDescending(w => w.ZIP);
                    break;
                case "Date":
                    weathers = weathers.OrderBy(w => w.Date);
                    break;
                case "Date_desc":
                    weathers = weathers.OrderByDescending(w => w.Date);
                    break;
                default:
                    weathers = weathers.OrderBy(w => w.ZIP);
                    break;
            }
            return View(await weathers.AsNoTracking().ToListAsync());
        }

        // GET: Weathers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weather = await _context.Weather
                .SingleOrDefaultAsync(m => m.ZIP == id);
            if (weather == null)
            {
                return NotFound();
            }

            return View(weather);
        }

        // GET: Weathers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weathers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZIP,City,State,Day,Temperature,FeelsLike,WindDirection,WindSpeed,Humidity,AirPressure,Visibility,UVIndex,Sunrise,Sunset,Moonrise,Moonset,Temperature_Celsius")] Weather weather)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weather);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weather);
        }

        // GET: Weathers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weather = await _context.Weather.SingleOrDefaultAsync(m => m.ZIP == id);
            if (weather == null)
            {
                return NotFound();
            }
            return View(weather);
        }

        // POST: Weathers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZIP,City,State,Day,Temperature,FeelsLike,WindDirection,WindSpeed,Humidity,AirPressure,Visibility,UVIndex,Sunrise,Sunset,Moonrise,Moonset,Temperature_Celsius")] Weather weather)
        {
            if (id != weather.ZIP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weather);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherExists(weather.ZIP))
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
            return View(weather);
        }

        // GET: Weathers/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weather = await _context.Weather
                .SingleOrDefaultAsync(m => m.ZIP == id);
            if (weather == null)
            {
                return NotFound();
            }

            return View(weather);
        }

        // POST: Weathers/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weather = await _context.Weather.SingleOrDefaultAsync(m => m.ZIP == id);
            _context.Weather.Remove(weather);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherExists(int id)
        {
            return _context.Weather.Any(e => e.ZIP == id);
        }
    }
}

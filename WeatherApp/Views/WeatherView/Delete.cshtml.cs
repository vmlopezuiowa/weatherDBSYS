using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp.Views.WeatherView
{
    public class DeleteModel : PageModel
    {
        private readonly WeatherApp.Data.ApplicationDbContext _context;

        public DeleteModel(WeatherApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Weather Weather { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Weather = await _context.Weather.SingleOrDefaultAsync(m => m.ZIP == id);

            if (Weather == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Weather = await _context.Weather.FindAsync(id);

            if (Weather != null)
            {
                _context.Weather.Remove(Weather);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

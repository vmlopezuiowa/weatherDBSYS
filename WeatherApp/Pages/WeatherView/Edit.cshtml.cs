using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;

namespace WeatherApp.Pages.WeatherView
{
    public class EditModel : PageModel
    {
        private readonly WeatherApp.Models.WeatherContext _context;

        public EditModel(WeatherApp.Models.WeatherContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Weather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(Weather.ZIP))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WeatherExists(int id)
        {
            return _context.Weather.Any(e => e.ZIP == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Models;

namespace WeatherApp.Pages.Weather
{
    public class DetailsModel : PageModel
    {
        private readonly WeatherApp.Models.WeatherContext _context;

        public DetailsModel(WeatherApp.Models.WeatherContext context)
        {
            _context = context;
        }

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
    }
}

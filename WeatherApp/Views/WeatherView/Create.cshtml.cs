using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp.Views.WeatherView
{
    public class CreateModel : PageModel
    {
        private readonly WeatherApp.Data.ApplicationDbContext _context;

        public CreateModel(WeatherApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Weather Weather { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Weather.Add(Weather);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
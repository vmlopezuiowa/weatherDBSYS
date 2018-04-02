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
    public class IndexModel : PageModel
    {
        private readonly WeatherApp.Models.WeatherContext _context;

        public IndexModel(WeatherApp.Models.WeatherContext context)
        {
            _context = context;
        }

        public IList<Weather> Weather { get;set; }

        public async Task OnGetAsync()
        {
            Weather = await _context.Weather.ToListAsync();
        }
    }
}

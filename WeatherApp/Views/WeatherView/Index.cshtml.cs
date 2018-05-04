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
    public class IndexModel : PageModel
    {
        private readonly WeatherApp.Data.ApplicationDbContext _context;

        public IndexModel(WeatherApp.Data.ApplicationDbContext context)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
    public class NightAndDay
    {
        // zip, city, state, time, temperature, feelslike, 
        // humidity, windspeed, airpressure, visibility, uv index

        [Key, Column(Order = 0)]
        public int ZIP { get; set; }
        [Key, Column(Order = 1)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public TimeSpan Sunrise { get; set; }

        public TimeSpan Sunset { get; set; }

        public TimeSpan Moonrise { get; set; }
        public TimeSpan Moonset { get; set; }
    }
}

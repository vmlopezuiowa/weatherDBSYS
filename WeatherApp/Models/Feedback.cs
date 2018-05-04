using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.Models
{
    public class Feedback
    {
        // zip, city, state, time, temperature, feelslike, 

        [Key, Column(Order = 0)]
        public int ReviewId { get; set; }
        public string Email{ get; set; }
        public string Comment { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }
       

    }
}

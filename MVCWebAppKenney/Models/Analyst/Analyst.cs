using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.Analyst
{
    public class Analyst : ApplicationUser
    {
        // List of Demand Forecasts
        public List<Forecast> ForecastsByAnalyst { get; set; }

        public Analyst() { }

        public Analyst(string firstname, string lastname, string email, string phoneNumber, string password) : base(firstname, lastname, email, phoneNumber, password) { }
    }
}

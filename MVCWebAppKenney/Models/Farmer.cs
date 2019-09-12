using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models
{
    public class Farmer : ApplicationUser
    {
        // Link to Farm
        public int FarmID { get; set; }
        [ForeignKey("FarmID")]
        public Farm Farm { get; set; }

        public Farmer() { }

        public Farmer(string firstname, string lastname, string email, string phoneNumber, string password, int farmID) : base(firstname, lastname, email, phoneNumber, password)
        {
            this.FarmID = farmID;
        }
    }
}

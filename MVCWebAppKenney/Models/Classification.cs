using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Registration.Student
//FinAid.Student

namespace MVCWebAppKenney.Models
{
    public class Classification
    {
        //For MVC, all attributes(private) are properties(public)
        //accessType (private, public, protected)
        [Key]
        public int ClassificationID { get; set; }
        public string ClassificationName { get; set; }

        public List<Crop> Crops { get; set; }

    } //end class

} //end namespace

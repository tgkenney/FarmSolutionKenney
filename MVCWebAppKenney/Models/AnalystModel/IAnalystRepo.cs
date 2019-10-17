using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.Analyst
{
    public interface IAnalystRepo
    {
        List<Analyst> ListAllAnalysts();
    }
}

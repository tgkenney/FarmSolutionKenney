using MVCWebAppKenney.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.Analyst
{
    public class AnalystRepo : IAnalystRepo
    {
        private ApplicationDbContext database;

        public AnalystRepo(ApplicationDbContext dbContext)
        {
            database = dbContext;
        }

        public List<Analyst> ListAllAnalysts()
        {
            List<Analyst> analystList = database.Analysts.ToList<Analyst>();

            return analystList;
        }
    }
}

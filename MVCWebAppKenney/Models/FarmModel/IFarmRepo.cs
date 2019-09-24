using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.FarmModel
{
    public interface IFarmRepo
    {
        List<Farm> ListAllFarms();
        Task AddFarm(Farm farm);
        Task EditFarm(Farm farm);
        Task DeleteFarm(int farmID);
    }
}

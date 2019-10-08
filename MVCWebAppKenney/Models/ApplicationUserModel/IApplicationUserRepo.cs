using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebAppKenney.Models.ApplicationUserModel
{
    public interface IApplicationUserRepo
    {
        List<ApplicationUser> ListAllUsers();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUShop.Domains.Models.User;

namespace eUShop.BusinessLogic.Interface
{
    public interface IAuthActions
    {
        object? LoginActionFlow(UserAuthAction auth);
    }
}

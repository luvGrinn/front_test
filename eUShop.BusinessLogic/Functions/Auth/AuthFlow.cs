using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUShop.BusinessLogic.Core.Auth;
using eUShop.BusinessLogic.Interface;
using eUShop.Domains.Models.User;

namespace eUShop.BusinessLogic.Functions.Auth
{
    public class AuthFlow : AuthActions, IAuthActions
    {
        public object? LoginActionFlow(UserAuthAction auth)
        {
            var isValid = ValidateLogin(auth);
            return isValid ? GenToken(auth) : null;
        }
    }
}

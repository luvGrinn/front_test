using eUShop.BusinessLogic.Functions.Auth;
using eUShop.BusinessLogic.Functions.Products;
using eUShop.BusinessLogic.Interface;

namespace eUShop.BusinessLogic
{
    public class BusinessLogic
    {
        public BusinessLogic() { }

        public IAuthActions GetAuthActions()
        {
            return new AuthFlow();
        }

        public IProduct GetProductActions()
        {
            return new ProductFlow();
        }
    }
}

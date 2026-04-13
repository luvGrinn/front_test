using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUShop.Domains.Models.Base;
using eUShop.Domains.Models.Product;

namespace eUShop.BusinessLogic.Interface
{
    public interface IProduct
    {
        List<ProductDto> GetAllProductsAction();
        ProductDto GetProductByIdAction(int id);
        ResponceMsg ResponceProductUpdateAction(ProductDto product);
        ResponceMsg ResponceProductDeleteAction(int id);
        ResponceMsg ResponceProductCreateAction(ProductDto product);
    }
}

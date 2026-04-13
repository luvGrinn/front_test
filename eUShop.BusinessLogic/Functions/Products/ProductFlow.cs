using eUShop.BusinessLogic.Core.Products;
using eUShop.BusinessLogic.Interface;
using eUShop.Domains.Models.Base;
using eUShop.Domains.Models.Product;

namespace eUShop.BusinessLogic.Functions.Products
{
    public class ProductFlow : ProductAction, IProduct
    {
        public List<ProductDto> GetAllProductsAction()
        {
            var products = ExecuteGetAllProductsAction();
            return products;
        }

        public ProductDto GetProductByIdAction(int id)
        {
            return GetProductDataByIdAction(id);
        }

        public ResponceMsg ResponceProductUpdateAction(ProductDto product)
        {
            return ExecuteProductUpdateAction(product);
        }

        public ResponceMsg ResponceProductDeleteAction(int id)
        {
            return ExecuteProductDeleteAction(id);
        }

        public ResponceMsg ResponceProductCreateAction(ProductDto product)
        {
            return ExecuteProductCreateAction(product);
        }
    }
}

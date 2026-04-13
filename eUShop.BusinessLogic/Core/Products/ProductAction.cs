using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUShop.DataAccess.Context;
using eUShop.Domains.Entities.Product;
using eUShop.Domains.Enums;
using eUShop.Domains.Models.Base;
using eUShop.Domains.Models.Product;

namespace eUShop.BusinessLogic.Core.Products
{
    public class ProductAction
    {
        protected List<ProductDto> ExecuteGetAllProductsAction()
        {
            var products = new List<ProductDto>();
            List<ProductData> pData;

            using (var db =new ProductContext())
            {
                //TODO: Add InerJoin to select on D3 and D4!
                pData = db.Products.ToList();
            }

            foreach (var product in pData)
            {
                var produc = new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    Images = product.Images,
                    Price = product.Price
                };

                products.Add(produc);
            }

            return products;
        }
        protected ProductDto GetProductDataByIdAction(int id)
        {

            ProductData pData;
            using (var db = new ProductContext())
            {
                //TODO: Add InerJoin to select on D3 and D4!
                pData = db.Products.FirstOrDefault(x => x.Id == id);
            }

            return new ProductDto()
            {
                Id = pData.Id,
                Name = pData.Name,
                Description = pData.Description,
                Category = pData.Category,
                Images = pData.Images,
                Price = pData.Price
            };
        }
        protected ResponceMsg ExecuteProductUpdateAction(ProductDto product)
        {
            using (var db = new ProductContext())
            {
                var pData = db.Products.FirstOrDefault(x => x.Id == product.Id);
                if (pData == null)
                {
                    return new ResponceMsg { IsSuccess = false, Message = "Product not found." };
                }

                pData.Name = product.Name;
                pData.Description = product.Description;
                pData.Category = product.Category;
                pData.Images = product.Images;
                pData.Price = product.Price;
                
                db.SaveChanges();
            }

            return new ResponceMsg { IsSuccess = true, Message = "Product updated successfully." };
        }
        protected ResponceMsg ExecuteProductDeleteAction(int id)
        {
            using (var db = new ProductContext())
            {
                var pData = db.Products.FirstOrDefault(x => x.Id == id);
                if (pData == null)
                {
                    return new ResponceMsg { IsSuccess = false, Message = "Product not found." };
                }
                db.Products.Remove(pData);
                db.SaveChanges();
            }
            return new ResponceMsg { IsSuccess = true, Message = "Product deleted successfully." };
        }
        protected ResponceMsg ExecuteProductCreateAction(ProductDto product)
        {
            ProductData pData;
            using (var db = new ProductContext())
            {
                pData = db.Products.FirstOrDefault(
                    x => x.Name.Equals(product.Name));
            }

            if (pData != null)
            {
                return new ResponceMsg
                {
                    IsSuccess = false, 
                    Message = "An product with this Name already exist in our system."
                };
            }

            var pLocalData = new ProductData
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category,
                Images = product.Images,
                Status = ProductStatus.Active
            };

            using (var db = new ProductContext())
            {
                db.Products.Add(pLocalData);
                db.SaveChanges();
            }

            return new ResponceMsg
            {
                IsSuccess = true,
                Message = "Product was succesfully added."
            };
        }
    }
}

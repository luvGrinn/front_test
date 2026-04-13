using eUShop.Domains.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace eUShop.DataAccess.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductData> Products { get; set; }



        public DbSet<ProductImgData> ProductImgs { get; set; }
        public DbSet<CategoryData> Categories { get; set; }
        public DbSet<ProductDescriptionData> Description { get; set; }
        public DbSet<DescriptionAdvanced> DescriptionAdvanced { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }
    }
}

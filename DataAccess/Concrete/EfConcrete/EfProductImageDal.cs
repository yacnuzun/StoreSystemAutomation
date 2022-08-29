using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.DatabaseContext;
using Entity.Concrete;
using Entity.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfConcrete
{
    public class EfProductImageDal:EfEntityRepositoryBase<StoreDbContext,ProductImage>,IProductImageDal
    {
        public List<ProductImageDto> GetProductDetails()
        {
            using (StoreDbContext context = new StoreDbContext())
            {
                var result = from pi in context.ProductImages
                             join p in context.Products
                             on pi.ProductId equals p.Id
                             select new ProductImageDto()
                             {
                                 Id= (int)pi.Id,
                                 Picture = pi.ImagePath,
                                 ProductName = p.Name,
                                 Price = p.Price,
                                 Description = p.Description
                             };
                return result.ToList();
            }
        }
    }
}

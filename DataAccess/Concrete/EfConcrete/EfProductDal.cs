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
    public class EfProductDal : EfEntityRepositoryBase<StoreDbContext, Product>, IProductDal
    {
        public List<ProductDto> GetProductDetails(int id)
        {
            using (StoreDbContext context =new StoreDbContext() )
            {
                var result = from p in context.Products
                             join pi in context.ProductImages
                             on p.Id equals pi.ProductId
                             where p.Id== id
                             select new ProductDto()
                             {
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

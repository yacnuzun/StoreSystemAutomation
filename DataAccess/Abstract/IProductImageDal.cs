using Core.DataAccess;
using Entity.Concrete;
using Entity.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductImageDal:IEntityRepository<ProductImage>
    {
        List<ProductImageDto> GetProductDetails();
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.DatabaseContext;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EfConcrete
{
    public class EfProductDal:EfEntityRepositoryBase<StoreDbContext,Product>,IProductDal
    {
    }
}

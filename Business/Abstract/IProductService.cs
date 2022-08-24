using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDto>> GetProductDetails(int id);
        IDataResult<Product> Get(int id);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);

    }
}

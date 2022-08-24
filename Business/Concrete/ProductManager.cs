using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("Ürün Eklendi.");
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult("Ürün Eklendi.");
        }

        public IDataResult<Product> Get(int id)
        {
            var result = _productDal.Get(p => p.Id == id);
            return new SuccessDataResult<Product>(result,"Ürün Listelendi.");
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),"Ürünler Listelendi.");
        }

        public IDataResult<List<ProductDto>> GetProductDetails(int id)
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetProductDetails(id), "Ürün Detayı Gösterildi.");
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult("Ürün Eklendi.");
        }
    }
}

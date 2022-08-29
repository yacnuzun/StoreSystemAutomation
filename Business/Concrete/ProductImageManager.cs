using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dto_s;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImage;

        public ProductImageManager(IProductImageDal productImage)
        {

            _productImage = productImage;
        }

        public IResult Add(IFormFile file,ProductImage productImage)
        {
            productImage.ImagePath=FileHelper.Add(file);
            _productImage.Add(productImage);
            return new SuccessResult("Eklendi.");
        }

        public IResult Delete(ProductImage productImage)
        {
            FileHelper.Delete(productImage.ImagePath);
            _productImage.Delete(productImage);
            return new SuccessResult("Silindi.");
        }

        public IDataResult<ProductImage> Get(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImage.Get(p => p.Id == id));
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImage.GetAll());
        }

        public IDataResult<List<ProductImage>> GetByProductId(int id)
        {
            return new SuccessDataResult<List<ProductImage>>(_productImage.GetAll(p => p.ProductId == id));
        }

        public IDataResult<List<ProductImageDto>> GetProductsDetail()
        {
            return new SuccessDataResult<List<ProductImageDto>>(_productImage.GetProductDetails());
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = FileHelper.Update((_productImage.Get(p => p.Id == productImage.Id)).ToString(), file);
            _productImage.Update(productImage);
            return new SuccessResult("Güncellendi.");
        }
    }
}

using Business.Abstract;
 using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        
        public ProductManager(IProductDal productDal ,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
           
        }

         [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            #region FluentKullanmadanOnce
            ////iş kodları-business code
            //if (product.ProductName.Length < 2)
            //{
            //    //magic strings  --stringleri ayrı ayrı yazmak demek
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}
            #endregion
            //ValidationTool.Validate(new ProductValidator(),product);
            //business code
            //Aynı isimde ürün eklenemez
            //bir kategoride en fazla 10 ürün olablir.
            //eğer mevcut kategori sayısı 15'i gectiyse sisteme yeni ürün eklenemez
           IResult result= BusinessRules.Run(CheckIfProductNameExists(product.ProductName)
                           , CheckIfProductCountOfCategoryCorrect(product.CategoryId)
                           , CheckIfCategoryLimitExceded()
                           );

           if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            #region iş kuralı yazmadan once
            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)  
            //{
            //    if (CheckIfProductNameExists(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);
            //        return new SuccessResult(Messages.ProductAdded);
            //    }

            //}
            //return new ErrorResult();
            #endregion
        }



        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
            }
            else
                return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);


        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));

        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        
        
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string produtName)
        {
            //Any var mı demek bool deger dondurur
            var result = _productDal.GetAll(p => p.ProductName==produtName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            //Any var mı demek bool deger dondurur
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}

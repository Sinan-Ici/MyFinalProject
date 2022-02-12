using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.UtiliErrories.Results;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using Entites.DTOs;
using FluentValidation;
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
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]//Add meodunu doğrula productValidator kullanark.(Add metodunu doğrula productValidator dAki kurallara göre.
        [CacheRemoveAspect("IProductService.Get")]//Update metodunda açıklaması yapıldı.
        public IResult Add(Product product)
        {
            IResult result=  BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckifTheProductNamesExists(product.ProductName),CheckIFCategoryLimitExceded());
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded); 
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Product>> GetAll()        
        {
            //if (DateTime.Now.Hour == 14)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            //return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
            
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryId==id);
        }
        [CacheAspect]
        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId==productId);
        }

        public IDataResult <List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());    
        }
        [CacheRemoveAspect("IProductService.Get")]//Update işlemi yaparken daha önce cache içine kaydettiğimiz veriyi silmemiz gerekiyor çünkü artık güncel veri değil bu nedenle IProdctservice teki Get metodunu için kayıtta kalan cache verisini bu metod çalışırken temizle demiş olduk.0
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Product>> IProductService.GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == id));
        }

        IDataResult<Product> IProductService.GetById(int productId)
        {
            return new SuccessDataResult<Product>( _productDal.Get(p => p.ProductId == productId));
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            int result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckifTheProductNamesExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
           
        }
        private IResult CheckIFCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if (product.UnitPrice < 10)
            {
                throw new Exception("");
            }

            Add(product);

            return null;
        }
    }
}           

using Core.Utilities.Results;
using Entites.Concrete;
using Entites.DTOs;
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
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<List<Product>> GetAllByCategoryId(int id);//category id sine göre getir.
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);//mesajları, hata mesajları ekleyebilmnek için idatareult kullandık
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);//burada data yok o yuzde idata result demedik
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);
            
    }
}

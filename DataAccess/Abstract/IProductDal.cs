using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(int Id);

        List<Product> GetAllByCategory(int categoryID);
        List<Product> GetAll();
    }
}

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID O HARFİ
    //O=Open Closed Principle
    //Yeni bir özellik ekliyoruz ama mevcut hiçbir şeyi değiştirmiyoruz. Sadece ef klasörü oluşturduk onun kendi kodlarını yazdık
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetByUnitPrice(20,100))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}

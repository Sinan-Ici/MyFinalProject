using System;
using System.Collections.Generic;
using System.Linq;

namespace deneme
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Araba> arabalars = new List<Araba>
            {
                new Araba{Fiyati=150000,Markasi="Honda",UnitInStock=50},
                new Araba{Fiyati=200000,Markasi="Fiat",UnitInStock=40},
                new Araba{Fiyati=175000,Markasi="Reanult",UnitInStock=30}
                
            };
            foreach (var araba in arabalars)
            {
                if (araba.Fiyati>=160000 && araba.UnitInStock>=35)
                {
                    Console.WriteLine(araba.Markasi+" "+araba.Fiyati);
                }
            }
            var result = arabalars.Where(a => a.Fiyati >= 160000 && a.UnitInStock <= 35);
            foreach (var item in result)
            {
                Console.WriteLine(item.Markasi+" "+item.Fiyati);
            }
        }
        static List<Araba> GetArabas(List<Araba>arabas )
        {
            List<Araba> filtrele = new List<Araba>();
            foreach (var item in arabas)
            {
                filtrele.Add(arabas);   
            }
            return filtrele;
        }
        static List<Araba> GetArabalarLinq(List<Araba> arabas)
        {
            return arabas.Where(a => a.Fiyati <= 160000).ToList();
        }

        
    }
    class Araba
    {
        public int Fiyati { get; set; }
        public string Markasi { get; set; }
        public int UnitInStock { get; set; }
    }
}

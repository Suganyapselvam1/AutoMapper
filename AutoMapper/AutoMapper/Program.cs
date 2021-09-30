using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            WithoutAutoMapper();
        }
        public static void WithoutAutoMapper()
        {
            var merchandise = new Merchandise();
            merchandise.ID = 1;
            merchandise.Name = "Jersey";
            merchandise.Price = 20;

            var merchandiseView = new MerchandiseView();
            merchandiseView.ID = merchandise.ID;
            merchandiseView.DiffName = merchandise.Name;
            merchandiseView.Price = merchandise.Price;

            Console.WriteLine(merchandiseView.Price);
        }
    }
}

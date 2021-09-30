using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    class Program
    {
        private static IMapper mapper;
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Merchandise, MerchandiseView>()
                .ForMember(x => x.DiffName, y => y.MapFrom(z => z.Name));
            });
            mapper = config.CreateMapper();
            config.AssertConfigurationIsValid();

            WithoutAutoMapper();
            AutoMapperSimpleEx();
        }

        private static void AutoMapperSimpleEx()
        {
            var merchandise = new Merchandise();
            merchandise.ID = 2;
            merchandise.Name = "Gift Card";
            merchandise.Price = 50;

            MerchandiseView merchandiseView = mapper.Map<MerchandiseView>(merchandise);
            Console.WriteLine(merchandiseView.ID);
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

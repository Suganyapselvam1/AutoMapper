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
            AutoMapperForList();
        }

        private static void AutoMapperForList()
        {
            var merchandise = new Merchandise();
            merchandise.ID = 2;
            merchandise.Name = "Gift Card";
            merchandise.Price = 50;

            var merchandiseSizeMap1 = new MerchandiseSizeMap()
            {
                ID = 1,
                Size = "M",
                Stock = 5,
            };

            var merchandiseSizeMap2 = new MerchandiseSizeMap()
            {
                ID = 2,
                Size = "L",
                Stock = 4,
            };

            var merchandiseSizeMap3 = new MerchandiseSizeMap()
            {
                ID = 1,
                Size = "XL",
                Stock = 3,
            };

            var merchandiseSizeMaps = new List<MerchandiseSizeMap>();
            merchandiseSizeMaps.Add(merchandiseSizeMap1);
            merchandiseSizeMaps.Add(merchandiseSizeMap2);
            merchandiseSizeMaps.Add(merchandiseSizeMap3);

            merchandise.MerchandiseSizeMaps = merchandiseSizeMaps;

            MerchandiseView merchandiseView = mapper.Map<MerchandiseView>(merchandise);
            foreach (var merchandiseSizeMap in merchandiseView.MerchandiseSizeMaps)
            {
                Console.WriteLine(merchandiseSizeMap.Size);
            }

        }
        private static void AutoMapperSimpleEx()
        {
            var merchandise = new Merchandise();
            merchandise.ID = 2;
            merchandise.Name = "Gift Card";
            merchandise.Price = 50;

            merchandise.MerchandiseSizeMap = new MerchandiseSizeMap()
            {
                ID=1,
                Size="M",
                Stock=5,
            };
            

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

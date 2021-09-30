using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    public class MerchandiseView
    {
        public int ID { get; set; }
        public string DiffName { get; set; }
        public decimal Price { get; set; }
        public List<MerchandiseSizeMap> MerchandiseSizeMaps { get; set; }
    }
}

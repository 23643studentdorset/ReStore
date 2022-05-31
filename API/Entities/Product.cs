using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Product
    {
        public int id { get; set; }
        public String name { get; set; }

        public String description { get; set; }

        public long price { get; set; }

        public String pictureUrl { get; set; }

        public String type { get; set; }

        public String brand { get; set; }

        public int quantityInStock { get; set; }
    }
}
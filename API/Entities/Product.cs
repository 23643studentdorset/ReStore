using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }

        public string description { get; set; }

        public long price { get; set; }

        public string pictureUrl { get; set; }

        public string type { get; set; }

        public string brand { get; set; }

        public int quantityInStock { get; set; }
    }
}
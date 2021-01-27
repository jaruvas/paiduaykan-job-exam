using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiduaykanAPI.Models
{
    public class Products
    {
        public int product_id { get; set; }

        public int store_id { get; set; }

        public string product_name { get; set; }

        public string product_description { get; set; }

        public double price { get; set; }

        public int product_type_id { get; set; }

        public int unit_id { get; set; }

        public string product_type_name { get; set; }

        public string product_unit_name { get; set; }
    }
}

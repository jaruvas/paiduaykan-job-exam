using PaiduaykanAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiduaykanAPI.Models
{
    public class Stores
    {
        public int store_id { get; set; }

        public string store_name { get; set; }

        public string store_description { get; set; }

        public string store_tel { get; set; }

        public string store_address { get; set; }
    }
}

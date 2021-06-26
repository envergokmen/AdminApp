using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{

    public class ProductResult
    {
        public object searchKeyWord { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalItem { get; set; }
        public int totalPage { get; set; }
        public Item[] items { get; set; }
    }

    public class Item
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public bool isActive { get; set; }
    }

}

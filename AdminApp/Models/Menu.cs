using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models
{
   
    public class MenuItem
    {
        public string Name { get; set; }
        public string LinkTo { get; set; }
        public string icon { get; set; }
        public Subitem[] SubItems { get; set; }
    }

    public class Subitem
    {
        public string Name { get; set; }
        public string LinkTo { get; set; }
        public string icon { get; set; }
    }


}

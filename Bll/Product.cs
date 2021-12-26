using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
   public class Product
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public  Int16 ReorderPoint{ get; set;}
        public string Class { get; set; }
    }
}

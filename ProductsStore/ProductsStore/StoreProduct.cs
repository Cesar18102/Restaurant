using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStore
{
    public class StoreProduct {

        public int id;
        public int productId;
        public string name;
        public string unit;
        public DateTime shelfStart;
        public double amount;
        public double price;

        public StoreProduct() { }
    }
}

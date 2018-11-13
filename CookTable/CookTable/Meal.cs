using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTable {

    public class Meal {

        public int id;
        public int mealId;
        public int count;
        public string name;
        public double weight;
        public string useProducts;
        public int state_id;

        public List<Product> products;

        public void SetProducts() {

            products = new List<Product>();

            string[] prods = useProducts.Substring(0, useProducts.Length - 1).Split(';');
            foreach (string prod in prods) {

                string[] info = prod.Split(' ');
                Product result = Server.Deserialize<List<Product>>(Server.PostQuery(Constants.QueryURL, "query=SELECT DISTINCT name, unit FROM product WHERE id = " + info[1] + "&pas=Delishes228"))[0];
                result.id = Convert.ToInt32(info[0]);
                result.count = Convert.ToInt32(info[2]);
                products.Add(result);
            }
        }
    }
}

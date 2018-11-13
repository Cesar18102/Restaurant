using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookTable {

    public class Offer {

        public int id;
        public DateTime start;
        public string comment;

        public List<Meal> meals;

        public void SetMeals() {

            meals = Server.Deserialize<List<Meal>>(Server.PostQuery(Constants.QueryURL, "query=SELECT DISTINCT OM.id, MN.id AS mealId, OM.count, OM.useProducts, MN.weight, ML.name, OM.state_id FROM offer OF, offeredmeals OM, menu MN, meal ML WHERE OM.mealMenuld = MN.id AND ML.id = MN.mealId AND OM.offerId = " + id + " AND (OM.state_id = 1 OR OM.state_id = 0)&pas=Delishes228"));

            foreach (Meal meal in meals)
                meal.SetProducts();
        }
    }
}

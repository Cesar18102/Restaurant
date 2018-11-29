using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductsStore
{
    public partial class DropExpiredForm : Form
    {

        private List<Product> PL = new List<Product>();
        private List<StoreProduct> SPL = new List<StoreProduct>();

        public DropExpiredForm()
        {
            InitializeComponent();
        }

        private void DropExpiredForm_Load(object sender, EventArgs e)
        {
            UpdateOldProducts();
        }

        private void RemoveOldProducts_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < oldProductsList.RowCount; i++)
                Server.PostQuery(Constants.QueryURL, "query=DELETE FROM storage_product " + 
                                                           "WHERE id = " + oldProductsList.Rows[i].Cells["oldProductID"].Value + ";&pas=Delishes228");

            UpdateOldProducts();
        }

        public void UpdateOldProducts() {

            string response_stored = Server.PostQuery(Constants.QueryURL,
                                        "query=SELECT S.id, P.id AS product_id, P.name, (SELECT U.name " +
                                                                                        "FROM unit U " +
                                                                                        "WHERE U.id = P.unit_id) AS unit, " +
                                                     "S.made_date, S.amount, S.discrete_price " +
                                               "FROM product P, storage_product S " +
                                               "WHERE P.id = S.product_id&pas=Delishes228");

            SPL = Server.Deserialize<StoreProduct>(response_stored);



            string response_product = Server.PostQuery(Constants.QueryURL, "query=SELECT P.id, P.name, U.name AS unit, C.name AS category, P.shelf_life " +
                                                                           "FROM product P, unit U, category C " +
                                                                           "WHERE U.id = P.unit_id AND C.id = P.category_id " +
                                                                           "ORDER BY P.id ASC&pas=Delishes228");

            PL = Server.Deserialize<Product>(response_product);

            oldProductsList.Rows.Clear();

            for (int i = 0; i < SPL.Count; i++) {

                DateTime shelfStart = SPL[i].made_date;
                DateTime now = DateTime.Now;

                for (int j = 0; j < PL.Count; j++)
                {

                    int shelfLife = Convert.ToInt32(PL[j].shelf_life);

                    if (SPL[i].name == PL[j].name && shelfStart.AddHours(shelfLife) < now)
                    {

                        oldProductsList.Rows.Add();
                        int hours = Convert.ToInt32((shelfStart.AddHours(shelfLife) - now).TotalHours);

                        oldProductsList.Rows[oldProductsList.RowCount - 1].Cells["oldProductID"].Value = SPL[i].id;
                        oldProductsList.Rows[oldProductsList.RowCount - 1].Cells["oldProductName"].Value = SPL[i].name;
                        oldProductsList.Rows[oldProductsList.RowCount - 1].Cells["oldProductCount"].Value = SPL[i].amount;
                        oldProductsList.Rows[oldProductsList.RowCount - 1].Cells["oldProductUnit"].Value = SPL[i].unit;
                        oldProductsList.Rows[oldProductsList.RowCount - 1].Cells["oldProductPrice"].Value = SPL[i].discrete_price;
                        oldProductsList.Rows[oldProductsList.RowCount - 1].Cells["oldPeriod"].Value = -hours;

                        for (int k = 0; k < 6; k++)
                            oldProductsList.Rows[oldProductsList.RowCount - 1].Cells[k].Style.BackColor = Color.Red;
                    }
                }

            }
        }
    }
}

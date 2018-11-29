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
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void InsertStoredButton_Click(object sender, EventArgs e)
        {
            if (StoreProductName.SelectedIndex != -1 && CountInput.Value > 0 && PrimalPriceInput.Value > 0)
                InsertStoredProduct(StoreProductName.Items[StoreProductName.SelectedIndex].ToString(), Convert.ToDouble(CountInput.Value), Convert.ToDouble(PrimalPriceInput.Value), ShelfStartDate.Value);
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            UpdateStoreList();

            LoadProducts();

            if (StoreProductName.Items.Count > 0)
                StoreProductName.SelectedIndex = 0;
        }

        public void LoadProducts()
        {

            string response = Server.PostQuery(Constants.QueryURL, "query=SELECT name FROM product&pas=Delishes228");

            List<Product> products = Server.Deserialize<Product>(response);

            foreach (Product i in products)
                StoreProductName.Items.Add(i.name);
        }

        public void InsertStoredProduct(string name, double count, double price, DateTime start)
        {

            int id = Server.Deserialize<MaxId>(Server.PostQuery(Constants.QueryURL, "query=SELECT MAX(id) AS id FROM storage_product&pas=Delishes228"))[0].id + 1;
            int productId = Server.Deserialize<MaxId>(Server.PostQuery(Constants.QueryURL, "query=SELECT id FROM product WHERE name = '" + name + "'&pas=Delishes228"))[0].id;

            string values = "'" + id.ToString() + "','" + productId.ToString() + "','" + start.Year + "-" + start.Month + "-" + start.Day + "','" + count.ToString() + "','" + price.ToString() + "'";

            string response = Server.PostQuery(Constants.QueryURL, "query=INSERT INTO storage_product VALUES(" + values + ")&pas=Delishes228");

            UpdateStoreList();
        }

        public void UpdateStoreList()
        {

            storeList.Rows.Clear();

            string response = Server.PostQuery(Constants.QueryURL,
                                        "query=SELECT S.id, P.id AS product_id, P.name, (SELECT U.name FROM unit U WHERE U.id = P.unit_id) AS unit, S.made_date, S.amount, S.discrete_price FROM product P, storage_product S WHERE P.id = S.product_id&pas=Delishes228");

            List<StoreProduct> stores = Server.Deserialize<StoreProduct>(response);


            string response_products = Server.PostQuery(Constants.QueryURL, "query=SELECT P.id, P.name, U.name AS unit, C.name AS category, P.shelf_life FROM product P, unit U, category C WHERE U.id = P.unit_id AND C.id = P.category_id ORDER BY P.id ASC&pas=Delishes228");
            List<Product> products = Server.Deserialize<Product>(response_products);

            if (stores != null)
                foreach (StoreProduct i in stores)
                {

                    storeList.Rows.Add();
                    storeList.Rows[storeList.RowCount - 1].Cells[0].Value = i.id;
                    storeList.Rows[storeList.RowCount - 1].Cells[1].Value = i.name;
                    storeList.Rows[storeList.RowCount - 1].Cells[2].Value = i.amount;
                    storeList.Rows[storeList.RowCount - 1].Cells[3].Value = i.unit;
                    storeList.Rows[storeList.RowCount - 1].Cells[4].Value = i.discrete_price;
                    storeList.Rows[storeList.RowCount - 1].Cells[5].Value = i.made_date.ToShortDateString();

                    DateTime shelfStart = i.made_date;
                    DateTime now = DateTime.Now;

                    for (int j = 0; j < products.Count; j++) {

                        int shelfLife = Convert.ToInt32(products[j].shelf_life);

                        if (i.name == products[j].name && shelfStart.AddHours(shelfLife) < now)
                            for (int k = 0; k < storeList.Rows[storeList.RowCount - 1].Cells.Count; k++ )
                                storeList.Rows[storeList.RowCount - 1].Cells[k].Style.BackColor = Color.Red;
                    }
                }
        }
    }
}

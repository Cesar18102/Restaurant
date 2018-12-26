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
    public partial class AddProductNameForm : Form
    {
        public AddProductNameForm()
        {
            InitializeComponent();
        }

        private List<Predicate<Product>> Filter = new List<Predicate<Product>>();

        private void AddProductNameForm_Load(object sender, EventArgs e)
        {
            UpdateProductList();

            LoadCategories();
            LoadUnits();

            if (CategoryInput.Items.Count > 0)
                CategoryInput.SelectedIndex = 0;

            if (UnitInput.Items.Count > 0)
                UnitInput.SelectedIndex = 0;
        }

        public void UpdateProductList() {

            productsList.Rows.Clear();

            string response = Server.PostQuery(Constants.QueryURL, "query=SELECT P.id, P.name, U.name AS unit, C.name AS category, P.shelf_life FROM product P, unit U, category C WHERE U.id = P.unit_id AND C.id = P.category_id ORDER BY P.id ASC&pas=Delishes228");

            List<Product> products = Server.Deserialize<Product>(response);

            if (products != null)
                foreach (Product i in products)
                {
                    bool IsInRange = true;
                    foreach(Predicate<Product> P in Filter)
                        if (!P(i)) {

                            IsInRange = false;
                            break;
                        }

                    if (!IsInRange)
                        continue;

                    productsList.Rows.Add();
                    productsList.Rows[productsList.RowCount - 1].Cells[0].Value = i.id;
                    productsList.Rows[productsList.RowCount - 1].Cells[1].Value = i.name;
                    productsList.Rows[productsList.RowCount - 1].Cells[2].Value = i.category;
                    productsList.Rows[productsList.RowCount - 1].Cells[3].Value = i.unit;
                    productsList.Rows[productsList.RowCount - 1].Cells[4].Value = i.shelf_life;

                    DeleteID.Minimum = Math.Min(DeleteID.Minimum, i.id);
                    DeleteID.Maximum = Math.Max(DeleteID.Maximum, i.id);
                }
        }

        public void InsertProduct(string name, int shelfLife)
        {

            int id = Server.Deserialize<MaxId>(Server.PostQuery(Constants.QueryURL, "query=SELECT MAX(id) AS id FROM product&pas=Delishes228"))[0].id + 1;

            int CategId = Server.Deserialize<MaxId>(Server.PostQuery(Constants.QueryURL, "query=SELECT id FROM category WHERE name = '" + CategoryInput.Items[CategoryInput.SelectedIndex].ToString() + "'&pas=Delishes228"))[0].id;
            int UnitId = Server.Deserialize<MaxId>(Server.PostQuery(Constants.QueryURL, "query=SELECT id FROM unit WHERE name = '" + UnitInput.Items[UnitInput.SelectedIndex].ToString() + "'&pas=Delishes228"))[0].id;

            string values = "'" + id.ToString() + "','" + name + "','" + CategId + "','" + UnitId + "','" + shelfLife.ToString() + "'";

            string response = Server.PostQuery(Constants.QueryURL, "query=INSERT INTO product VALUES(" + values + ")&pas=Delishes228");

            UpdateProductList();

            MessageBox.Show("Наименование успешно добавлено!");
        }

        public void LoadCategories()
        {

            string response = Server.PostQuery(Constants.QueryURL, "query=SELECT name FROM category&pas=Delishes228");

            List<Category> categories = Server.Deserialize<Category>(response);

            foreach (Category i in categories)
            {
                CategoryInput.Items.Add(i.name);
                FilterCategory.Items.Add(i.name);
            }
        }

        public void LoadUnits()
        {

            string response = Server.PostQuery(Constants.QueryURL, "query=SELECT name FROM unit&pas=Delishes228");

            List<Category> units = Server.Deserialize<Category>(response);

            foreach (Category i in units)
                UnitInput.Items.Add(i.name);
        }

        private void SubmitProduct_Click(object sender, EventArgs e)
        {
            if (ProductNameInput.Text != "" && CategoryInput.SelectedIndex != -1 && UnitInput.SelectedIndex != -1 && ShelfLifeInput.Value > 0)
                InsertProduct(ProductNameInput.Text, Convert.ToInt32(ShelfLifeInput.Value));
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            Server.PostQuery(Constants.QueryURL, "query=DELETE FROM product WHERE id = " + DeleteID.Value.ToString() + "&pas=Delishes228");
            UpdateProductList();

            MessageBox.Show("Наименование успешно удалено!");
        }

        private void Filter_Change(object sender, EventArgs e)
        {
            Filter.Clear();

            if (SearchName.Text != "")
                Filter.Add(P => P.name.ToUpper().StartsWith(SearchName.Text.ToUpper()));

            if (FilterCategory.SelectedIndex != -1)
                Filter.Add(P => P.category == FilterCategory.Items[FilterCategory.SelectedIndex].ToString());

            UpdateProductList();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            FilterCategory.SelectedIndex = -1;
        }
    }
}

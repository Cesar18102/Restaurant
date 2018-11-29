using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;

namespace ProductsStore
{
    public partial class Storage : Form
    {
        public Storage()
        {
            InitializeComponent();
        }

        private void AddProductName_Click(object sender, EventArgs e)
        {
            AddProductNameForm APNF = new AddProductNameForm();
            APNF.ShowDialog();
        }

        private void AddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm APF = new AddProductForm();
            APF.ShowDialog();
        }

        private void DropExpired_Click(object sender, EventArgs e)
        {
            DropExpiredForm DEF = new DropExpiredForm();
            DEF.ShowDialog();
        }
    }
}

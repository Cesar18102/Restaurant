using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Word;
using System.Net;

namespace Reports
{
    public partial class Form1 : Form
    {
        private Word.Application Application;
        private Word.Document Document;
        private Word.Range R;
        private Word.Table T;
        private Object missingObj = System.Reflection.Missing.Value;
        private Object trueObj = true;
        private Object falseObj = false;

        private List<StoreProduct> SP = new List<StoreProduct>();
        private List<Meal> M = new List<Meal>();

        public delegate string ValueAt<Q>(Q SP, int i);

        public Form1()
        {
            InitializeComponent();
        }

        private void MealReport_Click(object sender, EventArgs e)
        {
            M = Server.Deserialize<Meal>(Server.PostQuery(Constants.QueryURL, 
                                  "query=SELECT M.id, (SELECT name FROM category C WHERE C.id = M.category_id) AS category, " +
                                  "M.name, M.description, M.weight, (SELECT name FROM unit U WHERE U.id = M.unit_id) AS unit " +
                                  "FROM meal M&pas=Delishes228"));

            PrintWord<Meal>(new List<string>() {"id", "Категория", "Название", "Описание", "Вес", "Единицы измерения" },
                            (MEL, i) => {
                                Meal ML = MEL as Meal;
                                switch(i) {

                                    case 0: return ML.id.ToString(); break;
                                    case 1: return ML.category; break;
                                    case 2: return ML.name; break;
                                    case 3: return ML.decription; break;
                                    case 4: return ML.weight.ToString(); break;
                                    case 5: return ML.unit; break;
                                    default: return ""; break;
                                }
                            }, M);
        }

        private void ProductReport_Click(object sender, EventArgs e)
        {
            SP = Server.Deserialize<StoreProduct>(Server.PostQuery(Constants.QueryURL,
                                  "query=SELECT SP.id, (SELECT name FROM product P WHERE P.id = SP.product_id) AS product, " +
                                  "SP.made_date, SP.discrete_price, SP.amount, (SELECT U.name FROM unit U, product P WHERE U.id = P.unit_id AND P.id = SP.product_id) AS unit " + 
                                  "FROM storage_product SP&pas=Delishes228"));

            PrintWord<StoreProduct>(new List<string>() { "id", "Продукт", "Дата изготовления", "Цена за единицу", "Количество", "Единицы измерения" },
                            (SPR, i) =>
                            {
                                StoreProduct S = SPR as StoreProduct;
                                switch (i)
                                {

                                    case 0: return S.id.ToString(); break;
                                    case 1: return S.product; break;
                                    case 2: return S.made_date.Date.ToShortDateString(); break;
                                    case 3: return S.discrete_price.ToString(); break;
                                    case 4: return S.amount.ToString(); break;
                                    case 5: return S.unit; break;
                                    default: return ""; break;
                                }
                            }, SP);
        }

        private void PrintWord<Q>(List<string> headers, ValueAt<Q> V, List<Q> Values) {

            this.UseWaitCursor = true;
            FileStream FS = File.Create(Environment.CurrentDirectory + "/Print.doc");
            FS.Close();

            Application = new Word.Application();
            Object PrintPath = Environment.CurrentDirectory + "/Print.doc";

            Document = Application.Documents.Add(ref PrintPath, ref missingObj, ref missingObj, ref missingObj);
            Document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            R = Document.Sections[1].Range;

            T = Document.Tables.Add(R, Values.Count + 1, 6, missingObj, missingObj);
            T.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            T.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            for (int i = 1; i <= 6; i++) {

                T.Rows[1].Cells[i].Width = 500 / headers.Count;
                T.Rows[1].Cells[i].Range.Text = headers[i - 1];
            }

            for (int i = 0; i < Values.Count; i++)
                for (int j = 0; j < headers.Count; j++)
                {
                    T.Rows[i + 2].Cells[j + 1].Width = 500 / headers.Count;
                    T.Rows[i + 2].Cells[j + 1].Range.Text = V(Values[i], j);
                }

            Document.Save();
            Document.Close(missingObj, missingObj, missingObj);
            this.UseWaitCursor = false;
        }
    }
}

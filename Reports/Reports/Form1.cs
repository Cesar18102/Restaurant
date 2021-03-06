﻿using System;
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
using System.Diagnostics;

namespace Reports
{
    public partial class Form1 : Form
    {
        private Word.Application Application;
        private Word.Document Document;
        private Word.Range R;
        private Word.Table T;
        private Word.Paragraph P;
        private Object missingObj = System.Reflection.Missing.Value;
        private Object trueObj = true;
        private Object falseObj = false;

        private List<StoreProduct> SP = new List<StoreProduct>();
        private List<Meal> M = new List<Meal>();
        private List<Driver> D = new List<Driver>();
        private List<MealStat> MS = new List<MealStat>();

        private int V = 0;

        public delegate string ValueAt<Q>(Q SP, int i);

        public Form1()
        {
            InitializeComponent();
        }

        private void MealReport_Click(object sender, EventArgs e)
        {
            ReportProgress.Value = 5;
            this.UseWaitCursor = true;

            M = Server.Deserialize<Meal>(Server.PostQuery(Constants.QueryURL,
                                  "query=SELECT M.id, (SELECT name FROM category C WHERE C.id = M.category_id) AS category, " +
                                  "M.name, M.description, M.weight, (SELECT name FROM unit U WHERE U.id = M.unit_id) AS unit " +
                                  "FROM meal M&pas=Delishes228"));

            ReportProgress.Value = 10;

            int Delta = 80 / (3 * M.Count);

            PrintWord<Meal>(new List<string>() { "id", "Категория", "Название", "Описание", "Вес", "Единицы измерения" },
                            (MEL, i) =>
                            {
                                Meal ML = MEL as Meal;

                                ReportProgress.Increment(Delta);

                                switch (i)
                                {

                                    case 0: return ML.id.ToString(); break;
                                    case 1: return ML.category; break;
                                    case 2: return ML.name; break;
                                    case 3: return ML.decription; break;
                                    case 4: return ML.weight.ToString(); break;
                                    case 5: return ML.unit; break;
                                    default: return ""; break;
                                }
                            }, M, "Отчет по блюдам");

            this.UseWaitCursor = false;
            ReportProgress.Value = 100;
        }

        private void ProductReport_Click(object sender, EventArgs e)
        {
            ReportProgress.Value = 5;
            this.UseWaitCursor = true;

            SP = Server.Deserialize<StoreProduct>(Server.PostQuery(Constants.QueryURL,
                                  "query=SELECT SP.id, (SELECT name FROM product P WHERE P.id = SP.product_id) AS product, " +
                                  "SP.made_date, SP.discrete_price, SP.amount, (SELECT U.name FROM unit U, product P WHERE U.id = P.unit_id AND P.id = SP.product_id) AS unit " +
                                  "FROM storage_product SP&pas=Delishes228"));

            ReportProgress.Value = 10;

            int Delta = 80 / (3 * SP.Count);

            PrintWord<StoreProduct>(new List<string>() { "id", "Продукт", "Дата изготовления", "Цена за единицу", "Количество", "Единицы измерения" },
                            (SPR, i) =>
                            {
                                StoreProduct S = SPR as StoreProduct;

                                ReportProgress.Increment(Delta);

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
                            }, SP, "Отчет по продуктам на складе");

            this.UseWaitCursor = false;
            ReportProgress.Value = 100;
        }

        private void DriverReport_Click(object sender, EventArgs e)
        {
            ReportProgress.Value = 5;
            this.UseWaitCursor = true;

            D = Server.Deserialize<Driver>(Server.PostQuery(Constants.QueryURL, "query=SELECT * FROM driver&pas=Delishes228"));

            ReportProgress.Value = 10;

            int Delta = 80 / (3 * D.Count);

            PrintWord<Driver>(new List<string>() { "id", "Полное имя", "Дата рождения", "Паспорт", "Машина", "e-mail" },
                            (DR, i) =>
                            {
                                Driver DRV = DR as Driver;

                                ReportProgress.Increment(Delta);

                                switch (i)
                                {

                                    case 0: return DRV.id.ToString(); break;
                                    case 1: return DRV.surname + " " + DRV.name + " " + DRV.fathername; break;
                                    case 2: return DRV.birth.Date.ToShortDateString(); break;
                                    case 3: return (DRV.passport_seria == null ? "" : DRV.passport_seria) + DRV.passport_id; break;
                                    case 4: return DRV.car_model + ", " + DRV.car_id; break;
                                    case 5: return DRV.mail; break;
                                    default: return ""; break;
                                }
                            }, D, "Отчет по водителям доставки");

            this.UseWaitCursor = false;
            ReportProgress.Value = 100;
        }

        private void SoldMealsStats_Click(object sender, EventArgs e)
        {
            ReportProgress.Value = 5;
            this.UseWaitCursor = true;

            MS = Server.Deserialize<MealStat>(Server.PostQuery(Constants.QueryURL, "query=SELECT CONCAT(ML.name, ' : ', MN.weight, ' ', (SELECT name FROM unit U WHERE U.id = ML.unit_id)) AS name, " + 
                                                                                                "SUM(PU.amount) AS sold, SUM(PU.spent) total_spent, SUM(MN.price * PU.amount) total_earned " + 
                                                                                          "FROM (SELECT O.id, O.menu_id, O.amount, SUM(ROUND(SP.discrete_price * UP.amount, 2)) as spent " + 
                                                                                                "FROM offered_meal O, used_product UP, storage_product SP " + 
                                                                                                "WHERE UP.offered_meal_id = O.id AND " + 
                                                                                                "UP.storage_product_id = SP.id AND  " + 
                                                                                                "O.state_id = 5 " + 
                                                                                                "GROUP BY O.ID, O.menu_id " + 
                                                                                                ") PU, " + 
                                                                                                "menu MN, " + 
                                                                                                "meal ML " + 
                                                                                          "WHERE PU.menu_id = MN.id and MN.meal_id = ML.id " + 
                                                                                          "GROUP BY PU.menu_id&pas=Delishes228"));

            ReportProgress.Value = 10;

            int Delta = 80 / (3 * MS.Count);

            PrintWord<MealStat>(new List<string>() { "Блюдо", "Продано", "Заработано", "Потрачено", "Профит" },
                            (MLS, i) =>
                            {
                                MealStat M = MLS as MealStat;

                                ReportProgress.Increment(Delta);

                                switch (i)
                                {

                                    case 0: return M.name; break;
                                    case 1: return M.sold.ToString(); break;
                                    case 2: return M.total_earned.ToString(); break;
                                    case 3: return M.total_spent.ToString(); break;
                                    case 4: return (M.total_earned - M.total_spent).ToString(); break;
                                    default: return ""; break;
                                }
                            }, MS, "Статистика проданных блюд");

            this.UseWaitCursor = false;
            ReportProgress.Value = 100;
        }

        private void PrintWord<Q>(List<string> headers, ValueAt<Q> V, List<Q> Values, string head)
        {

            foreach (Process P in Process.GetProcessesByName("WINWORD"))
                P.Kill();

            this.UseWaitCursor = true;
            FileStream FS = File.Create(Environment.CurrentDirectory + "/Print.doc");
            FS.Close();

            Application = new Word.Application();
            Object PrintPath = Environment.CurrentDirectory + "/Print.doc";

            Document = Application.Documents.Add(ref PrintPath, ref missingObj, ref missingObj, ref missingObj);
            Document.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            R = Document.Sections[1].Range;

            T = Document.Tables.Add(R, Values.Count + 3, headers.Count, missingObj, missingObj);
            T.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            T.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

            T.Rows[1].Cells.Merge();
            T.Rows[1].Cells[1].Width = 698;
            T.Rows[1].Cells[1].Range.Text = head;
            T.Rows[1].Cells[1].Range.Font.Size = 18;
            T.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            T.Rows[1].Cells[1].Range.Borders.Enable = 0;

            for (int i = 1; i <= headers.Count; i++)
            {

                T.Rows[2].Cells[i].Width = 700 / headers.Count;
                T.Rows[2].Cells[i].Range.Text = headers[i - 1];

                T.Rows[2].Cells[i].Range.Font.Size = 14;
                T.Rows[2].Cells[i].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }

            for (int i = 0; i < Values.Count; i++)
                for (int j = 0; j < headers.Count; j++)
                {
                    T.Rows[i + 3].Cells[j + 1].Width = 700 / headers.Count;
                    T.Rows[i + 3].Cells[j + 1].Range.Text = V(Values[i], j);

                    if (i % 2 == 0)
                        T.Rows[i + 3].Cells[j + 1].Shading.BackgroundPatternColor = Word.WdColor.wdColorGray20;
                }

            T.Rows[T.Rows.Count].Cells.Merge();
            T.Rows[T.Rows.Count].Cells[1].Range.Font.Size = 18;
            T.Rows[T.Rows.Count].Cells[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            T.Rows[T.Rows.Count].Cells[1].Range.Borders.Enable = 0;
            T.Rows[T.Rows.Count].Cells[1].Range.Text = "Дата отчета: " + DateTime.Now.ToShortDateString();

            try
            {
                Document.Save();
                Process.Start(Document.FullName);
                Document.Close(missingObj, missingObj, missingObj);
            }
            catch { ReportProgress.Value = 0; MessageBox.Show("Путь не выбран, отчет не создан!"); }
            this.UseWaitCursor = false;
        }
    }
}

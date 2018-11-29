namespace Reports
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MealReport = new System.Windows.Forms.Button();
            this.ProductReport = new System.Windows.Forms.Button();
            this.DriverReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MealReport
            // 
            this.MealReport.Location = new System.Drawing.Point(13, 13);
            this.MealReport.Name = "MealReport";
            this.MealReport.Size = new System.Drawing.Size(409, 41);
            this.MealReport.TabIndex = 0;
            this.MealReport.Text = "Отчет по блюдам";
            this.MealReport.UseVisualStyleBackColor = true;
            this.MealReport.Click += new System.EventHandler(this.MealReport_Click);
            // 
            // ProductReport
            // 
            this.ProductReport.Location = new System.Drawing.Point(13, 60);
            this.ProductReport.Name = "ProductReport";
            this.ProductReport.Size = new System.Drawing.Size(409, 41);
            this.ProductReport.TabIndex = 1;
            this.ProductReport.Text = "Отчет по продуктам";
            this.ProductReport.UseVisualStyleBackColor = true;
            this.ProductReport.Click += new System.EventHandler(this.ProductReport_Click);
            // 
            // DriverReport
            // 
            this.DriverReport.Location = new System.Drawing.Point(13, 107);
            this.DriverReport.Name = "DriverReport";
            this.DriverReport.Size = new System.Drawing.Size(409, 41);
            this.DriverReport.TabIndex = 2;
            this.DriverReport.Text = "Отчет по водителям";
            this.DriverReport.UseVisualStyleBackColor = true;
            this.DriverReport.Click += new System.EventHandler(this.DriverReport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 163);
            this.Controls.Add(this.DriverReport);
            this.Controls.Add(this.ProductReport);
            this.Controls.Add(this.MealReport);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MealReport;
        private System.Windows.Forms.Button ProductReport;
        private System.Windows.Forms.Button DriverReport;
    }
}


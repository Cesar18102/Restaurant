namespace ProductsStore
{
    partial class DropExpiredForm
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
            this.oldProductsList = new System.Windows.Forms.DataGridView();
            this.RemoveOldProducts = new System.Windows.Forms.Button();
            this.oldProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldProductCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldProductUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.oldProductsList)).BeginInit();
            this.SuspendLayout();
            // 
            // oldProductsList
            // 
            this.oldProductsList.AllowUserToAddRows = false;
            this.oldProductsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oldProductsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oldProductID,
            this.oldProductName,
            this.oldProductCount,
            this.oldProductUnit,
            this.oldProductPrice,
            this.oldPeriod});
            this.oldProductsList.Location = new System.Drawing.Point(12, 12);
            this.oldProductsList.Name = "oldProductsList";
            this.oldProductsList.ReadOnly = true;
            this.oldProductsList.RowHeadersVisible = false;
            this.oldProductsList.Size = new System.Drawing.Size(667, 467);
            this.oldProductsList.TabIndex = 7;
            // 
            // RemoveOldProducts
            // 
            this.RemoveOldProducts.Location = new System.Drawing.Point(12, 485);
            this.RemoveOldProducts.Name = "RemoveOldProducts";
            this.RemoveOldProducts.Size = new System.Drawing.Size(667, 120);
            this.RemoveOldProducts.TabIndex = 8;
            this.RemoveOldProducts.Text = "Списать просроченные продукты";
            this.RemoveOldProducts.UseVisualStyleBackColor = true;
            this.RemoveOldProducts.Click += new System.EventHandler(this.RemoveOldProducts_Click);
            // 
            // oldProductID
            // 
            this.oldProductID.HeaderText = "ID";
            this.oldProductID.Name = "oldProductID";
            this.oldProductID.ReadOnly = true;
            this.oldProductID.Width = 50;
            // 
            // oldProductName
            // 
            this.oldProductName.HeaderText = "Название";
            this.oldProductName.Name = "oldProductName";
            this.oldProductName.ReadOnly = true;
            this.oldProductName.Width = 120;
            // 
            // oldProductCount
            // 
            this.oldProductCount.HeaderText = "Количество";
            this.oldProductCount.Name = "oldProductCount";
            this.oldProductCount.ReadOnly = true;
            this.oldProductCount.Width = 120;
            // 
            // oldProductUnit
            // 
            this.oldProductUnit.HeaderText = "Ед. Измерения";
            this.oldProductUnit.Name = "oldProductUnit";
            this.oldProductUnit.ReadOnly = true;
            this.oldProductUnit.Width = 120;
            // 
            // oldProductPrice
            // 
            this.oldProductPrice.HeaderText = "Цена за ед.";
            this.oldProductPrice.Name = "oldProductPrice";
            this.oldProductPrice.ReadOnly = true;
            // 
            // oldPeriod
            // 
            this.oldPeriod.HeaderText = "Просрочено на";
            this.oldPeriod.Name = "oldPeriod";
            this.oldPeriod.ReadOnly = true;
            this.oldPeriod.Width = 150;
            // 
            // DropExpiredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 616);
            this.Controls.Add(this.RemoveOldProducts);
            this.Controls.Add(this.oldProductsList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "DropExpiredForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DropExpiredForm";
            this.Load += new System.EventHandler(this.DropExpiredForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oldProductsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView oldProductsList;
        private System.Windows.Forms.Button RemoveOldProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldProductCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldProductUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldPeriod;
    }
}
namespace ProductsStore
{
    partial class AddProductForm
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
            this.storeList = new System.Windows.Forms.DataGridView();
            this.FillStorePanel = new System.Windows.Forms.Panel();
            this.HeadLabel2 = new System.Windows.Forms.Label();
            this.ShelfStartDate = new System.Windows.Forms.DateTimePicker();
            this.ShelfStartDateLabel = new System.Windows.Forms.Label();
            this.PrimalPriceInput = new System.Windows.Forms.NumericUpDown();
            this.PrimalPrice = new System.Windows.Forms.Label();
            this.InsertStoredButton = new System.Windows.Forms.Button();
            this.CountInput = new System.Windows.Forms.NumericUpDown();
            this.CountLabel = new System.Windows.Forms.Label();
            this.StoreProductName = new System.Windows.Forms.ComboBox();
            this.StoreNameLabel = new System.Windows.Forms.Label();
            this.StoreID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShelfStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.storeList)).BeginInit();
            this.FillStorePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrimalPriceInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // storeList
            // 
            this.storeList.AllowUserToAddRows = false;
            this.storeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreID,
            this.StoreName,
            this.Amount,
            this.StoreUnit,
            this.Price,
            this.ShelfStart});
            this.storeList.Location = new System.Drawing.Point(12, 12);
            this.storeList.Name = "storeList";
            this.storeList.RowHeadersVisible = false;
            this.storeList.Size = new System.Drawing.Size(700, 467);
            this.storeList.TabIndex = 5;
            // 
            // FillStorePanel
            // 
            this.FillStorePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FillStorePanel.Controls.Add(this.HeadLabel2);
            this.FillStorePanel.Controls.Add(this.ShelfStartDate);
            this.FillStorePanel.Controls.Add(this.ShelfStartDateLabel);
            this.FillStorePanel.Controls.Add(this.PrimalPriceInput);
            this.FillStorePanel.Controls.Add(this.PrimalPrice);
            this.FillStorePanel.Controls.Add(this.InsertStoredButton);
            this.FillStorePanel.Controls.Add(this.CountInput);
            this.FillStorePanel.Controls.Add(this.CountLabel);
            this.FillStorePanel.Controls.Add(this.StoreProductName);
            this.FillStorePanel.Controls.Add(this.StoreNameLabel);
            this.FillStorePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FillStorePanel.Location = new System.Drawing.Point(12, 485);
            this.FillStorePanel.Name = "FillStorePanel";
            this.FillStorePanel.Size = new System.Drawing.Size(698, 221);
            this.FillStorePanel.TabIndex = 4;
            // 
            // HeadLabel2
            // 
            this.HeadLabel2.AutoSize = true;
            this.HeadLabel2.Location = new System.Drawing.Point(215, 10);
            this.HeadLabel2.Name = "HeadLabel2";
            this.HeadLabel2.Size = new System.Drawing.Size(259, 24);
            this.HeadLabel2.TabIndex = 10;
            this.HeadLabel2.Text = "Добавить продукт на склад";
            // 
            // ShelfStartDate
            // 
            this.ShelfStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ShelfStartDate.Location = new System.Drawing.Point(157, 143);
            this.ShelfStartDate.Name = "ShelfStartDate";
            this.ShelfStartDate.Size = new System.Drawing.Size(534, 29);
            this.ShelfStartDate.TabIndex = 21;
            // 
            // ShelfStartDateLabel
            // 
            this.ShelfStartDateLabel.AutoSize = true;
            this.ShelfStartDateLabel.Location = new System.Drawing.Point(3, 145);
            this.ShelfStartDateLabel.Name = "ShelfStartDateLabel";
            this.ShelfStartDateLabel.Size = new System.Drawing.Size(122, 24);
            this.ShelfStartDateLabel.TabIndex = 20;
            this.ShelfStartDateLabel.Text = "Изготовлен:";
            // 
            // PrimalPriceInput
            // 
            this.PrimalPriceInput.DecimalPlaces = 2;
            this.PrimalPriceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.PrimalPriceInput.Location = new System.Drawing.Point(157, 111);
            this.PrimalPriceInput.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.PrimalPriceInput.Name = "PrimalPriceInput";
            this.PrimalPriceInput.Size = new System.Drawing.Size(534, 29);
            this.PrimalPriceInput.TabIndex = 19;
            this.PrimalPriceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // PrimalPrice
            // 
            this.PrimalPrice.AutoSize = true;
            this.PrimalPrice.Location = new System.Drawing.Point(3, 113);
            this.PrimalPrice.Name = "PrimalPrice";
            this.PrimalPrice.Size = new System.Drawing.Size(112, 24);
            this.PrimalPrice.TabIndex = 18;
            this.PrimalPrice.Text = "Цена за ед.";
            // 
            // InsertStoredButton
            // 
            this.InsertStoredButton.Location = new System.Drawing.Point(3, 177);
            this.InsertStoredButton.Name = "InsertStoredButton";
            this.InsertStoredButton.Size = new System.Drawing.Size(688, 37);
            this.InsertStoredButton.TabIndex = 17;
            this.InsertStoredButton.Text = "Добавить";
            this.InsertStoredButton.UseVisualStyleBackColor = true;
            this.InsertStoredButton.Click += new System.EventHandler(this.InsertStoredButton_Click);
            // 
            // CountInput
            // 
            this.CountInput.DecimalPlaces = 2;
            this.CountInput.Location = new System.Drawing.Point(157, 79);
            this.CountInput.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.CountInput.Name = "CountInput";
            this.CountInput.Size = new System.Drawing.Size(534, 29);
            this.CountInput.TabIndex = 16;
            this.CountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(3, 81);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(127, 24);
            this.CountLabel.TabIndex = 15;
            this.CountLabel.Text = "Количество: ";
            // 
            // StoreProductName
            // 
            this.StoreProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StoreProductName.FormattingEnabled = true;
            this.StoreProductName.Location = new System.Drawing.Point(157, 45);
            this.StoreProductName.Name = "StoreProductName";
            this.StoreProductName.Size = new System.Drawing.Size(534, 32);
            this.StoreProductName.TabIndex = 12;
            // 
            // StoreNameLabel
            // 
            this.StoreNameLabel.AutoSize = true;
            this.StoreNameLabel.Location = new System.Drawing.Point(3, 48);
            this.StoreNameLabel.Name = "StoreNameLabel";
            this.StoreNameLabel.Size = new System.Drawing.Size(107, 24);
            this.StoreNameLabel.TabIndex = 9;
            this.StoreNameLabel.Text = "Название: ";
            // 
            // StoreID
            // 
            this.StoreID.HeaderText = "ID";
            this.StoreID.Name = "StoreID";
            this.StoreID.Width = 50;
            // 
            // StoreName
            // 
            this.StoreName.HeaderText = "Название";
            this.StoreName.Name = "StoreName";
            this.StoreName.Width = 150;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Количество";
            this.Amount.Name = "Amount";
            this.Amount.Width = 120;
            // 
            // StoreUnit
            // 
            this.StoreUnit.HeaderText = "Ед. Измерения";
            this.StoreUnit.Name = "StoreUnit";
            this.StoreUnit.Width = 120;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена за ед.";
            this.Price.Name = "Price";
            // 
            // ShelfStart
            // 
            this.ShelfStart.HeaderText = "Дата изготовления";
            this.ShelfStart.Name = "ShelfStart";
            this.ShelfStart.Width = 150;
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 718);
            this.Controls.Add(this.storeList);
            this.Controls.Add(this.FillStorePanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "AddProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddProductForm";
            this.Load += new System.EventHandler(this.AddProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.storeList)).EndInit();
            this.FillStorePanel.ResumeLayout(false);
            this.FillStorePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrimalPriceInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView storeList;
        private System.Windows.Forms.Panel FillStorePanel;
        private System.Windows.Forms.Label HeadLabel2;
        private System.Windows.Forms.DateTimePicker ShelfStartDate;
        private System.Windows.Forms.Label ShelfStartDateLabel;
        private System.Windows.Forms.NumericUpDown PrimalPriceInput;
        private System.Windows.Forms.Label PrimalPrice;
        private System.Windows.Forms.Button InsertStoredButton;
        private System.Windows.Forms.NumericUpDown CountInput;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.ComboBox StoreProductName;
        private System.Windows.Forms.Label StoreNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShelfStart;
    }
}
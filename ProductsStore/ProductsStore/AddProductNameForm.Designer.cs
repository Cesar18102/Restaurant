namespace ProductsStore
{
    partial class AddProductNameForm
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
            this.productsList = new System.Windows.Forms.DataGridView();
            this.addProductPanel = new System.Windows.Forms.Panel();
            this.HeadLabel1 = new System.Windows.Forms.Label();
            this.SubmitProduct = new System.Windows.Forms.Button();
            this.ShelfLifeInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.UnitInput = new System.Windows.Forms.ComboBox();
            this.UnitLabel = new System.Windows.Forms.Label();
            this.CategoryInput = new System.Windows.Forms.ComboBox();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.ProductNameInput = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shelfLife = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.productsList)).BeginInit();
            this.addProductPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShelfLifeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // productsList
            // 
            this.productsList.AllowUserToAddRows = false;
            this.productsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProductName,
            this.Category,
            this.Unit,
            this.shelfLife});
            this.productsList.Location = new System.Drawing.Point(12, 12);
            this.productsList.Name = "productsList";
            this.productsList.RowHeadersVisible = false;
            this.productsList.Size = new System.Drawing.Size(598, 398);
            this.productsList.TabIndex = 4;
            // 
            // addProductPanel
            // 
            this.addProductPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.addProductPanel.Controls.Add(this.HeadLabel1);
            this.addProductPanel.Controls.Add(this.SubmitProduct);
            this.addProductPanel.Controls.Add(this.ShelfLifeInput);
            this.addProductPanel.Controls.Add(this.label1);
            this.addProductPanel.Controls.Add(this.UnitInput);
            this.addProductPanel.Controls.Add(this.UnitLabel);
            this.addProductPanel.Controls.Add(this.CategoryInput);
            this.addProductPanel.Controls.Add(this.CategoryLabel);
            this.addProductPanel.Controls.Add(this.ProductNameInput);
            this.addProductPanel.Controls.Add(this.NameLabel);
            this.addProductPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addProductPanel.Location = new System.Drawing.Point(12, 416);
            this.addProductPanel.Name = "addProductPanel";
            this.addProductPanel.Size = new System.Drawing.Size(598, 221);
            this.addProductPanel.TabIndex = 3;
            // 
            // HeadLabel1
            // 
            this.HeadLabel1.AutoSize = true;
            this.HeadLabel1.Location = new System.Drawing.Point(134, 10);
            this.HeadLabel1.Name = "HeadLabel1";
            this.HeadLabel1.Size = new System.Drawing.Size(324, 24);
            this.HeadLabel1.TabIndex = 9;
            this.HeadLabel1.Text = "Добавить наименование продукта";
            // 
            // SubmitProduct
            // 
            this.SubmitProduct.Location = new System.Drawing.Point(3, 177);
            this.SubmitProduct.Name = "SubmitProduct";
            this.SubmitProduct.Size = new System.Drawing.Size(588, 37);
            this.SubmitProduct.TabIndex = 8;
            this.SubmitProduct.Text = "Добавить";
            this.SubmitProduct.UseVisualStyleBackColor = true;
            this.SubmitProduct.Click += new System.EventHandler(this.SubmitProduct_Click);
            // 
            // ShelfLifeInput
            // 
            this.ShelfLifeInput.Location = new System.Drawing.Point(187, 145);
            this.ShelfLifeInput.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.ShelfLifeInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ShelfLifeInput.Name = "ShelfLifeInput";
            this.ShelfLifeInput.Size = new System.Drawing.Size(404, 29);
            this.ShelfLifeInput.TabIndex = 7;
            this.ShelfLifeInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Срок жизни, часов";
            // 
            // UnitInput
            // 
            this.UnitInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnitInput.FormattingEnabled = true;
            this.UnitInput.Location = new System.Drawing.Point(187, 111);
            this.UnitInput.Name = "UnitInput";
            this.UnitInput.Size = new System.Drawing.Size(404, 32);
            this.UnitInput.TabIndex = 5;
            // 
            // UnitLabel
            // 
            this.UnitLabel.AutoSize = true;
            this.UnitLabel.Location = new System.Drawing.Point(3, 114);
            this.UnitLabel.Name = "UnitLabel";
            this.UnitLabel.Size = new System.Drawing.Size(154, 24);
            this.UnitLabel.TabIndex = 4;
            this.UnitLabel.Text = "Ед. измерения: ";
            // 
            // CategoryInput
            // 
            this.CategoryInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryInput.FormattingEnabled = true;
            this.CategoryInput.Location = new System.Drawing.Point(187, 77);
            this.CategoryInput.Name = "CategoryInput";
            this.CategoryInput.Size = new System.Drawing.Size(404, 32);
            this.CategoryInput.TabIndex = 3;
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(3, 80);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(115, 24);
            this.CategoryLabel.TabIndex = 2;
            this.CategoryLabel.Text = "Категория: ";
            // 
            // ProductNameInput
            // 
            this.ProductNameInput.Location = new System.Drawing.Point(187, 45);
            this.ProductNameInput.Name = "ProductNameInput";
            this.ProductNameInput.Size = new System.Drawing.Size(404, 29);
            this.ProductNameInput.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(3, 48);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(107, 24);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Название: ";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Название";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 150;
            // 
            // Category
            // 
            this.Category.HeaderText = "Категория";
            this.Category.Name = "Category";
            this.Category.Width = 120;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Ед. измерения";
            this.Unit.Name = "Unit";
            this.Unit.Width = 120;
            // 
            // shelfLife
            // 
            this.shelfLife.HeaderText = "Срок годности";
            this.shelfLife.Name = "shelfLife";
            this.shelfLife.Width = 150;
            // 
            // AddProductNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 649);
            this.Controls.Add(this.productsList);
            this.Controls.Add(this.addProductPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "AddProductNameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddProductNameForm";
            this.Load += new System.EventHandler(this.AddProductNameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsList)).EndInit();
            this.addProductPanel.ResumeLayout(false);
            this.addProductPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShelfLifeInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productsList;
        private System.Windows.Forms.Panel addProductPanel;
        private System.Windows.Forms.Label HeadLabel1;
        private System.Windows.Forms.Button SubmitProduct;
        private System.Windows.Forms.NumericUpDown ShelfLifeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox UnitInput;
        private System.Windows.Forms.Label UnitLabel;
        private System.Windows.Forms.ComboBox CategoryInput;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.TextBox ProductNameInput;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn shelfLife;
    }
}
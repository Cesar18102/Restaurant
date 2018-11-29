namespace ProductsStore
{
    partial class Storage
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
            this.AddProductName = new System.Windows.Forms.Button();
            this.AddProduct = new System.Windows.Forms.Button();
            this.DropExpired = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddProductName
            // 
            this.AddProductName.Location = new System.Drawing.Point(12, 85);
            this.AddProductName.Name = "AddProductName";
            this.AddProductName.Size = new System.Drawing.Size(426, 58);
            this.AddProductName.TabIndex = 0;
            this.AddProductName.Text = "Добавить наименование продукта";
            this.AddProductName.UseVisualStyleBackColor = true;
            this.AddProductName.Click += new System.EventHandler(this.AddProductName_Click);
            // 
            // AddProduct
            // 
            this.AddProduct.Location = new System.Drawing.Point(12, 149);
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(426, 58);
            this.AddProduct.TabIndex = 1;
            this.AddProduct.Text = "Добавить продукт на склад";
            this.AddProduct.UseVisualStyleBackColor = true;
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // DropExpired
            // 
            this.DropExpired.Location = new System.Drawing.Point(12, 213);
            this.DropExpired.Name = "DropExpired";
            this.DropExpired.Size = new System.Drawing.Size(426, 58);
            this.DropExpired.TabIndex = 2;
            this.DropExpired.Text = "Списать просроченые продукты";
            this.DropExpired.UseVisualStyleBackColor = true;
            this.DropExpired.Click += new System.EventHandler(this.DropExpired_Click);
            // 
            // Storage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 369);
            this.Controls.Add(this.DropExpired);
            this.Controls.Add(this.AddProduct);
            this.Controls.Add(this.AddProductName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Storage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StorageKeeper";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddProductName;
        private System.Windows.Forms.Button AddProduct;
        private System.Windows.Forms.Button DropExpired;

    }
}


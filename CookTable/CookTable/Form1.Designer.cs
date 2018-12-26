namespace CookTable
{
    partial class Cooker
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
            this.components = new System.ComponentModel.Container();
            this.offeredmeals = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubOfferID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MealId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MealCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MealWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeSpent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reciepe = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CookStart = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OfferIdHidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OfferedMealIdHidden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateProgress = new System.Windows.Forms.ProgressBar();
            this.UpdateBarLabel = new System.Windows.Forms.Label();
            this.ProgressTimer = new System.Windows.Forms.Timer(this.components);
            this.TimeLabel = new System.Windows.Forms.Label();
            this.ForceUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OfferIDCB = new System.Windows.Forms.CheckBox();
            this.AcceptedCB = new System.Windows.Forms.CheckBox();
            this.MealIDCB = new System.Windows.Forms.CheckBox();
            this.ReadyCB = new System.Windows.Forms.CheckBox();
            this.OfferIDVAL = new System.Windows.Forms.NumericUpDown();
            this.MealIDVAL = new System.Windows.Forms.NumericUpDown();
            this.Reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.offeredmeals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfferIDVAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MealIDVAL)).BeginInit();
            this.SuspendLayout();
            // 
            // offeredmeals
            // 
            this.offeredmeals.AllowUserToAddRows = false;
            this.offeredmeals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.offeredmeals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.offeredmeals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.offeredmeals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SubOfferID,
            this.MealId,
            this.MealName,
            this.MealCount,
            this.MealWeight,
            this.Start,
            this.Comment,
            this.TimeSpent,
            this.Reciepe,
            this.CookStart,
            this.State,
            this.OfferIdHidden,
            this.OfferedMealIdHidden});
            this.offeredmeals.Location = new System.Drawing.Point(14, 12);
            this.offeredmeals.Margin = new System.Windows.Forms.Padding(0);
            this.offeredmeals.Name = "offeredmeals";
            this.offeredmeals.RowHeadersVisible = false;
            this.offeredmeals.RowTemplate.Height = 40;
            this.offeredmeals.Size = new System.Drawing.Size(1400, 649);
            this.offeredmeals.TabIndex = 0;
            this.offeredmeals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.offeredmeals_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID заказа";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // SubOfferID
            // 
            this.SubOfferID.HeaderText = "ID позиции";
            this.SubOfferID.Name = "SubOfferID";
            this.SubOfferID.ReadOnly = true;
            // 
            // MealId
            // 
            this.MealId.HeaderText = "ID блюда";
            this.MealId.Name = "MealId";
            this.MealId.ReadOnly = true;
            // 
            // MealName
            // 
            this.MealName.HeaderText = "Блюдо";
            this.MealName.Name = "MealName";
            this.MealName.ReadOnly = true;
            // 
            // MealCount
            // 
            this.MealCount.HeaderText = "Кол-во";
            this.MealCount.Name = "MealCount";
            this.MealCount.ReadOnly = true;
            // 
            // MealWeight
            // 
            this.MealWeight.HeaderText = "Вес блюда";
            this.MealWeight.Name = "MealWeight";
            this.MealWeight.ReadOnly = true;
            // 
            // Start
            // 
            this.Start.HeaderText = "Время заказа";
            this.Start.Name = "Start";
            this.Start.ReadOnly = true;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Комментарий";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // TimeSpent
            // 
            this.TimeSpent.HeaderText = "Минут прошло";
            this.TimeSpent.Name = "TimeSpent";
            // 
            // Reciepe
            // 
            this.Reciepe.HeaderText = "Рецепт";
            this.Reciepe.Name = "Reciepe";
            this.Reciepe.ReadOnly = true;
            this.Reciepe.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Reciepe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CookStart
            // 
            this.CookStart.HeaderText = "Начало готовки";
            this.CookStart.Name = "CookStart";
            this.CookStart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CookStart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // State
            // 
            this.State.HeaderText = "Готовность";
            this.State.Name = "State";
            this.State.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.State.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // OfferIdHidden
            // 
            this.OfferIdHidden.HeaderText = "Заказ";
            this.OfferIdHidden.Name = "OfferIdHidden";
            this.OfferIdHidden.ReadOnly = true;
            this.OfferIdHidden.Visible = false;
            // 
            // OfferedMealIdHidden
            // 
            this.OfferedMealIdHidden.HeaderText = "Позиция";
            this.OfferedMealIdHidden.Name = "OfferedMealIdHidden";
            this.OfferedMealIdHidden.ReadOnly = true;
            this.OfferedMealIdHidden.Visible = false;
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 60000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // UpdateProgress
            // 
            this.UpdateProgress.Location = new System.Drawing.Point(169, 686);
            this.UpdateProgress.Margin = new System.Windows.Forms.Padding(4);
            this.UpdateProgress.Name = "UpdateProgress";
            this.UpdateProgress.Size = new System.Drawing.Size(770, 68);
            this.UpdateProgress.TabIndex = 1;
            // 
            // UpdateBarLabel
            // 
            this.UpdateBarLabel.AutoSize = true;
            this.UpdateBarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateBarLabel.Location = new System.Drawing.Point(13, 707);
            this.UpdateBarLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UpdateBarLabel.Name = "UpdateBarLabel";
            this.UpdateBarLabel.Size = new System.Drawing.Size(148, 24);
            this.UpdateBarLabel.TabIndex = 2;
            this.UpdateBarLabel.Text = "До обновления";
            // 
            // ProgressTimer
            // 
            this.ProgressTimer.Interval = 1000;
            this.ProgressTimer.Tick += new System.EventHandler(this.ProgressTimer_Tick);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.BackColor = System.Drawing.SystemColors.Control;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeLabel.Location = new System.Drawing.Point(540, 707);
            this.TimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(30, 24);
            this.TimeLabel.TabIndex = 3;
            this.TimeLabel.Text = "60";
            // 
            // ForceUpdate
            // 
            this.ForceUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForceUpdate.Location = new System.Drawing.Point(946, 686);
            this.ForceUpdate.Name = "ForceUpdate";
            this.ForceUpdate.Size = new System.Drawing.Size(465, 68);
            this.ForceUpdate.TabIndex = 4;
            this.ForceUpdate.Text = "Принудительное обновление";
            this.ForceUpdate.UseVisualStyleBackColor = true;
            this.ForceUpdate.Click += new System.EventHandler(this.ForceUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(620, 758);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Фильтры";
            // 
            // OfferIDCB
            // 
            this.OfferIDCB.AutoSize = true;
            this.OfferIDCB.Location = new System.Drawing.Point(374, 800);
            this.OfferIDCB.Name = "OfferIDCB";
            this.OfferIDCB.Size = new System.Drawing.Size(95, 22);
            this.OfferIDCB.TabIndex = 6;
            this.OfferIDCB.Text = "ID Заказа";
            this.OfferIDCB.UseVisualStyleBackColor = true;
            this.OfferIDCB.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // AcceptedCB
            // 
            this.AcceptedCB.AutoSize = true;
            this.AcceptedCB.Location = new System.Drawing.Point(712, 800);
            this.AcceptedCB.Name = "AcceptedCB";
            this.AcceptedCB.Size = new System.Drawing.Size(190, 22);
            this.AcceptedCB.TabIndex = 7;
            this.AcceptedCB.Text = "Принято к выполнению";
            this.AcceptedCB.UseVisualStyleBackColor = true;
            this.AcceptedCB.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // MealIDCB
            // 
            this.MealIDCB.AutoSize = true;
            this.MealIDCB.Location = new System.Drawing.Point(374, 830);
            this.MealIDCB.Name = "MealIDCB";
            this.MealIDCB.Size = new System.Drawing.Size(92, 22);
            this.MealIDCB.TabIndex = 8;
            this.MealIDCB.Text = "ID Блюда";
            this.MealIDCB.UseVisualStyleBackColor = true;
            this.MealIDCB.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // ReadyCB
            // 
            this.ReadyCB.AutoSize = true;
            this.ReadyCB.Location = new System.Drawing.Point(712, 830);
            this.ReadyCB.Name = "ReadyCB";
            this.ReadyCB.Size = new System.Drawing.Size(78, 22);
            this.ReadyCB.TabIndex = 9;
            this.ReadyCB.Text = "Готово";
            this.ReadyCB.UseVisualStyleBackColor = true;
            this.ReadyCB.CheckedChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // OfferIDVAL
            // 
            this.OfferIDVAL.Location = new System.Drawing.Point(475, 799);
            this.OfferIDVAL.Name = "OfferIDVAL";
            this.OfferIDVAL.Size = new System.Drawing.Size(171, 24);
            this.OfferIDVAL.TabIndex = 10;
            this.OfferIDVAL.ValueChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // MealIDVAL
            // 
            this.MealIDVAL.Location = new System.Drawing.Point(475, 829);
            this.MealIDVAL.Name = "MealIDVAL";
            this.MealIDVAL.Size = new System.Drawing.Size(171, 24);
            this.MealIDVAL.TabIndex = 11;
            this.MealIDVAL.ValueChanged += new System.EventHandler(this.Filter_CheckedChanged);
            // 
            // Reset
            // 
            this.Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Reset.Location = new System.Drawing.Point(919, 785);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(252, 68);
            this.Reset.TabIndex = 12;
            this.Reset.Text = "Опустить все флаги";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Cooker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 881);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.MealIDVAL);
            this.Controls.Add(this.OfferIDVAL);
            this.Controls.Add(this.ReadyCB);
            this.Controls.Add(this.MealIDCB);
            this.Controls.Add(this.AcceptedCB);
            this.Controls.Add(this.OfferIDCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ForceUpdate);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.UpdateBarLabel);
            this.Controls.Add(this.UpdateProgress);
            this.Controls.Add(this.offeredmeals);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Cooker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CookTable";
            this.Load += new System.EventHandler(this.Cooker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.offeredmeals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfferIDVAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MealIDVAL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView offeredmeals;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubOfferID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MealId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MealCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MealWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSpent;
        private System.Windows.Forms.DataGridViewButtonColumn Reciepe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CookStart;
        private System.Windows.Forms.DataGridViewCheckBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfferIdHidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfferedMealIdHidden;
        private System.Windows.Forms.ProgressBar UpdateProgress;
        private System.Windows.Forms.Label UpdateBarLabel;
        private System.Windows.Forms.Timer ProgressTimer;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Button ForceUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox OfferIDCB;
        private System.Windows.Forms.CheckBox AcceptedCB;
        private System.Windows.Forms.CheckBox MealIDCB;
        private System.Windows.Forms.CheckBox ReadyCB;
        private System.Windows.Forms.NumericUpDown OfferIDVAL;
        private System.Windows.Forms.NumericUpDown MealIDVAL;
        private System.Windows.Forms.Button Reset;
    }
}


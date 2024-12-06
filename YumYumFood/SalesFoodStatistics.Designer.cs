namespace YumYumFood
{
    partial class SalesFoodStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_chart = new System.Windows.Forms.DataGridView();
            this.food_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.food_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.food_in_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.food_out_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.food_difference_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_group = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_sort = new System.Windows.Forms.ComboBox();
            this.lbl_status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("세방고딕 Regular", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(299, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "식자재 통계";
            // 
            // dgv_chart
            // 
            this.dgv_chart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.food_code,
            this.food_name,
            this.food_in_price,
            this.food_out_price,
            this.food_difference_price});
            this.dgv_chart.Location = new System.Drawing.Point(12, 124);
            this.dgv_chart.Name = "dgv_chart";
            this.dgv_chart.RowHeadersWidth = 51;
            this.dgv_chart.RowTemplate.Height = 27;
            this.dgv_chart.Size = new System.Drawing.Size(776, 314);
            this.dgv_chart.TabIndex = 1;
            this.dgv_chart.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_chart_CellDoubleClick);
            // 
            // food_code
            // 
            this.food_code.HeaderText = "코드";
            this.food_code.MinimumWidth = 6;
            this.food_code.Name = "food_code";
            this.food_code.ReadOnly = true;
            this.food_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.food_code.Width = 125;
            // 
            // food_name
            // 
            this.food_name.HeaderText = "품명";
            this.food_name.MinimumWidth = 6;
            this.food_name.Name = "food_name";
            this.food_name.ReadOnly = true;
            this.food_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.food_name.Width = 125;
            // 
            // food_in_price
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.food_in_price.DefaultCellStyle = dataGridViewCellStyle4;
            this.food_in_price.HeaderText = "매입가";
            this.food_in_price.MinimumWidth = 6;
            this.food_in_price.Name = "food_in_price";
            this.food_in_price.ReadOnly = true;
            this.food_in_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.food_in_price.Width = 125;
            // 
            // food_out_price
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.food_out_price.DefaultCellStyle = dataGridViewCellStyle5;
            this.food_out_price.HeaderText = "출고가";
            this.food_out_price.MinimumWidth = 6;
            this.food_out_price.Name = "food_out_price";
            this.food_out_price.ReadOnly = true;
            this.food_out_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.food_out_price.Width = 125;
            // 
            // food_difference_price
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.food_difference_price.DefaultCellStyle = dataGridViewCellStyle6;
            this.food_difference_price.HeaderText = "차액 (이익)";
            this.food_difference_price.MinimumWidth = 6;
            this.food_difference_price.Name = "food_difference_price";
            this.food_difference_price.ReadOnly = true;
            this.food_difference_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.food_difference_price.Width = 125;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("세방고딕 Regular", 16.2F);
            this.btn_search.Location = new System.Drawing.Point(673, 74);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(115, 44);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "조회";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("세방고딕 Regular", 12F);
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "그룹";
            // 
            // cb_group
            // 
            this.cb_group.Font = new System.Drawing.Font("세방고딕 Regular", 13.8F);
            this.cb_group.FormattingEnabled = true;
            this.cb_group.Items.AddRange(new object[] {
            "전체",
            "년",
            "월"});
            this.cb_group.Location = new System.Drawing.Point(67, 81);
            this.cb_group.Name = "cb_group";
            this.cb_group.Size = new System.Drawing.Size(155, 36);
            this.cb_group.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("세방고딕 Regular", 12F);
            this.label3.Location = new System.Drawing.Point(258, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "정렬 기준";
            // 
            // cb_sort
            // 
            this.cb_sort.Font = new System.Drawing.Font("세방고딕 Regular", 13.8F);
            this.cb_sort.FormattingEnabled = true;
            this.cb_sort.Items.AddRange(new object[] {
            "코드",
            "품명",
            "매입가",
            "출고가",
            "차액 (이익)"});
            this.cb_sort.Location = new System.Drawing.Point(360, 81);
            this.cb_sort.Name = "cb_sort";
            this.cb_sort.Size = new System.Drawing.Size(225, 36);
            this.cb_sort.TabIndex = 6;
            // 
            // lbl_status
            // 
            this.lbl_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_status.Font = new System.Drawing.Font("세방고딕 Regular", 9F);
            this.lbl_status.Location = new System.Drawing.Point(493, 9);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(295, 62);
            this.lbl_status.TabIndex = 7;
            this.lbl_status.Text = "상태";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SalesFoodStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.cb_sort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_group);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.dgv_chart);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SalesFoodStatistics";
            this.Text = "SalesFoodStatistics";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_chart;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_group;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_sort;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn food_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn food_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn food_in_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn food_out_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn food_difference_price;
    }
}
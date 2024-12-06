namespace YumYumFood
{
    partial class SalesOutputStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_status = new System.Windows.Forms.Label();
            this.cb_sort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_group = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.dgv_chart = new System.Windows.Forms.DataGridView();
            this.output_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.output_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_status
            // 
            this.lbl_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_status.Font = new System.Drawing.Font("세방고딕 Regular", 9F);
            this.lbl_status.Location = new System.Drawing.Point(493, 9);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(295, 62);
            this.lbl_status.TabIndex = 23;
            this.lbl_status.Text = "상태";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cb_sort
            // 
            this.cb_sort.Font = new System.Drawing.Font("세방고딕 Regular", 13.8F);
            this.cb_sort.FormattingEnabled = true;
            this.cb_sort.Items.AddRange(new object[] {
            "출고처명",
            "출고가"});
            this.cb_sort.Location = new System.Drawing.Point(360, 81);
            this.cb_sort.Name = "cb_sort";
            this.cb_sort.Size = new System.Drawing.Size(225, 36);
            this.cb_sort.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("세방고딕 Regular", 12F);
            this.label3.Location = new System.Drawing.Point(258, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 21;
            this.label3.Text = "정렬 기준";
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
            this.cb_group.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("세방고딕 Regular", 12F);
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "그룹";
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("세방고딕 Regular", 16.2F);
            this.btn_search.Location = new System.Drawing.Point(673, 74);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(115, 44);
            this.btn_search.TabIndex = 18;
            this.btn_search.Text = "조회";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dgv_chart
            // 
            this.dgv_chart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.output_name,
            this.output_price});
            this.dgv_chart.Location = new System.Drawing.Point(12, 124);
            this.dgv_chart.Name = "dgv_chart";
            this.dgv_chart.RowHeadersWidth = 51;
            this.dgv_chart.RowTemplate.Height = 27;
            this.dgv_chart.Size = new System.Drawing.Size(776, 314);
            this.dgv_chart.TabIndex = 17;
            this.dgv_chart.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_chart_CellDoubleClick);
            // 
            // output_name
            // 
            this.output_name.HeaderText = "출고처명";
            this.output_name.MinimumWidth = 6;
            this.output_name.Name = "output_name";
            this.output_name.ReadOnly = true;
            this.output_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.output_name.Width = 125;
            // 
            // output_price
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.output_price.DefaultCellStyle = dataGridViewCellStyle2;
            this.output_price.HeaderText = "출고가";
            this.output_price.MinimumWidth = 6;
            this.output_price.Name = "output_price";
            this.output_price.ReadOnly = true;
            this.output_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.output_price.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("세방고딕 Regular", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(299, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 39);
            this.label1.TabIndex = 16;
            this.label1.Text = "출고처 통계";
            // 
            // SalesOutputStatistics
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
            this.Name = "SalesOutputStatistics";
            this.Text = "SalesOutputStatistics";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ComboBox cb_sort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_group;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView dgv_chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn output_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn output_price;
    }
}
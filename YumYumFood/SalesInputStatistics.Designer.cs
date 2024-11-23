namespace YumYumFood
{
    partial class SalesInputStatistics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_status = new System.Windows.Forms.Label();
            this.cb_sort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_group = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.dgv_chart = new System.Windows.Forms.DataGridView();
            this.input_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.input_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_status
            // 
            this.lbl_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_status.Location = new System.Drawing.Point(493, 9);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(295, 62);
            this.lbl_status.TabIndex = 15;
            this.lbl_status.Text = "상태";
            this.lbl_status.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cb_sort
            // 
            this.cb_sort.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cb_sort.FormattingEnabled = true;
            this.cb_sort.Items.AddRange(new object[] {
            "매입처명",
            "매입가"});
            this.cb_sort.Location = new System.Drawing.Point(360, 81);
            this.cb_sort.Name = "cb_sort";
            this.cb_sort.Size = new System.Drawing.Size(225, 31);
            this.cb_sort.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(258, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "정렬 기준";
            // 
            // cb_group
            // 
            this.cb_group.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cb_group.FormattingEnabled = true;
            this.cb_group.Items.AddRange(new object[] {
            "전체",
            "년",
            "월"});
            this.cb_group.Location = new System.Drawing.Point(67, 81);
            this.cb_group.Name = "cb_group";
            this.cb_group.Size = new System.Drawing.Size(155, 31);
            this.cb_group.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "그룹";
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_search.Location = new System.Drawing.Point(673, 74);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(115, 44);
            this.btn_search.TabIndex = 10;
            this.btn_search.Text = "조회";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // dgv_chart
            // 
            this.dgv_chart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_chart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.input_name,
            this.input_price});
            this.dgv_chart.Location = new System.Drawing.Point(12, 124);
            this.dgv_chart.Name = "dgv_chart";
            this.dgv_chart.RowHeadersWidth = 51;
            this.dgv_chart.RowTemplate.Height = 27;
            this.dgv_chart.Size = new System.Drawing.Size(776, 314);
            this.dgv_chart.TabIndex = 9;
            this.dgv_chart.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_chart_CellDoubleClick);
            // 
            // input_name
            // 
            this.input_name.HeaderText = "매입처명";
            this.input_name.MinimumWidth = 6;
            this.input_name.Name = "input_name";
            this.input_name.ReadOnly = true;
            this.input_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.input_name.Width = 125;
            // 
            // input_price
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.input_price.DefaultCellStyle = dataGridViewCellStyle7;
            this.input_price.HeaderText = "매입가";
            this.input_price.MinimumWidth = 6;
            this.input_price.Name = "input_price";
            this.input_price.ReadOnly = true;
            this.input_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.input_price.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(299, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 33);
            this.label1.TabIndex = 8;
            this.label1.Text = "매입처 통계";
            // 
            // SalesInputStatistics
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
            this.Name = "SalesInputStatistics";
            this.Text = "SalesInputStatistics";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn input_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn input_price;
    }
}
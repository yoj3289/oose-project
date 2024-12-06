namespace YumYumFood
{
    partial class SalesInputGrowth
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
            this.pnl_chart = new System.Windows.Forms.Panel();
            this.cb_group = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnl_chart
            // 
            this.pnl_chart.AutoScroll = true;
            this.pnl_chart.BackColor = System.Drawing.Color.White;
            this.pnl_chart.Location = new System.Drawing.Point(12, 112);
            this.pnl_chart.Name = "pnl_chart";
            this.pnl_chart.Size = new System.Drawing.Size(737, 273);
            this.pnl_chart.TabIndex = 14;
            // 
            // cb_group
            // 
            this.cb_group.Font = new System.Drawing.Font("세방고딕 Regular", 13.8F);
            this.cb_group.FormattingEnabled = true;
            this.cb_group.Items.AddRange(new object[] {
            "년",
            "월"});
            this.cb_group.Location = new System.Drawing.Point(67, 69);
            this.cb_group.Name = "cb_group";
            this.cb_group.Size = new System.Drawing.Size(155, 36);
            this.cb_group.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("세방고딕 Regular", 12F);
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "그룹";
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("세방고딕 Regular", 16.2F);
            this.btn_search.Location = new System.Drawing.Point(634, 62);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(115, 44);
            this.btn_search.TabIndex = 11;
            this.btn_search.Text = "조회";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_title.Font = new System.Drawing.Font("세방고딕 Regular", 19.8F, System.Drawing.FontStyle.Bold);
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(737, 50);
            this.lbl_title.TabIndex = 10;
            this.lbl_title.Text = "의 매입가 성장도";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SalesInputGrowth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 397);
            this.Controls.Add(this.pnl_chart);
            this.Controls.Add(this.cb_group);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.lbl_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SalesInputGrowth";
            this.Text = "SalesInputGrowth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_chart;
        private System.Windows.Forms.ComboBox cb_group;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lbl_title;
    }
}
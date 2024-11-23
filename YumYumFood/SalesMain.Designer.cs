namespace YumYumFood
{
    partial class SalesMain
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
            this.toSalesFoodStatisticsBtn = new System.Windows.Forms.Button();
            this.toSalesInputStatisticsBtn = new System.Windows.Forms.Button();
            this.toSalesOutputStatisticsBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_best = new System.Windows.Forms.Label();
            this.lbl_worst = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toSalesFoodStatisticsBtn
            // 
            this.toSalesFoodStatisticsBtn.Font = new System.Drawing.Font("굴림", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toSalesFoodStatisticsBtn.Location = new System.Drawing.Point(12, 263);
            this.toSalesFoodStatisticsBtn.Name = "toSalesFoodStatisticsBtn";
            this.toSalesFoodStatisticsBtn.Size = new System.Drawing.Size(252, 175);
            this.toSalesFoodStatisticsBtn.TabIndex = 0;
            this.toSalesFoodStatisticsBtn.Text = "식자재 통계";
            this.toSalesFoodStatisticsBtn.UseVisualStyleBackColor = true;
            this.toSalesFoodStatisticsBtn.Click += new System.EventHandler(this.toSalesFoodStatisticsBtn_Click);
            // 
            // toSalesInputStatisticsBtn
            // 
            this.toSalesInputStatisticsBtn.Font = new System.Drawing.Font("굴림", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toSalesInputStatisticsBtn.Location = new System.Drawing.Point(274, 263);
            this.toSalesInputStatisticsBtn.Name = "toSalesInputStatisticsBtn";
            this.toSalesInputStatisticsBtn.Size = new System.Drawing.Size(252, 175);
            this.toSalesInputStatisticsBtn.TabIndex = 1;
            this.toSalesInputStatisticsBtn.Text = "매입처 통계";
            this.toSalesInputStatisticsBtn.UseVisualStyleBackColor = true;
            this.toSalesInputStatisticsBtn.Click += new System.EventHandler(this.toSalesInputStatisticsBtn_Click);
            // 
            // toSalesOutputStatisticsBtn
            // 
            this.toSalesOutputStatisticsBtn.Font = new System.Drawing.Font("굴림", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toSalesOutputStatisticsBtn.Location = new System.Drawing.Point(536, 263);
            this.toSalesOutputStatisticsBtn.Name = "toSalesOutputStatisticsBtn";
            this.toSalesOutputStatisticsBtn.Size = new System.Drawing.Size(252, 175);
            this.toSalesOutputStatisticsBtn.TabIndex = 2;
            this.toSalesOutputStatisticsBtn.Text = "출고처 통계";
            this.toSalesOutputStatisticsBtn.UseVisualStyleBackColor = true;
            this.toSalesOutputStatisticsBtn.Click += new System.EventHandler(this.toSalesOutputStatisticsBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 33);
            this.label1.TabIndex = 17;
            this.label1.Text = "매출 관리 (통계)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbl_best);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 175);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbl_worst);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(424, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 175);
            this.panel2.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(358, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "BEST";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "WORST";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_best
            // 
            this.lbl_best.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_best.ForeColor = System.Drawing.Color.Blue;
            this.lbl_best.Location = new System.Drawing.Point(3, 46);
            this.lbl_best.Name = "lbl_best";
            this.lbl_best.Size = new System.Drawing.Size(358, 113);
            this.lbl_best.TabIndex = 1;
            this.lbl_best.Text = "1.";
            this.lbl_best.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_worst
            // 
            this.lbl_worst.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_worst.ForeColor = System.Drawing.Color.Red;
            this.lbl_worst.Location = new System.Drawing.Point(3, 46);
            this.lbl_worst.Name = "lbl_worst";
            this.lbl_worst.Size = new System.Drawing.Size(358, 113);
            this.lbl_worst.TabIndex = 2;
            this.lbl_worst.Text = "1.";
            this.lbl_worst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SalesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toSalesOutputStatisticsBtn);
            this.Controls.Add(this.toSalesInputStatisticsBtn);
            this.Controls.Add(this.toSalesFoodStatisticsBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SalesMain";
            this.Text = "SalesMain";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toSalesFoodStatisticsBtn;
        private System.Windows.Forms.Button toSalesInputStatisticsBtn;
        private System.Windows.Forms.Button toSalesOutputStatisticsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_best;
        private System.Windows.Forms.Label lbl_worst;
    }
}
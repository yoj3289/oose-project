namespace YumYumFood
{
    partial class FoodInput_Search
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
            this.foodIn_Grid = new System.Windows.Forms.DataGridView();
            this.Submit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.foodInput_text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.foodIn_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // foodIn_Grid
            // 
            this.foodIn_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foodIn_Grid.Location = new System.Drawing.Point(18, 48);
            this.foodIn_Grid.Margin = new System.Windows.Forms.Padding(2);
            this.foodIn_Grid.Name = "foodIn_Grid";
            this.foodIn_Grid.RowHeadersWidth = 62;
            this.foodIn_Grid.RowTemplate.Height = 30;
            this.foodIn_Grid.Size = new System.Drawing.Size(869, 379);
            this.foodIn_Grid.TabIndex = 43;
            // 
            // Submit
            // 
            this.Submit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Submit.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Submit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Submit.Location = new System.Drawing.Point(860, 12);
            this.Submit.Margin = new System.Windows.Forms.Padding(2);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(27, 26);
            this.Submit.TabIndex = 42;
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(15, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 41;
            this.label6.Text = "입고조회";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(683, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "입고처";
            // 
            // foodInput_text
            // 
            this.foodInput_text.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.foodInput_text.Location = new System.Drawing.Point(751, 14);
            this.foodInput_text.Margin = new System.Windows.Forms.Padding(2);
            this.foodInput_text.Name = "foodInput_text";
            this.foodInput_text.Size = new System.Drawing.Size(106, 26);
            this.foodInput_text.TabIndex = 39;
            // 
            // FoodInput_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 439);
            this.Controls.Add(this.foodIn_Grid);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.foodInput_text);
            this.Name = "FoodInput_Search";
            this.Text = "FoodInput_Search";
            ((System.ComponentModel.ISupportInitialize)(this.foodIn_Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView foodIn_Grid;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox foodInput_text;
    }
}
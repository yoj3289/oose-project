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
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.foodInput_text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.foodIn_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // foodIn_Grid
            // 
            this.foodIn_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foodIn_Grid.Location = new System.Drawing.Point(26, 72);
            this.foodIn_Grid.Name = "foodIn_Grid";
            this.foodIn_Grid.RowHeadersWidth = 62;
            this.foodIn_Grid.RowTemplate.Height = 30;
            this.foodIn_Grid.Size = new System.Drawing.Size(1241, 568);
            this.foodIn_Grid.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("세방고딕 Regular", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(21, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 33);
            this.label6.TabIndex = 41;
            this.label6.Text = "입고조회";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("세방고딕 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(976, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 28);
            this.label1.TabIndex = 40;
            this.label1.Text = "입고처";
            // 
            // foodInput_text
            // 
            this.foodInput_text.Font = new System.Drawing.Font("세방고딕 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.foodInput_text.Location = new System.Drawing.Point(1073, 21);
            this.foodInput_text.Name = "foodInput_text";
            this.foodInput_text.Size = new System.Drawing.Size(150, 36);
            this.foodInput_text.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::YumYumFood.Properties.Resources.pngegg__1_;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(142, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 38);
            this.button1.TabIndex = 44;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Submit
            // 
            this.Submit.BackgroundImage = global::YumYumFood.Properties.Resources.free_icon_search_107122;
            this.Submit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Submit.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Submit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Submit.Location = new System.Drawing.Point(1229, 18);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(39, 39);
            this.Submit.TabIndex = 42;
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // FoodInput_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 658);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.foodIn_Grid);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.foodInput_text);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button button1;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YumYumFood
{
    public partial class FoodOutputSearchPopup : Form
    {
        private FoodOutputSearch parentForm;
        public FoodOutputSearchPopup(FoodOutputSearch parent)
        {
            InitializeComponent();
            parentForm = parent;

            //폼 스타일 설정
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // 크기 조절 불가
            this.MaximizeBox = false;  // 최대화 버튼 제거
            this.MinimizeBox = false;  // 최소화 버튼 제거
            this.StartPosition = FormStartPosition.CenterParent; // 부모 폼 중앙에 표시
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

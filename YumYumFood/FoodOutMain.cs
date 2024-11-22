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
    public partial class FoodOutMain : Form
    {
        public FoodOutMain()
        {
            InitializeComponent();
        }

        //출고 처리 화면 열기
        private void button1_Click(object sender, EventArgs e)
        {
            FoodOutput_Process newform = new FoodOutput_Process();
            newform.Show();
        }

        //출고 조회 화면 열기
        private void button2_Click(object sender, EventArgs e)
        {
            FoodOutputSearch newform2 = new FoodOutputSearch();
            newform2.Show();
        }
    }
}

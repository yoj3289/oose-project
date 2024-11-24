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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //입고처리 화면 띄우는 코드
            FoodInput_Process newform1 = new FoodInput_Process();
            newform1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //출고처리 화면 띄우는 코드
            FoodOutput_Process newform = new FoodOutput_Process();
            newform.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //출고조회 화면 띄우는 코드
            FoodOutputSearch newform2 = new FoodOutputSearch();
            newform2.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //재고관리 화면 띄우는 코드
            try
            {
                // DBClass를 사용해 데이터 초기화
                DBClass db = new DBClass();
                db.UpdateAllFoodQuantities(); // 재고 데이터 최신화

                // FoodManagement 폼 열기
                FoodManagement foodManagement = new FoodManagement();
                foodManagement.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"재고 관리 화면 열기 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //통계관리 화면 띄우는 코드
            SalesMain salesMain = new SalesMain();
            salesMain.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //입고조회 화면 띄우는 코드
            FoodInput_Search newform5 = new FoodInput_Search();
            newform5.Show();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DBManager.InsertInitialData();
                MessageBox.Show("데이터 삽입 완료");
                //LoadData(); // 데이터 그리드 새로고침
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러: " + ex.Message);
            }
        }
    }
}

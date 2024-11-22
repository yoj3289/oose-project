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
    public partial class FoodOutputSearch : Form
    {
        private DataTable table;
        public FoodOutputSearch()
        {
            InitializeComponent();
        }

        // 새로운 DataTable 생성 및 열 추가
        private void InitializeDataTable()
        {
            table = new DataTable();
            table.Columns.Add("판매처", typeof(string));
            table.Columns.Add("출고일자", typeof(string));
            table.Columns.Add("식자재번호", typeof(string));
            table.Columns.Add("식자재이름", typeof(string));
            table.Columns.Add("수량", typeof(int));
            table.Columns.Add("출고단가", typeof(decimal));
            table.Columns.Add("금액", typeof(decimal));
        }

        //전체 내역 출력
        private void LoadFoodOutputData()
        {
            try
            {
                // 기존 데이터 모두 제거
                table.Rows.Clear();

                // DB에서 데이터 가져오기
                DataTable data = DBManager.GetFoodOutputData();

                // 데이터 추가
                foreach (DataRow row in data.Rows)
                {
                    table.Rows.Add(
                        row["foodOutput"].ToString(),
                        Convert.ToDateTime(row["foodOutDate"]).ToString("yyyy-MM-dd"),
                        row["foodCode"].ToString(),
                        row["foodName"].ToString(),
                        Convert.ToInt32(row["foodQuantity"]),
                        Convert.ToDecimal(row["foodOutPrice"]),
                        Convert.ToDecimal(row["foodTotalPrice"])
                    );
                }

                // DataGridView에 데이터 바인딩
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 로드 중 오류 발생: " + ex.Message);
            }
        }


        private void FoodOutputSearch_Load(object sender, EventArgs e)
        {
            InitializeDataTable();
            LoadFoodOutputData();
        }

        //리스트 갱신
        private void UpdateDataGridView(DataTable data)
        {
            // 데이터 추가
            foreach (DataRow row in data.Rows)
            {
                table.Rows.Add(
                    row["foodOutput"].ToString(),
                    Convert.ToDateTime(row["foodOutDate"]).ToString("yyyy-MM-dd"),
                    row["foodCode"].ToString(),
                    row["foodName"].ToString(),
                    Convert.ToInt32(row["foodQuantity"]),
                    Convert.ToDecimal(row["foodOutPrice"]),
                    Convert.ToDecimal(row["foodTotalPrice"])
                );
            }

            // DataGridView에 데이터 바인딩
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchFoodOutput(); // 검색 기능 실행
        }

        private void SearchFoodOutput()
        {
            try
            {
                string searchText = textBox1.Text.Trim();

                // 기존 데이터 모두 제거
                table.Rows.Clear();

                // DB에서 검색 결과 가져오기
                DataTable searchResult = DBManager.SearchFoodOutput(searchText);

                UpdateDataGridView(searchResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show("검색 중 오류 발생: " + ex.Message);
            }
        }
    }
}


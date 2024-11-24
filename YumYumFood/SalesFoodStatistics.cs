using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Oracle.ManagedDataAccess.Client;
using Oracle.DataAccess.Client;

namespace YumYumFood
{
    public partial class SalesFoodStatistics : Form
    {
        List<FoodInfo> rawList = new List<FoodInfo>(); // SELECT 한 가공 전 식자재 정보 리스트
        List<FoodInfoRow> processingList = new List<FoodInfoRow>(); // 가공한 식자재 정보 리스트

        public SalesFoodStatistics()
        {
            InitializeComponent();

            cb_group.SelectedIndex = 0; // 그룹 콤보박스 초기화
            cb_sort.SelectedIndex = 0; // 정렬기준 콤보박스 초기화
            lbl_status.ForeColor = Color.Black;
            lbl_status.Text = ""; // 상태 레이블 초기화
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            lbl_status.Text = "조회 중";

            dgv_chart.Rows.Clear();
            rawList.Clear();
            processingList.Clear();

            string groupStandard = cb_group.SelectedItem.ToString(); // 그룹 기준 get
            string sortStandard = cb_sort.SelectedItem.ToString(); // 정렬 기준 get

            if (!groupStandard.Equals("전체") && !dgv_chart.Columns.Contains("food_group"))
            { // 그룹 기준이 전체가 아니고 "그룹" 열이 없다면 "그룹" 열 추가
                DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();

                newColumn.DefaultCellStyle = dgv_chart.Columns[0].DefaultCellStyle;
                newColumn.HeaderCell.Style = dgv_chart.Columns[0].HeaderCell.Style;
                newColumn.Name = "food_group";
                newColumn.HeaderText = "그룹";
                newColumn.SortMode = DataGridViewColumnSortMode.NotSortable;

                dgv_chart.Columns.Insert(2, newColumn);
            }
            else if (groupStandard.Equals("전체") && dgv_chart.Columns.Contains("food_group"))
            { // 그룹 기준이 "전쳬"이고 "그룹" 열이 있다면 "그룹"열 삭제
                dgv_chart.Columns.Remove("food_group");
            }

            // 데이터베이스 연결
            string connectionString = "User Id=fooduser; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe)));";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // FoodInputDB 데이터 SELECT
                    string inputQuery = "SELECT foodCode, foodName, foodInDate, foodInPrice, foodInQuantity FROM FoodInputDB";
                    using (OracleCommand command = new OracleCommand(inputQuery, connection))
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string foodCode = reader["foodCode"].ToString();
                            string foodName = reader["foodName"].ToString();
                            string foodInDate = reader["foodInDate"].ToString();
                            int foodInPrice = Convert.ToInt32(reader["foodInPrice"]);
                            int foodInQuantity = Convert.ToInt32(reader["foodInQuantity"]);

                            rawList.Add(new FoodInfo(foodCode, foodName, "input", foodInDate, foodInPrice * foodInQuantity));
                        }
                    }

                    // FoodOutputDB 데이터 SELECT
                    string outputQuery = "SELECT foodCode, foodName, foodOutDate, foodOutPrice, foodQuantity FROM FoodOutputDB";
                    using (OracleCommand command = new OracleCommand(outputQuery, connection))
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string foodCode = reader["foodCode"].ToString();
                            string foodName = reader["foodName"].ToString();
                            string foodOutDate = reader["foodOutDate"].ToString();
                            int foodOutPrice = Convert.ToInt32(reader["foodOutPrice"]);
                            int foodQuantity = Convert.ToInt32(reader["foodQuantity"]);

                            rawList.Add(new FoodInfo(foodCode, foodName, "output", foodOutDate, foodOutPrice * foodQuantity));
                        }
                    }
                }
                catch (Exception ex)
                {
                    lbl_status.ForeColor = Color.Red;
                    lbl_status.Text = $"데이터 검색 중 오류 발생\n{ex.Message}";
                    return;
                }
            }

            Grouping(groupStandard); // 그룹핑
            CalculateDifference(); // 차액 계산
            Sort(sortStandard); // 정렬

            if (!dgv_chart.Columns.Contains("food_group"))
            {
                foreach (var i in processingList)
                {
                    dgv_chart.Rows.Add(i.GetFoodCode(), i.GetFoodName(), string.Format("{0:#,0} 원", i.GetFoodInPrice()), string.Format("{0:#,0} 원", i.GetFoodOutPrice()), string.Format("{0:#,0} 원", i.GetFoodDiffrence()));
                }
            }
            else
            {
                foreach (var i in processingList)
                {
                    dgv_chart.Rows.Add(i.GetFoodCode(), i.GetFoodName(), i.GetFoodGroup(), string.Format("{0:#,0} 원", i.GetFoodInPrice()), string.Format("{0:#,0} 원", i.GetFoodOutPrice()), string.Format("{0:#,0} 원", i.GetFoodDiffrence()));
                }
            }
            lbl_status.ForeColor = Color.Blue;
            lbl_status.Text = "조회 완료";
        }

        private void Grouping(string standard)
        {
            Dictionary<string, FoodInfoRow> groupedData = new Dictionary<string, FoodInfoRow>(); // 중간 저장용 Dictionary

            foreach (var i in rawList)
            {
                string key = i.GetFoodCode(); // 기본 키는 foodCode
                string groupName = null;

                // 그룹 기준에 따라 키 변경 및 그룹 이름 설정
                if (standard == "년")
                {
                    DateTime date = DateTime.Parse(i.GetFoodDate());
                    key += "_" + date.Year; //  키에 년 추가
                    groupName = $"{date.Year}년";
                }
                else if (standard == "월")
                {
                    DateTime date = DateTime.Parse(i.GetFoodDate());
                    key += $"_{date.Year}_{date.Month:D2}"; //  키에 년, 월 추가
                    groupName = $"{date.Year}년 {date.Month}월";
                }

                if (groupedData.ContainsKey(key)) // 기존 그룹이 있으면 매입가, 출고가 합산
                {
                    var existingRow = groupedData[key];
                    if (i.GetFoodInOrOut() == "input")
                    {
                        existingRow.SetFoodInPrice(existingRow.GetFoodInPrice() + i.GetFoodPrice());
                    }
                    else if (i.GetFoodInOrOut() == "output")
                    {
                        existingRow.SetFoodOutPrice(existingRow.GetFoodOutPrice() + i.GetFoodPrice());
                    }
                }
                else // 기존 그룹이 없으면 새로운 그룹 생성
                {
                    int foodInPrice = 0;
                    int foodOutPrice = 0;

                    if (i.GetFoodInOrOut() == "input")
                    {
                        foodInPrice = i.GetFoodPrice();
                    }
                    else if (i.GetFoodInOrOut() == "output")
                    {
                        foodOutPrice = i.GetFoodPrice();
                    }

                    var newRow = new FoodInfoRow(
                        i.GetFoodCode(),
                        i.GetFoodName(),
                        foodInPrice,
                        foodOutPrice
                    );

                    if (groupName != null) // 그룹 이름 설정
                    {
                        newRow.SetFoodGroup(groupName);
                    }

                    groupedData.Add(key, newRow);
                }
            }

            foreach (var entry in groupedData.Values) // Dictionary 내용을 processingList로 변환
            {
                processingList.Add(entry);
            }
        }

        private void Sort(string standard)
        {
            if (standard.Equals("코드")) // 사전순
            {
                if (dgv_chart.Columns.Contains("food_group"))
                {
                    processingList.Sort((x, y) => ParseFoodGroup(x.GetFoodGroup()).CompareTo(ParseFoodGroup(y.GetFoodGroup())));
                }
                processingList.Sort((x, y) => string.Compare(x.GetFoodCode(), y.GetFoodCode(), StringComparison.Ordinal));
            }
            else if (standard.Equals("품명")) // 사전순
            {
                if (dgv_chart.Columns.Contains("food_group"))
                {
                    processingList.Sort((x, y) => ParseFoodGroup(x.GetFoodGroup()).CompareTo(ParseFoodGroup(y.GetFoodGroup())));
                }
                processingList.Sort((x, y) => string.Compare(x.GetFoodName(), y.GetFoodName(), StringComparison.Ordinal));
            }
            else if (standard.Equals("매입가")) // 내림차순
            {
                processingList.Sort((x, y) => y.GetFoodInPrice().CompareTo(x.GetFoodInPrice()));
            }
            else if (standard.Equals("출고가")) // 내림차순
            {
                processingList.Sort((x, y) => y.GetFoodOutPrice().CompareTo(x.GetFoodOutPrice()));
            }
            else if (standard.Equals("차액 (이익)")) // 내림차순
            {
                processingList.Sort((x, y) => y.GetFoodDiffrence().CompareTo(x.GetFoodDiffrence()));
            }
        }

        private void CalculateDifference()
        {
            foreach (var i in processingList)
            {
                i.SetFoodDiffrence(i.GetFoodInPrice() - i.GetFoodOutPrice());
            }
        }

        private int ParseFoodGroup(string foodGroup) // "YYYY년 MM월" 형식을 비교를 위해 "YYYYMM" 숫자로 변환하는 메서드
        {
            try
            {
                string year = foodGroup.Substring(0, 4);
                string month = foodGroup.Substring(6, 2);

                return int.Parse(year) * 100 + int.Parse(month); // YYYYMM 형태로 변환
            }
            catch
            {
                return 0; // 변환 실패 시 기본값 반환
            }
        }

        private void dgv_chart_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_chart.Rows.Count) // 잘못된 행 클릭 방지
            {
                return;
            }

            // 클릭한 행에서 food_code 값 가져오기
            string selectedFoodCode = dgv_chart.Rows[e.RowIndex].Cells["food_code"].Value?.ToString();
            if (string.IsNullOrEmpty(selectedFoodCode))
            {
                lbl_status.ForeColor = Color.Red;
                lbl_status.Text = "선택된 항목의 식자재 코드가 유효하지 않음";
                return;
            }

            // rawList에서 food_code가 일치하는 데이터 필터링
            List<FoodInfo> filteredRawList = rawList
                .Where(item => item.GetFoodCode().Equals(selectedFoodCode))
                .ToList();

            if (filteredRawList.Count == 0)
            {
                lbl_status.ForeColor = Color.Red;
                lbl_status.Text = "선택된 항목의 식자재 코드에 대한 데이터가 없음";
                return;
            }

            // SalesFoodGrowth 폼 생성 및 모달로 열기
            SalesFoodGrowth foodGrowthForm = new SalesFoodGrowth(filteredRawList);
            foodGrowthForm.ShowDialog();
        }
    }
}

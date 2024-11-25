//조건검사 변경 및 추가 함수 목록: FoodCode_TextChanged, FoodQuantity_TextChanged, button1_Click
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
using System.Data;

namespace YumYumFood
{
    public partial class FoodOutput_Process : Form
    {
        private DataTable table;

        private String foodOutputText; //출고처 텍스트 박스 내용
        private String foodCodeText;
        private int foodQuantityText;
        private int foodPriceText;
        private String foodOutDateText;
        private decimal foodOutTotalPrice;

        private ToolTip toolTip1 = new ToolTip();

        //각각 코드와 재고 실시간 조회를 위한 변수
        private bool isValidFoodCode = false;
        private bool isValidQuantity = false;

        private bool isValidOutputCode = false;  // foodOutput과 foodCode 조합이 유효한지 확인, 241124추가


        public FoodOutput_Process()
        {
            InitializeComponent();

            // TextBox 이벤트 연결
            foodCode.TextChanged += FoodCode_TextChanged;
            foodQuantity.TextChanged += FoodQuantity_TextChanged;
            foodOutput.TextChanged += foodOutput_TextChanged;  // 새로운 이벤트 연결

            // 초기 상태는 비활성화
            btnOk.Enabled = false;

        }

        //테이블 초기세팅
        private void InitializeDataTable()
        {
            // 새로운 DataTable 생성 및 열 추가
            table = new DataTable();
            table.Columns.Add("출고처", typeof(string));
            table.Columns.Add("식자재 번호", typeof(string));
            table.Columns.Add("수량", typeof(string));
            table.Columns.Add("출고단가", typeof(string));
        }


        private void FoodOutput_Process_Load(object sender, EventArgs e)
        {
            InitializeDataTable();
            LoadData();
        }

        //출고 필요 목록 출력
        private void LoadData()
        {
            try
            {
                // 오늘 날짜를 TextBox에 표시
                foodOutDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

                // 기존 데이터 모두 제거
                table.Rows.Clear();

                // DB에서 데이터 가져오기
                DataTable data = DBManager.GetFoodOutRequireData();

                // 데이터 추가
                foreach (DataRow row in data.Rows)
                {
                    table.Rows.Add(
                        row["foodOutput"].ToString(),
                        row["foodCode"].ToString(),
                        row["foodOutQuantity"].ToString(),
                        row["foodOutPrice"].ToString()
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


        //주문 받는 과정이 프로그램에 없기 때문에 임시로 출고 필요 데이터 넣어줌(테스트 용도)
        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                DBManager.InsertInitialData();
                MessageBox.Show("데이터 삽입 완료");
                LoadData(); // 데이터 그리드 새로고침
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러: " + ex.Message);
            }
        }

        //테스트 과정에서 매번 run sql 로그인하기 번거롭기 때문에 출고 필요 데이터 항목 초기화 위함
        private void label2_Click(object sender, EventArgs e)
        {

            try
            {
                DBManager.ResetAllTables();
                InitializeDataTable(); // 테이블 초기화
                dataGridView1.DataSource = table; // 빈 테이블 바인딩
                MessageBox.Show("전체 초기화 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show("초기화 실패: " + ex.Message);
            }
        }


        //더이상 FoodDB를 참고하지 않고 입고를 참조하도록 변경
        private void btnOk_Click(object sender, EventArgs e)
        {
            foodOutputText = foodOutput.Text; //출고처 텍스트 박스 내용
            foodCodeText = foodCode.Text;
            foodQuantityText = int.Parse(foodQuantity.Text);
            //foodPriceText= int.Parse(foodPrice.Text);
            foodOutDateText = foodOutDate.Text;
            try
            {
                using (OracleConnection conn = DBManager.GetConnection())
                {
                    conn.Open();
                    OracleTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        // 1. 현재 날짜로 ID prefix 생성
                        string datePrefix = DateTime.Now.ToString("yyMMdd");
                        // 2. 해당 날짜의 마지막 ID 조회
                        int count = DBManager.GetLastIdForDate(datePrefix);
                        // 3. 새로운 ID 생성
                        string newId = $"{datePrefix}{(count + 1):D2}";
                        // 4. 날짜 변환
                        DateTime outDate = DateTime.ParseExact(foodOutDateText, "yyyy/MM/dd", null);
                        // 5. foodName 조회
                        string foodName = DBManager.GetFoodNameByCode(foodCodeText);
                        if (string.IsNullOrEmpty(foodName))
                        {
                            MessageBox.Show("유효하지 않은 식자재 코드입니다.");
                            return;
                        }

                        // 6. FoodOutputDB에 데이터 삽입
                        DBManager.InsertFoodOutput(
                            newId,
                            foodOutputText,
                            outDate,
                            foodCodeText,
                            foodName,
                            foodQuantityText,
                            decimal.Parse(foodPrice.Text)
                        );

                        // 7. FoodOutRequire에서 데이터 삭제 또는 업데이트
                        DBManager.ProcessFoodOutRequire(
                            foodOutputText,
                            foodCodeText,
                            foodQuantityText
                        );

                        // 8. 트랜잭션 커밋
                        transaction.Commit();

                        // 9. DataGridView 새로고침
                        LoadData();

                        // 10. 성공 메시지 표시
                        using (FoodOutputSuccessPopup popup = new FoodOutputSuccessPopup())
                        {
                            popup.ShowDialog(this);  // Modal 형태로 표시
                        }
                    }
                    catch (Exception ex)
                    {
                        // 오류 발생 시 롤백
                        transaction.Rollback();
                        throw new Exception($"처리 중 오류가 발생했습니다: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void foodPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void FoodCode_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(foodCode.Text))
            {
                isValidFoodCode = false;
                foodCode.BackColor = SystemColors.Window;
                toolTip1.SetToolTip(foodCode, "");
            }
            else
            {
                isValidFoodCode = DBManager.CheckFoodCodeExists(foodCode.Text);
                if (!isValidFoodCode)
                {
                    foodCode.BackColor = Color.LightPink;
                    toolTip1.SetToolTip(foodCode, "해당 코드로 입고된 이력이 없습니다.");
                }
                else
                {
                    foodCode.BackColor = SystemColors.Window;
                    toolTip1.SetToolTip(foodCode, "");
                }
            }
            CheckOutputAndCode();
            UpdateButtonState();
        }

        //241125추가
        private void FoodQuantity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(foodQuantity.Text) ||
                string.IsNullOrWhiteSpace(foodCode.Text) ||
                string.IsNullOrWhiteSpace(foodOutput.Text))
            {
                isValidQuantity = false;
            }
            else if (int.TryParse(foodQuantity.Text, out int inputQuantity))
            {
                // 실제 재고 수량 계산
                int actualQuantity = DBManager.GetActualFoodQuantity(foodCode.Text);

                // 출고처가 FoodOutRequire에 있는지 확인
                bool existsInRequire = DBManager.CheckOutputExists(foodOutput.Text);

                if (existsInRequire)
                {
                    // 출고처가 있는 경우, 요청 수량도 체크
                    int requireQuantity = DBManager.GetFoodOutRequireQuantity(foodOutput.Text, foodCode.Text);
                    isValidQuantity = (inputQuantity <= actualQuantity) && (inputQuantity <= requireQuantity);

                    if (!isValidQuantity)
                    {
                        foodQuantity.BackColor = Color.LightPink;
                        if (inputQuantity > requireQuantity)
                            toolTip1.SetToolTip(foodQuantity, $"요청 수량({requireQuantity})을 초과할 수 없습니다.");
                        else
                            toolTip1.SetToolTip(foodQuantity, $"가용 재고 수량({actualQuantity})을 초과할 수 없습니다.");
                    }
                    else
                    {
                        foodQuantity.BackColor = SystemColors.Window;
                        toolTip1.SetToolTip(foodQuantity, "");
                    }
                }
                else
                {
                    // 출고처가 없는 경우, 재고 수량만 체크
                    isValidQuantity = (inputQuantity <= actualQuantity);

                    if (!isValidQuantity)
                    {
                        foodQuantity.BackColor = Color.LightPink;
                        toolTip1.SetToolTip(foodQuantity, $"가용 재고 수량({actualQuantity})을 초과할 수 없습니다.");
                    }
                    else
                    {
                        foodQuantity.BackColor = SystemColors.Window;
                        toolTip1.SetToolTip(foodQuantity, "");
                    }
                }
            }
            else
            {
                isValidQuantity = false;
            }
            UpdateButtonState();
        }


        //require 의존도를 더 낮췄음 241125추가
        private void CheckOutputAndCode()
        {
            if (string.IsNullOrWhiteSpace(foodOutput.Text) || string.IsNullOrWhiteSpace(foodCode.Text))
            {
                isValidOutputCode = false;
            }
            else
            {
                bool existsInRequire = DBManager.CheckOutputExists(foodOutput.Text);
                if (existsInRequire)
                {
                    // 출고처가 FoodOutRequire에 있으면 코드 매칭 검사
                    isValidOutputCode = DBManager.CheckOutputAndCodeExist(foodOutput.Text, foodCode.Text);
                }
                else
                {
                    // 출고처가 FoodOutRequire에 없으면 무조건 true
                    isValidOutputCode = true;
                }
            }
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            // 모든 조건을 만족해야 버튼 활성화
            btnOk.Enabled = isValidFoodCode && isValidQuantity && isValidOutputCode;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void foodOutput_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(foodOutput.Text))
            {
                foodOutput.BackColor = SystemColors.Window;
                toolTip1.SetToolTip(foodOutput, "");
            }
            else
            {
                // 출고처가 FoodOutRequire에 있는지 확인
                bool existsInRequire = DBManager.CheckOutputExists(foodOutput.Text);

                if (existsInRequire)
                {
                    // 출고처가 있는 경우, 코드와의 조합도 체크
                    if (!string.IsNullOrWhiteSpace(foodCode.Text) &&
                        !DBManager.CheckOutputAndCodeExist(foodOutput.Text, foodCode.Text))
                    {
                        foodOutput.BackColor = Color.LightPink;
                        toolTip1.SetToolTip(foodOutput, "해당 출고처의 식자재 요청이 아닙니다.");
                    }
                    else
                    {
                        foodOutput.BackColor = SystemColors.Window;
                        toolTip1.SetToolTip(foodOutput, "");
                    }
                }
                else
                {
                    // 출고처가 없는 경우는 그냥 통과
                    foodOutput.BackColor = SystemColors.Window;
                    toolTip1.SetToolTip(foodOutput, "");
                }
            }
            CheckOutputAndCode();
        }
    }
}
// foodOutput이 변경될 때마다 조합 체크 241124수정
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
    public partial class FoodManagement : Form
    {
        private DBClass db; // DBClass 인스턴스 선언

        public FoodManagement()
        {
            InitializeComponent();
            db = new DBClass(); // DBClass 초기화
            db.UpdateAllFoodQuantities(); // 재고 데이터 초기화
            UpdateAlarmButton(); // 알람 버튼 색상 초기화
        }

        private void FoodManagement_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeDataGridView();
                //db.UpdateAllFoodQuantities(); // 재고 업데이트
                //UpdateAlarmButton(); // 알람 버튼 색상 초기화
            }
            catch (Exception ex)
            {
                MessageBox.Show($"폼 로드 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true; // 컬럼 자동 생성 허용
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // 헤더 가운데 정렬
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // 컬럼 크기 자동 조정
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 전체 행 선택 모드
        }

        private void UpdateAlarmButtonColor()
        {
            try
            {
                // 알람 조건 확인
                bool hasAlerts = db.CheckForAlerts();

                // 알람 조건에 따라 버튼 색상 변경
                btnAlarm.BackColor = hasAlerts ? Color.Yellow : Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"알람 버튼 색상 업데이트 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckForAlerts()
        {
            try
            {
                string query = @"
        SELECT 
            f.foodCode
        FROM 
            FoodDB f
        WHERE 
            f.foodQuantity <= 5 OR
            (f.foodExpiryDate <= SYSDATE + 7 AND f.foodExpiryDate >= SYSDATE)";

                DataTable resultTable = db.ExecuteQuery(query);

                // 디버깅용 출력
                Console.WriteLine($"[CheckForAlerts] 알람 조건에 해당하는 데이터 개수: {resultTable.Rows.Count}");

                return resultTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"알람 조건 확인 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UpdateAlarmButton()
        {
            if (CheckForAlerts())
            {
                btnAlarm.BackColor = Color.Yellow; // 알람 조건에 해당하는 데이터가 있으면 노란색
            }
            else
            {
                btnAlarm.BackColor = Color.White; // 없으면 흰색
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string itemName = txtItemName.Text.Trim();
                string itemCode = txtItemCode.Text.Trim();
                string date = txtDate.Text.Trim();

                if (string.IsNullOrEmpty(itemName) && string.IsNullOrEmpty(itemCode) && string.IsNullOrEmpty(date))
                {
                    MessageBox.Show("검색 조건을 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 입고와 출고 데이터를 기반으로 FoodDB 업데이트
                string updateQuery = @"
        UPDATE FoodDB f
        SET f.foodQuantity = (
            NVL((SELECT SUM(fi.foodInQuantity) FROM FoodInputDB fi WHERE fi.foodCode = f.foodCode), 0) -
            NVL((SELECT SUM(fo.foodQuantity) FROM FoodOutputDB fo WHERE fo.foodCode = f.foodCode), 0)
        )";

                db.ExecuteQuery(updateQuery); // FoodDB.foodQuantity 업데이트

                // 검색 조건 생성
                string condition = "1=1";
                if (!string.IsNullOrEmpty(itemName))
                {
                    condition += $" AND UPPER(f.foodName) LIKE UPPER('%{itemName}%')";
                }
                if (!string.IsNullOrEmpty(itemCode))
                {
                    condition += $" AND f.foodCode LIKE '%{itemCode}%'";
                }
                if (!string.IsNullOrEmpty(date))
                {
                    if (DateTime.TryParse(date, out DateTime parsedDate))
                    {
                        condition += $" AND (TRUNC(fi.foodInDate) = TO_DATE('{parsedDate:yyyy-MM-dd}', 'YYYY-MM-DD') OR TRUNC(fo.foodOutDate) = TO_DATE('{parsedDate:yyyy-MM-dd}', 'YYYY-MM-DD'))";
                    }
                    else
                    {
                        MessageBox.Show("날짜 형식이 잘못되었습니다. YYYY-MM-DD 형식으로 입력해주세요.", "날짜 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 검색 쿼리 생성
                string query = $@"
        SELECT 
            fi.foodInDate AS 입고일자,
            fi.foodInPut AS 입고처,
            fo.foodOutDate AS 출고일자,
            fo.foodOutput AS 출고처,
            f.foodCode AS 식자재번호,
            f.foodName AS 식자재이름,
            f.foodQuantity AS 현재수량,
            f.foodExpiryDate AS 유통기한
        FROM 
            FoodDB f
        LEFT JOIN FoodInputDB fi ON f.foodCode = fi.foodCode
        LEFT JOIN FoodOutputDB fo ON f.foodCode = fo.foodCode
        WHERE {condition}
        GROUP BY 
            fi.foodInDate, fi.foodInPut, fo.foodOutDate, fo.foodOutput, f.foodCode, f.foodName, f.foodExpiryDate, f.foodQuantity";

                DataTable resultTable = db.ExecuteQuery(query);
                dataGridView1.DataSource = resultTable;

                if (resultTable.Rows.Count > 0)
                {
                    MessageBox.Show($"총 {resultTable.Rows.Count}개의 결과가 검색되었습니다.", "검색 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("검색 결과가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"검색 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
        SELECT 
            f.foodCode AS 식자재번호,
            f.foodName AS 식자재이름,
            f.foodQuantity AS 현재수량,
            f.foodExpiryDate AS 유통기한
        FROM 
            FoodDB f
        WHERE 
            f.foodQuantity <= 5 OR
            (f.foodExpiryDate <= SYSDATE + 7 AND f.foodExpiryDate >= SYSDATE)";

                DataTable resultTable = db.ExecuteQuery(query);
                dataGridView1.DataSource = resultTable;

                if (resultTable.Rows.Count > 0)
                {
                    MessageBox.Show($"알람 조건에 해당하는 {resultTable.Rows.Count}개의 데이터가 조회되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("알람 조건에 해당하는 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"알람 데이터 조회 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

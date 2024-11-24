using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace YumYumFood
{
    public partial class FoodInput_Process : Form
    {
        private OracleConnection odpConn = new OracleConnection();

        public FoodInput_Process()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (!AddInputData())
            {
                return;
            }
            else
            {
                string foodCode = foodCode_text.Text.Trim();
                string foodExpiryDate = foodExpiryDate_text.Text.Trim();
                string foodInPrice = foodInPrice_text.Text.Trim();
                string foodInput = foodInput_text.Text.Trim();
                string foodName = foodName_text.Text.Trim();
                string foodInQuantity = foodInQuantity_text.Text.Trim();
                string connectionString = "USER ID=fooduser;PASSWORD=1111;DATA SOURCE=localhost:1521/xe;";
                //string connectionString = "User Id=fooduser;Password=1111;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)))";
                // SQL INSERT 문
                string insertQuery = @"
                    INSERT INTO FoodInputDB (
                        foodInID, foodInDate, foodInPut, foodCode, foodName, foodInQuantity, foodInPrice, foodExpiryDatePrice
                    ) 
                    VALUES (
                        (SELECT NVL(MAX(foodInID), 0) + 1 FROM FoodInputDB), 
                        :foodInDate, :foodInPut, :foodCode, :foodName, :foodInQuantity, :foodInPrice, :foodExpiryDate )";
                // 데이터베이스 연결 및 실행
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                        {
                            cmd.Parameters.Add("foodInDate", OracleDbType.Date).Value = DateTime.Now; // 현재 날짜
                            cmd.Parameters.Add("foodInPut", OracleDbType.Varchar2).Value = foodInput;
                            cmd.Parameters.Add("foodCode", OracleDbType.Varchar2).Value = foodCode;
                            cmd.Parameters.Add("foodName", OracleDbType.Varchar2).Value = foodName;
                            cmd.Parameters.Add("foodInQuantity", OracleDbType.Int32).Value = int.Parse(foodInQuantity);
                            cmd.Parameters.Add("foodInPrice", OracleDbType.Int32).Value = int.Parse(foodInPrice);
                            cmd.Parameters.Add("foodExpiryDate", OracleDbType.Date).Value = DateTime.ParseExact(foodExpiryDate, "yyyy-MM-dd", null);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            conn.Close();
                            // 성공 메시지
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("데이터가 성공적으로 삽입되었습니다!", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("데이터 삽입에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            conn.Close();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            FoodInput_Search newform5 = new FoodInput_Search();
            newform5.Show();
        }

        private bool AddInputData()
        {
            // 1. foodCode 검사 (최대 20자)
            string foodCode = foodCode_text.Text.Trim();
            if (string.IsNullOrEmpty(foodCode) || foodCode.Length > 20)
            {
                MessageBox.Show("식자재 번호는 1~20자 사이로 입력해야 합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 2. foodExpiryDate 검사 (YYYY-MM-DD 형식)
            string foodExpiryDate = foodExpiryDate_text.Text.Trim();
            if (!Regex.IsMatch(foodExpiryDate, @"^\d{4}-\d{2}-\d{2}$"))
            {
                MessageBox.Show("유통기한은 YYYY-MM-DD 형식으로 입력해야 합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 날짜 형식 유효성 검사 추가 (정확한 날짜인지 확인)
            if (!DateTime.TryParseExact(foodExpiryDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("유통기한은 올바른 날짜여야 합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 3. foodInPrice 검사 (숫자, 소수점 이하 2자리까지)
            string foodInPrice = foodInPrice_text.Text.Trim();
            if (!Regex.IsMatch(foodInPrice, @"^\d+(\.\d{1,2})?$"))
            {
                MessageBox.Show("입고 단가는 숫자로 입력하며 소수점은 최대 두 자리까지 가능합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 4. foodInput 검사 (최대 20자)
            string foodInput = foodInput_text.Text.Trim();
            if (string.IsNullOrEmpty(foodInput) || foodInput.Length > 20)
            {
                MessageBox.Show("입고처는 1~20자 사이로 입력해야 합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 5. foodInQuantity 검사 (숫자, 최대 5자리)
            string foodInQuantity = foodInQuantity_text.Text.Trim();
            if (!Regex.IsMatch(foodInQuantity, @"^\d{1,5}$"))
            {
                MessageBox.Show("수량은 숫자로 입력하며 1~5자 사이로 입력해야 합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 4. foodName 검사 (최대 20자)
            string foodName = foodName_text.Text.Trim();
            if (string.IsNullOrEmpty(foodName) || foodName.Length > 20)
            {
                MessageBox.Show("입고처는 1~20자 사이로 입력해야 합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // 모든 유효성 검사를 통과한 경우
            return true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FoodInput_Process_Load(object sender, EventArgs e)
        {

        }
    }
}

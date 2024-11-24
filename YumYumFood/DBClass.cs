using System;
using System.Data; // DataSet 및 DataTable을 사용하기 위함
using System.Windows.Forms; // MessageBox를 사용하기 위함
using Oracle.DataAccess.Client; // Oracle 데이터베이스에 연결하기 위함

namespace YumYumFood
{
    class DBClass
    {
        private string connectionString; // 데이터베이스 연결 문자열
        private DataSet dataSet; // 데이터를 보관하는 데이터셋

        public DBClass()
        {
            //connectionString = "USER ID=fooduser;PASSWORD=1111;DATA SOURCE=localhost:1521/xe;";
            connectionString = "User Id=fooduser; Password=1111; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=DESKTOP-F5563H6)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";
            dataSet = new DataSet();
        }

        // 데이터 조회 및 반환
        public DataTable ExecuteQuery(string query)
        {
            try
            {
                using (OracleDataAdapter adapter = new OracleDataAdapter(query, connectionString))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    return resultTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"쿼리 실행 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // 전체 재고 업데이트
        public void UpdateAllFoodQuantities()
        {
            try
            {
                string query = @"
                UPDATE FoodDB f
                SET f.foodQuantity = (
                    NVL((SELECT SUM(fi.foodInQuantity) FROM FoodInputDB fi WHERE fi.foodCode = f.foodCode), 0) -
                    NVL((SELECT SUM(fo.foodQuantity) FROM FoodOutputDB fo WHERE fo.foodCode = f.foodCode), 0)
                )";

                using (OracleConnection conn = new OracleConnection(connectionString))
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"재고 업데이트 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 알람 조건 확인
        public bool CheckForAlerts()
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

                DataTable resultTable = ExecuteQuery(query);

                return resultTable.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"알람 조건 확인 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 특정 식자재 재고 업데이트
        public void UpdateFoodQuantity(string foodCode, int quantityChange)
        {
            try
            {
                string query = @"
                UPDATE FoodDB
                SET foodQuantity = foodQuantity + :quantityChange
                WHERE foodCode = :foodCode";

                using (OracleConnection conn = new OracleConnection(connectionString))
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter(":quantityChange", quantityChange));
                    cmd.Parameters.Add(new OracleParameter(":foodCode", foodCode));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"재고 업데이트 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

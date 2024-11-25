using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using Oracle.ManagedDataAccess.Client;
using Oracle.DataAccess.Client;
using System.Data;
using System.Windows.Forms;  // 이 줄 추가

public class DBManager
{
    //공유 폴더의 ID와 password 참고, Nuget은 각자 다운로드 해야 함, DB가 폴더에 있어야 함
    private static readonly string connectionString = "USER ID=fooduser;PASSWORD=1111;DATA SOURCE=localhost:1521/xe;";

    public static OracleConnection GetConnection()
    {
        return new OracleConnection(connectionString);  // 매번 새로운 연결 생성
    }

    public static void InsertInitialData()
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                try
                {
                    // 트랜잭션 시작
                    OracleTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    // 기존 데이터 삭제
                    cmd.CommandText = "DELETE FROM FoodOutputDB";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM FoodOutRequire";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM FoodInputDB";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM FoodDB";
                    cmd.ExecuteNonQuery();

                    // FoodInputDB 데이터 삽입
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(1, TO_DATE('2024-11-10', 'YYYY-MM-DD'), '우리과수원', 'F001', '사과', 100, 1500, TO_DATE('2024-11-20', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(2, TO_DATE('2024-11-13', 'YYYY-MM-DD'), '꿀꿀농장', 'F002', '삼겹살', 250, 3500, TO_DATE('2024-11-25', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(3, TO_DATE('2024-11-16', 'YYYY-MM-DD'), '토끼정원', 'F003', '당근', 300, 2500, TO_DATE('2024-11-27', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(4, TO_DATE('2024-11-20', 'YYYY-MM-DD'), '우리농장', 'F004', '양파', 250, 2000, TO_DATE('2024-11-30', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(5, TO_DATE('2024-11-25', 'YYYY-MM-DD'), '음메목장', 'F005', '우유', 400, 3000, TO_DATE('2024-11-30', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // FoodOutRequire 데이터 삽입
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F001', '2024-11-19', '사과', '세종상사', 150)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F003', '2024-11-20', '당근', '대한맛집', 250)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F005', '2024-11-21', '우유', '우리고기', 350)";
                    cmd.ExecuteNonQuery();

                    // 트랜잭션 커밋
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw new Exception("데이터 삽입 실패: " + ex.Message);
                }
            }
        }
    }
    public static DataTable GetFoodOutRequireData()
    {
        DataTable dt = new DataTable();
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT r.foodOutput, r.foodCode, r.foodOutQuantity, i.foodInPrice as foodOutPrice FROM FoodOutRequire r JOIN FoodInputDB i ON r.foodCode = i.foodCode";
                try
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("데이터 로드 실패: " + ex.Message);
                }
            }
        }
        return dt;
    }



    // FoodOutRequire의 수량 조회
    public static int GetFoodOutRequireQuantity(string foodOutput, string foodCode)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                SELECT foodOutQuantity 
                FROM FoodOutRequire 
                WHERE foodOutput = :foodOutput 
                AND foodCode = :foodCode";

                cmd.Parameters.Add(new OracleParameter("foodOutput", foodOutput));
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }

    // 테이블 수정
    public static void ResetAllTables()
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                try
                {
                    OracleTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    // 테이블의 데이터 삭제
                    cmd.CommandText = "DELETE FROM FoodOutputDB";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM FoodOutRequire";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM FoodInputDB";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM FoodDB";
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    throw new Exception("테이블 데이터 초기화 실패: " + ex.Message);
                }
            }
        }
    }

    // 기존 날짜의 마지막 ID 조회
    public static int GetLastIdForDate(string datePrefix)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM FoodOutputDB WHERE SUBSTR(foodOutID, 1, 6) = :datePrefix";
                cmd.Parameters.Add(new OracleParameter("datePrefix", datePrefix));

                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }
    }

    public static string GetFoodNameByCode(string foodCode)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT foodName FROM FoodInputDB WHERE foodCode = :foodCode";
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));

                object result = cmd.ExecuteScalar();
                return result?.ToString() ?? "";
            }
        }
    }

    //FoodOutputDB에 출고 데이터 삽입
    public static void InsertFoodOutput(string foodOutID, string foodOutput, DateTime foodOutDate,
        string foodCode, string foodName, int foodQuantity, decimal foodOutPrice)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO FoodOutputDB 
                    (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice)
                    VALUES 
                    (:foodOutID, :foodOutput, :foodOutDate, :foodCode, :foodName, :foodQuantity, :foodOutPrice)";

                cmd.Parameters.Add(new OracleParameter("foodOutID", foodOutID));
                cmd.Parameters.Add(new OracleParameter("foodOutput", foodOutput));
                cmd.Parameters.Add(new OracleParameter("foodOutDate", foodOutDate));
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));
                cmd.Parameters.Add(new OracleParameter("foodName", foodName));
                cmd.Parameters.Add(new OracleParameter("foodQuantity", foodQuantity));
                cmd.Parameters.Add(new OracleParameter("foodOutPrice", foodOutPrice));

                cmd.ExecuteNonQuery();
            }
        }
    }


    //241125 추가
    public static void ProcessFoodOutRequire(string foodOutput, string foodCode, int processQuantity)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                // 먼저 FoodOutRequire에 해당 출고처와 코드가 있는지 확인
                cmd.CommandText = @"
                SELECT foodOutQuantity 
                FROM FoodOutRequire 
                WHERE foodOutput = :foodOutput 
                AND foodCode = :foodCode
                FOR UPDATE";  // 행 잠금을 위해 FOR UPDATE 추가

                cmd.Parameters.Add(new OracleParameter("foodOutput", foodOutput));
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())  // FoodOutRequire에 있는 경우
                    {
                        int currentQuantity = Convert.ToInt32(reader["foodOutQuantity"]);
                        reader.Close();

                        if (processQuantity == currentQuantity)
                        {
                            // 수량이 같으면 행 삭제
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"
                            DELETE FROM FoodOutRequire 
                            WHERE foodOutput = :foodOutput 
                            AND foodCode = :foodCode";
                            cmd.Parameters.Add(new OracleParameter("foodOutput", foodOutput));
                            cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));

                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                throw new Exception("FoodOutRequire 테이블 삭제 실패");
                            }
                        }
                        else
                        {
                            // 처리할 수량만큼 차감 업데이트
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"
                            UPDATE FoodOutRequire 
                            SET foodOutQuantity = :newQuantity 
                            WHERE foodOutput = :foodOutput 
                            AND foodCode = :foodCode";

                            int newQuantity = currentQuantity - processQuantity;
                            cmd.Parameters.Add(new OracleParameter("newQuantity", newQuantity));
                            cmd.Parameters.Add(new OracleParameter("foodOutput", foodOutput));
                            cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));

                            if (cmd.ExecuteNonQuery() == 0)
                            {
                                throw new Exception("FoodOutRequire 테이블 업데이트 실패");
                            }
                        }
                    }
                    else  // FoodOutRequire에 없는 경우
                    {
                        // 아무 작업도 하지 않고 그냥 리턴
                        return;
                    }
                }
            }
        }
    }

    //전체 출고내역 출력
    public static DataTable GetFoodOutputData()
    {
        DataTable dt = new DataTable();

        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = @"
                SELECT 
                    foodOutput,
                    foodOutDate,
                    foodCode,
                    foodName,
                    foodQuantity,
                    foodOutPrice,
                    foodTotalPrice
                FROM FoodOutputDB
                ORDER BY foodOutDate DESC";

                try
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("데이터 읽기 실패: " + ex.Message);
                }
            }
        }

        return dt;
    }

    // foodCode 존재 여부 확인 - FoodInputDB 기준으로 변경
    public static bool CheckFoodCodeExists(string foodCode)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM FoodInputDB WHERE foodCode = :foodCode";
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }

    // foodOutput과 foodCode 조합이 FoodOutRequire에 존재하는지 확인 241124추가
    public static bool CheckOutputAndCodeExist(string foodOutput, string foodCode)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT COUNT(*) 
                    FROM FoodOutRequire 
                    WHERE foodOutput = :foodOutput 
                    AND foodCode = :foodCode";

                cmd.Parameters.Add(new OracleParameter("foodOutput", foodOutput));
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }

    // foodQuantity 조회
    public static int GetFoodQuantity(string foodCode)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT foodQuantity FROM FoodDB WHERE foodCode = :foodCode";
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }

    //출고 선택조회 위한 쿼리
    public static DataTable SearchFoodOutput(string searchText)
    {
        DataTable dt = new DataTable();

        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = conn;

                // 검색어가 비어있으면 전체 데이터 반환
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    return GetFoodOutputData();
                }

                cmd.CommandText = @"
                    SELECT 
                        foodOutput,
                        foodOutDate,
                        foodCode,
                        foodName,
                        foodQuantity,
                        foodOutPrice,
                        foodTotalPrice
                    FROM FoodOutputDB
                    WHERE foodOutput = :searchText
                    ORDER BY foodOutDate DESC";

                cmd.Parameters.Add(new OracleParameter("searchText", searchText));

                try
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("검색 실패: " + ex.Message);
                }
            }
        }

        return dt;
    }

    //출고 완료 시 FOodDB재고 변경
    public static void UpdateFoodQuantity(string foodCode, int decreaseAmount)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE FoodDB 
                    SET foodQuantity = foodQuantity - :decreaseAmount 
                    WHERE foodCode = :foodCode";

                cmd.Parameters.Add(new OracleParameter("decreaseAmount", decreaseAmount));
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));

                cmd.ExecuteNonQuery();
            }
        }
    }

    public static bool CheckOutputExists(string foodOutput)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM FoodOutRequire WHERE foodOutput = :foodOutput";
                cmd.Parameters.Add(new OracleParameter("foodOutput", foodOutput));

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }

    // 실제 재고 수량 계산을 위한 새로운 메서드
    public static int GetActualFoodQuantity(string foodCode)
    {
        using (OracleConnection conn = GetConnection())
        {
            conn.Open();
            using (OracleCommand cmd = conn.CreateCommand())
            {
                // 입고 수량 합계 조회
                cmd.CommandText = @"
                SELECT COALESCE(SUM(foodInQuantity), 0)
                FROM FoodInputDB 
                WHERE foodCode = :foodCode";
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));
                int totalInput = Convert.ToInt32(cmd.ExecuteScalar());

                // 출고 수량 합계 조회
                cmd.Parameters.Clear();
                cmd.CommandText = @"
                SELECT COALESCE(SUM(foodQuantity), 0)
                FROM FoodOutputDB 
                WHERE foodCode = :foodCode";
                cmd.Parameters.Add(new OracleParameter("foodCode", foodCode));
                int totalOutput = Convert.ToInt32(cmd.ExecuteScalar());

                // 실제 재고 = 입고 합계 - 출고 합계
                return totalInput - totalOutput;
            }
        }
    }
}
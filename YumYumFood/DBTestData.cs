using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

public class DBTestData
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
                    // 사과 데이터 (F001)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(51, TO_DATE('2023-05-15', 'YYYY-MM-DD'), '경북과수원', 'F001', '사과', 180, 1800, TO_DATE('2023-12-30', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(52, TO_DATE('2023-08-15', 'YYYY-MM-DD'), '경북과수원', 'F001', '사과', 200, 1900, TO_DATE('2023-12-25', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(1, TO_DATE('2024-01-15', 'YYYY-MM-DD'), '경북과수원', 'F001', '사과', 200, 2000, TO_DATE('2024-12-30', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(2, TO_DATE('2024-02-15', 'YYYY-MM-DD'), '경북과수원', 'F001', '사과', 150, 2000, TO_DATE('2024-12-25', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(3, TO_DATE('2024-03-15', 'YYYY-MM-DD'), '경북과수원', 'F001', '사과', 180, 2000, TO_DATE('2024-12-20', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(4, TO_DATE('2024-04-15', 'YYYY-MM-DD'), '경북과수원', 'F001', '사과', 220, 2000, TO_DATE('2024-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 돼지고기 데이터 (F002)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(53, TO_DATE('2023-06-10', 'YYYY-MM-DD'), '한돈축산', 'F002', '돼지고기', 85, 7500, TO_DATE('2023-12-20', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(54, TO_DATE('2023-09-10', 'YYYY-MM-DD'), '한돈축산', 'F002', '돼지고기', 95, 7600, TO_DATE('2023-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(5, TO_DATE('2024-01-10', 'YYYY-MM-DD'), '한돈축산', 'F002', '돼지고기', 100, 8000, TO_DATE('2024-12-05', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(6, TO_DATE('2024-02-10', 'YYYY-MM-DD'), '한돈축산', 'F002', '돼지고기', 120, 7800, TO_DATE('2024-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(7, TO_DATE('2024-03-10', 'YYYY-MM-DD'), '한돈축산', 'F002', '돼지고기', 90, 8200, TO_DATE('2024-12-10', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(8, TO_DATE('2024-04-10', 'YYYY-MM-DD'), '한돈축산', 'F002', '돼지고기', 110, 7900, TO_DATE('2024-12-08', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 당근 데이터 (F003)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(55, TO_DATE('2023-05-20', 'YYYY-MM-DD'), '전북농산', 'F003', '당근', 250, 900, TO_DATE('2023-12-10', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(56, TO_DATE('2023-08-20', 'YYYY-MM-DD'), '전북농산', 'F003', '당근', 280, 950, TO_DATE('2023-12-05', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(9, TO_DATE('2024-01-20', 'YYYY-MM-DD'), '전북농산', 'F003', '당근', 300, 1000, TO_DATE('2024-12-01', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(10, TO_DATE('2024-02-20', 'YYYY-MM-DD'), '전북농산', 'F003', '당근', 250, 1200, TO_DATE('2024-12-08', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(11, TO_DATE('2024-03-20', 'YYYY-MM-DD'), '전북농산', 'F003', '당근', 280, 1100, TO_DATE('2024-12-05', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(12, TO_DATE('2024-04-20', 'YYYY-MM-DD'), '전북농산', 'F003', '당근', 320, 950, TO_DATE('2024-12-03', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 감자 데이터 (F004)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(13, TO_DATE('2024-01-25', 'YYYY-MM-DD'), '강원농산', 'F004', '감자', 400, 1500, TO_DATE('2024-12-30', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(14, TO_DATE('2024-02-25', 'YYYY-MM-DD'), '강원농산', 'F004', '감자', 350, 1600, TO_DATE('2024-12-25', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(15, TO_DATE('2024-03-25', 'YYYY-MM-DD'), '강원농산', 'F004', '감자', 380, 1550, TO_DATE('2024-12-20', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(16, TO_DATE('2024-04-25', 'YYYY-MM-DD'), '강원농산', 'F004', '감자', 420, 1450, TO_DATE('2024-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 양파 데이터 (F005)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(17, TO_DATE('2024-01-05', 'YYYY-MM-DD'), '창녕농산', 'F005', '양파', 500, 1300, TO_DATE('2024-12-25', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(18, TO_DATE('2024-02-05', 'YYYY-MM-DD'), '창녕농산', 'F005', '양파', 450, 1400, TO_DATE('2024-12-20', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(19, TO_DATE('2024-03-05', 'YYYY-MM-DD'), '하동농산', 'F005', '양파', 480, 1350, TO_DATE('2024-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(20, TO_DATE('2024-04-05', 'YYYY-MM-DD'), '하동농산', 'F005', '양파', 520, 1250, TO_DATE('2024-12-10', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 쌀 데이터 (F006)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(57, TO_DATE('2023-07-15', 'YYYY-MM-DD'), '이천농협', 'F006', '쌀', 850, 2300, TO_DATE('2023-12-28', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(58, TO_DATE('2023-10-15', 'YYYY-MM-DD'), '이천농협', 'F006', '쌀', 900, 2400, TO_DATE('2023-12-20', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(21, TO_DATE('2024-01-08', 'YYYY-MM-DD'), '이천농협', 'F006', '쌀', 1000, 2500, TO_DATE('2024-12-30', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(22, TO_DATE('2024-02-08', 'YYYY-MM-DD'), '이천농협', 'F006', '쌀', 900, 2600, TO_DATE('2024-12-25', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(23, TO_DATE('2024-03-08', 'YYYY-MM-DD'), '이천농협', 'F006', '쌀', 950, 2550, TO_DATE('2024-12-20', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(24, TO_DATE('2024-04-08', 'YYYY-MM-DD'), '이천농협', 'F006', '쌀', 1100, 2450, TO_DATE('2024-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 고등어 데이터 (F007)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(59, TO_DATE('2023-06-25', 'YYYY-MM-DD'), '부산수산', 'F007', '고등어', 170, 3800, TO_DATE('2023-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(60, TO_DATE('2023-09-25', 'YYYY-MM-DD'), '부산수산', 'F007', '고등어', 190, 3900, TO_DATE('2023-12-10', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(25, TO_DATE('2024-01-12', 'YYYY-MM-DD'), '부산수산', 'F007', '고등어', 200, 4000, TO_DATE('2024-12-05', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(26, TO_DATE('2024-02-12', 'YYYY-MM-DD'), '부산수산', 'F007', '고등어', 180, 4200, TO_DATE('2024-12-08', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(27, TO_DATE('2024-03-12', 'YYYY-MM-DD'), '부산수산', 'F007', '고등어', 220, 3900, TO_DATE('2024-12-03', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(28, TO_DATE('2024-04-12', 'YYYY-MM-DD'), '부산수산', 'F007', '고등어', 190, 4100, TO_DATE('2024-12-01', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 두부 데이터 (F008)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(29, TO_DATE('2024-01-03', 'YYYY-MM-DD'), '풀무원', 'F008', '두부', 150, 1800, TO_DATE('2024-12-10', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(30, TO_DATE('2024-02-03', 'YYYY-MM-DD'), '풀무원', 'F008', '두부', 130, 1900, TO_DATE('2024-12-08', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(31, TO_DATE('2024-03-03', 'YYYY-MM-DD'), '풀무원', 'F008', '두부', 160, 1750, TO_DATE('2024-12-05', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(32, TO_DATE('2024-04-03', 'YYYY-MM-DD'), '풀무원', 'F008', '두부', 140, 1850, TO_DATE('2024-12-03', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 계란 데이터 (F009)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(33, TO_DATE('2024-01-18', 'YYYY-MM-DD'), '양주계란', 'F009', '계란', 500, 5500, TO_DATE('2024-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(34, TO_DATE('2024-02-18', 'YYYY-MM-DD'), '양주계란', 'F009', '계란', 450, 5700, TO_DATE('2024-12-10', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(35, TO_DATE('2024-03-18', 'YYYY-MM-DD'), '양주계란', 'F009', '계란', 480, 5600, TO_DATE('2024-12-08', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(36, TO_DATE('2024-04-18', 'YYYY-MM-DD'), '양주계란', 'F009', '계란', 520, 5400, TO_DATE('2024-12-05', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 김치 데이터 (F010)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(37, TO_DATE('2024-01-22', 'YYYY-MM-DD'), '광주김치', 'F010', '김치', 300, 9000, TO_DATE('2024-12-20', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(38, TO_DATE('2024-02-22', 'YYYY-MM-DD'), '광주김치', 'F010', '김치', 280, 9200, TO_DATE('2024-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(39, TO_DATE('2024-03-22', 'YYYY-MM-DD'), '광주김치', 'F010', '김치', 320, 8900, TO_DATE('2024-12-10', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(40, TO_DATE('2024-04-22', 'YYYY-MM-DD'), '광주김치', 'F010', '김치', 290, 9100, TO_DATE('2024-12-08', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 버섯 데이터 (F011)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(41, TO_DATE('2024-01-28', 'YYYY-MM-DD'), '영천버섯', 'F011', '버섯', 150, 3500, TO_DATE('2024-12-08', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(42, TO_DATE('2024-02-28', 'YYYY-MM-DD'), '영천버섯', 'F011', '버섯', 130, 3700, TO_DATE('2024-12-05', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(43, TO_DATE('2024-03-28', 'YYYY-MM-DD'), '영천버섯', 'F011', '버섯', 160, 3400, TO_DATE('2024-12-03', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(44, TO_DATE('2024-04-28', 'YYYY-MM-DD'), '영천버섯', 'F011', '버섯', 140, 3600, TO_DATE('2024-12-01', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 두릅 데이터 (F012)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(45, TO_DATE('2024-01-30', 'YYYY-MM-DD'), '울릉농협', 'F012', '두릅', 100, 6000, TO_DATE('2024-12-15', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(46, TO_DATE('2024-02-29', 'YYYY-MM-DD'), '울릉농협', 'F012', '두릅', 90, 6200, TO_DATE('2024-12-10', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(47, TO_DATE('2024-03-30', 'YYYY-MM-DD'), '울릉농협', 'F012', '두릅', 110, 5900, TO_DATE('2024-12-08', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(48, TO_DATE('2024-04-30', 'YYYY-MM-DD'), '울릉농협', 'F012', '두릅', 95, 6100, TO_DATE('2024-12-05', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();

                    // 미나리 데이터 (F013)
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(49, TO_DATE('2024-01-28', 'YYYY-MM-DD'), '평택농산', 'F013', '미나리', 120, 4500, TO_DATE('2024-12-03', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodInputDB VALUES(50, TO_DATE('2024-02-28', 'YYYY-MM-DD'), '평택농산', 'F013', '미나리', 110, 4700, TO_DATE('2024-12-01', 'YYYY-MM-DD'))";
                    cmd.ExecuteNonQuery();



                    //FoodOutputDB 데이터 삽입
                    // 사과 출고 데이터 (F001) - 입고가 2000~2200원 대비 3000~3500원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (31, '서울식당', TO_DATE('2023-06-01', 'YYYY-MM-DD'), 'F001', '사과', 45, 3140)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (32, '부산식당', TO_DATE('2023-09-01', 'YYYY-MM-DD'), 'F001', '사과', 50, 3180)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (1, '서울식당', TO_DATE('2024-01-20', 'YYYY-MM-DD'), 'F001', '사과', 50, 3250)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (2, '부산식당', TO_DATE('2024-02-20', 'YYYY-MM-DD'), 'F001', '사과', 40, 3250)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (3, '대구식당', TO_DATE('2024-03-20', 'YYYY-MM-DD'), 'F001', '사과', 45, 3300)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (41, '속초식당', TO_DATE('2024-05-10', 'YYYY-MM-DD'), 'F001', '사과', 80, 3400)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (42, '수원식당', TO_DATE('2024-05-20', 'YYYY-MM-DD'), 'F001', '사과', 160, 3460)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (43, '서울식당', TO_DATE('2024-07-01', 'YYYY-MM-DD'), 'F001', '사과', 150, 3400)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (44, '화성식당', TO_DATE('2024-08-30', 'YYYY-MM-DD'), 'F001', '사과', 180, 3450)";
                    cmd.ExecuteNonQuery();

                    // 돼지고기 출고 데이터 (F002) - 입고가 7800~8200원 대비 11000~12000원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (33, '인천식당', TO_DATE('2023-07-01', 'YYYY-MM-DD'), 'F002', '돼지고기', 25, 11000)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (34, '대구식당', TO_DATE('2023-10-01', 'YYYY-MM-DD'), 'F002', '돼지고기', 30, 11200)";
                    cmd.ExecuteNonQuery();


                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (4, '인천식당', TO_DATE('2024-01-15', 'YYYY-MM-DD'), 'F002', '돼지고기', 30, 11500)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (5, '광주식당', TO_DATE('2024-02-15', 'YYYY-MM-DD'), 'F002', '돼지고기', 35, 11800)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (6, '대전식당', TO_DATE('2024-03-15', 'YYYY-MM-DD'), 'F002', '돼지고기', 25, 12000)";
                    cmd.ExecuteNonQuery();

                    // 당근 출고 데이터 (F003) - 입고가 950~1200원 대비 1800~2200원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (35, '광주식당', TO_DATE('2023-06-15', 'YYYY-MM-DD'), 'F003', '당근', 60, 1700)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (36, '대전식당', TO_DATE('2023-09-15', 'YYYY-MM-DD'), 'F003', '당근', 65, 1800)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (7, '울산식당', TO_DATE('2024-01-25', 'YYYY-MM-DD'), 'F003', '당근', 80, 1800)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (8, '강릉식당', TO_DATE('2024-02-25', 'YYYY-MM-DD'), 'F003', '당근', 70, 2000)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (9, '속초식당', TO_DATE('2024-03-25', 'YYYY-MM-DD'), 'F003', '당근', 75, 2200)";
                    cmd.ExecuteNonQuery();

                    // 쌀 출고 데이터 (F006) - 입고가 2450~2600원 대비 3500~4000원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (37, '울산식당', TO_DATE('2023-08-01', 'YYYY-MM-DD'), 'F006', '쌀', 170, 3300)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (38, '수원식당', TO_DATE('2023-11-01', 'YYYY-MM-DD'), 'F006', '쌀', 180, 3400)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (10, '수원식당', TO_DATE('2024-01-10', 'YYYY-MM-DD'), 'F006', '쌀', 200, 3500)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (11, '안양식당', TO_DATE('2024-02-10', 'YYYY-MM-DD'), 'F006', '쌀', 180, 3800)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (12, '용인식당', TO_DATE('2024-03-10', 'YYYY-MM-DD'), 'F006', '쌀', 190, 4000)";
                    cmd.ExecuteNonQuery();

                    // 고등어 출고 데이터 (F007) - 입고가 3900~4200원 대비 5500~6000원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (39, '성남식당', TO_DATE('2023-07-15', 'YYYY-MM-DD'), 'F007', '고등어', 40, 5500)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (40, '안양식당', TO_DATE('2023-10-15', 'YYYY-MM-DD'), 'F007', '고등어', 45, 5500)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (13, '성남식당', TO_DATE('2024-01-15', 'YYYY-MM-DD'), 'F007', '고등어', 50, 5750)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (14, '안산식당', TO_DATE('2024-02-15', 'YYYY-MM-DD'), 'F007', '고등어', 45, 5800)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (15, '화성식당', TO_DATE('2024-03-15', 'YYYY-MM-DD'), 'F007', '고등어', 48, 5900)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (45, '시흥식당', TO_DATE('2024-08-10', 'YYYY-MM-DD'), 'F007', '고등어', 180, 5900)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (46, '하남식당', TO_DATE('2024-08-20', 'YYYY-MM-DD'), 'F007', '고등어', 165, 5900)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (47, '파주식당', TO_DATE('2024-08-30', 'YYYY-MM-DD'), 'F007', '고등어', 100, 5950)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (48, '의정부식당', TO_DATE('2024-10-05', 'YYYY-MM-DD'), 'F007', '고등어', 180, 5950)";
                    cmd.ExecuteNonQuery();

                    // 두부 출고 데이터 (F008) - 입고가 1750~1900원 대비 2500~3000원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (16, '평택식당', TO_DATE('2024-01-05', 'YYYY-MM-DD'), 'F008', '두부', 40, 2500)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (17, '시흥식당', TO_DATE('2024-02-05', 'YYYY-MM-DD'), 'F008', '두부', 35, 2800)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (18, '오산식당', TO_DATE('2024-03-05', 'YYYY-MM-DD'), 'F008', '두부', 38, 3000)";
                    cmd.ExecuteNonQuery();

                    // 계란 출고 데이터 (F009) - 입고가 5400~5700원 대비 7000~7500원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (19, '군포식당', TO_DATE('2024-01-20', 'YYYY-MM-DD'), 'F009', '계란', 120, 7000)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (20, '의왕식당', TO_DATE('2024-02-20', 'YYYY-MM-DD'), 'F009', '계란', 100, 7200)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (21, '하남식당', TO_DATE('2024-03-20', 'YYYY-MM-DD'), 'F009', '계란', 110, 7500)";
                    cmd.ExecuteNonQuery();

                    // 김치 출고 데이터 (F010) - 입고가 8900~9200원 대비 12000~13000원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (22, '구리식당', TO_DATE('2024-01-25', 'YYYY-MM-DD'), 'F010', '김치', 70, 12000)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (23, '남양주식당', TO_DATE('2024-02-25', 'YYYY-MM-DD'), 'F010', '김치', 65, 12500)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (24, '파주식당', TO_DATE('2024-03-25', 'YYYY-MM-DD'), 'F010', '김치', 68, 13000)";
                    cmd.ExecuteNonQuery();

                    // 버섯 출고 데이터 (F011) - 입고가 3400~3700원 대비 5000~5500원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (25, '고양식당', TO_DATE('2024-01-30', 'YYYY-MM-DD'), 'F011', '버섯', 40, 5000)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (26, '의정부식당', TO_DATE('2024-02-28', 'YYYY-MM-DD'), 'F011', '버섯', 35, 5200)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (27, '김포식당', TO_DATE('2024-03-30', 'YYYY-MM-DD'), 'F011', '버섯', 38, 5500)";
                    cmd.ExecuteNonQuery();

                    // 두릅 출고 데이터 (F012) - 입고가 5900~6200원 대비 8000~8500원으로 출고
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (28, '광명식당', TO_DATE('2024-01-30', 'YYYY-MM-DD'), 'F012', '두릅', 25, 8390)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (29, '과천식당', TO_DATE('2024-02-28', 'YYYY-MM-DD'), 'F012', '두릅', 20, 8410)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (30, '양주식당', TO_DATE('2024-03-30', 'YYYY-MM-DD'), 'F012', '두릅', 22, 8500)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (49, '고양식당', TO_DATE('2024-06-10', 'YYYY-MM-DD'), 'F012', '두릅', 60, 8480)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (50, '군포식당', TO_DATE('2024-06-20', 'YYYY-MM-DD'), 'F012', '두릅', 100, 8420)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (51, '하남식당', TO_DATE('2024-10-01', 'YYYY-MM-DD'), 'F012', '두릅', 100, 8420)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutputDB (foodOutID, foodOutput, foodOutDate, foodCode, foodName, foodQuantity, foodOutPrice) VALUES (52, '김포식당', TO_DATE('2024-10-05', 'YYYY-MM-DD'), 'F012', '두릅', 60, 8480)";
                    cmd.ExecuteNonQuery();

                    // 유통기한 12월 11일 이전 데이터 (8개)
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F002', '2024-12-06', '돼지고기', '강남식당', 80)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F003', '2024-12-02', '당근', '서초식당', 150)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F007', '2024-12-04', '고등어', '송파식당', 100)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F008', '2024-12-05', '두부', '마포식당', 70)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F009', '2024-12-07', '계란', '영등포식당', 200)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F011', '2024-12-03', '버섯', '용산식당', 60)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F013', '2024-12-02', '미나리', '종로식당', 90)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F004', '2024-12-09', '감자', '중구식당', 85)";
                    cmd.ExecuteNonQuery();

                    // 유통기한 12월 11일 이후 데이터 (7개)
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F001', '2024-12-20', '사과', '동대문식당', 120)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F005', '2024-12-25', '양파', '성동식당', 180)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F006', '2024-12-18', '쌀', '광진식당', 250)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F010', '2024-12-22', '김치', '도봉식당', 300)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO FoodOutRequire VALUES ('F012', '2024-12-15', '두릅', '노원식당', 150)";
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
}


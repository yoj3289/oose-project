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
    public partial class SalesMain : Form
    {
        public SalesMain()
        {
            InitializeComponent();

            string best = "";
            string worst = "";

            string connectionString = "User Id=fooduser; Password=1111; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe)));";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    List<string> inputNameList = new List<string>();
                    List<int> inputTotalList = new List<int>();
                    List<string> outputNameList = new List<string>();
                    List<int> outputTotalList = new List<int>();

                    string inputQuery = @"SELECT foodName, SUM(foodInQuantity * foodInPrice) AS totalValue FROM FoodInputDB GROUP BY foodName, foodCode";
                    using (OracleCommand command = new OracleCommand(inputQuery, connection))
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            inputNameList.Add(reader.GetString(0));
                            inputTotalList.Add(Convert.ToInt32(reader.GetDecimal(1)));
                        }
                    }

                    string outputQuery = @"SELECT foodName, SUM(foodTotalPrice) AS totalValue FROM FoodOutputDB GROUP BY foodName, foodCode";
                    using (OracleCommand command = new OracleCommand(outputQuery, connection))
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            outputNameList.Add(reader.GetString(0));
                            outputTotalList.Add(Convert.ToInt32(reader.GetDecimal(1)));
                        }
                    }

                    List<string> resultList = new List<string>();

                    // Dictionary를 사용하여 input과 output의 값을 매핑
                    Dictionary<string, int> inputDict = new Dictionary<string, int>();
                    Dictionary<string, int> outputDict = new Dictionary<string, int>();

                    // inputNameList와 inputTotalList를 Dictionary에 추가
                    for (int i = 0; i < inputNameList.Count; i++)
                    {
                        inputDict[inputNameList[i]] = inputTotalList[i];
                    }

                    // outputNameList와 outputTotalList를 Dictionary에 추가
                    for (int i = 0; i < outputNameList.Count; i++)
                    {
                        outputDict[outputNameList[i]] = outputTotalList[i];
                    }

                    // 모든 이름을 기준으로 결과 계산
                    var allNames = new HashSet<string>(inputNameList);
                    allNames.UnionWith(outputNameList);

                    foreach (var name in allNames)
                    {
                        int inputTotal = inputDict.ContainsKey(name) ? inputDict[name] : 0;
                        int outputTotal = outputDict.ContainsKey(name) ? outputDict[name] : 0;

                        int difference = outputTotal - inputTotal;

                        // 결과 리스트에 추가
                        resultList.Add($"{name}: {difference}");
                    }

                    // 결과를 내림차순으로 정렬
                    resultList = resultList.OrderByDescending(x => int.Parse(x.Split(':')[1].Trim())).ToList();

                    for (int i = 0; i < resultList.Count(); i++)
                    {
                        char targetChar = ':';
                        int index = resultList[i].IndexOf(targetChar);

                        if (index != -1) // 특정 문자가 문자열에 존재하는 경우
                        {
                            resultList[i] = resultList[i].Substring(0, index);
                        }
                    }

                    for (int i = 0; i < resultList.Count(); i++)
                    {
                        Console.WriteLine(resultList[i]);
                    }

                    List<string> bestList = new List<string>();
                    List<string> worstList = new List<string>();

                    int count = resultList.Count;

                    for (int i = 0; i < Math.Min(3, count); i++)
                    {
                        bestList.Add(resultList[i]);
                    }

                    if (count > 3)
                    {
                        for (int i = count - 1; i >= Math.Max(count - 3, 3); i--)
                        {
                            worstList.Add(resultList[i]);
                        }
                    }

                    // best와 worst 설정
                    best = string.Join("\n", bestList.Select((name, index) => $"{index + 1}. {name}"));
                    worst = string.Join("\n", worstList.Select((name, index) => $"{index + 1}. {name}"));
                }
                catch (Exception ex)
                {
                    return;
                }
            }

            lbl_best.Text = best;
            lbl_worst.Text = worst;
        }

        private void toSalesFoodStatisticsBtn_Click(object sender, EventArgs e)
        {
            SalesFoodStatistics salesFoodStatistics = new SalesFoodStatistics();
            salesFoodStatistics.Show();
        }

        private void toSalesInputStatisticsBtn_Click(object sender, EventArgs e)
        {
            SalesInputStatistics salesInputStatistics = new SalesInputStatistics();
            salesInputStatistics.Show();
        }

        private void toSalesOutputStatisticsBtn_Click(object sender, EventArgs e)
        {
            SalesOutputStatistics salesOutputStatistics = new SalesOutputStatistics();
            salesOutputStatistics.Show();
        }
    }
}

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

                    string inputQuery = @"SELECT foodInput.foodName, (foodInput.foodInQuantity * foodInput.foodInPrice) - foodOutput.foodTotalPrice AS result FROM FoodInputDB foodInput JOIN FoodOutputDB foodOutput ON foodInput.foodCode = foodOutput.foodCode ORDER BY result DESC";

                    using (OracleCommand command = new OracleCommand(inputQuery, connection))
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        List<string> bestList = new List<string>();
                        List<string> worstList = new List<string>();

                        int count = 0;
                        // 결과를 읽어들임
                        while (reader.Read())
                        {
                            string foodName = reader.GetString(0);
                            decimal result = reader.GetDecimal(1);

                            // 가장 높은 3개
                            if (count < 3)
                            {
                                bestList.Add(foodName);
                            }
                            // 가장 낮은 3개
                            else if (count >= (reader.FieldCount - 3))
                            {
                                worstList.Add(foodName);
                            }
                            count++;
                        }

                        // best와 worst 설정
                        best = string.Join("\n", bestList.Select((name, index) => $"{index + 1}. {name}"));
                        worst = string.Join("\n", worstList.Select((name, index) => $"{index + 1}. {name}"));
                    }
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace YumYumFood
{
    public partial class FoodInput_Search : Form
    {
        private OracleConnection odpConn = new OracleConnection();
        public FoodInput_Search()
        {
            InitializeComponent();
            RequestInputData();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string foodInput = foodInput_text.Text.Trim();
            if (string.IsNullOrEmpty(foodInput) || foodInput.Length > 20)
            {
                MessageBox.Show("입고처는 1~20자 사이로 입력해야 합니다.", "유효성 검사 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RequestInputData(foodInput);
        }

        private void RequestInputData()
        {
            string query = "SELECT foodInDate, foodInPut, foodCode, foodName, foodInQuantity, foodInPrice, foodExpiryDatePrice FROM FoodInputDB";
            odpConn.ConnectionString = "User Id=fooduser; Password=1111; Data Source=(DESCRIPTION =   (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))   (CONNECT_DATA =     (SERVER = DEDICATED)     (SERVICE_NAME = xe)   ) );";
            odpConn.Open();
            OracleDataAdapter oda = new OracleDataAdapter()
            {
                SelectCommand = new OracleCommand(query, odpConn)
            };
            DataTable dt = new DataTable();
            oda.Fill(dt);
            odpConn.Close();
            foodIn_Grid.DataSource = dt;
            foodIn_Grid.Columns["foodInDate"].HeaderText = "입고일자";
            foodIn_Grid.Columns["foodInPut"].HeaderText = "입고처";
            foodIn_Grid.Columns["foodCode"].HeaderText = "식자재번호";
            foodIn_Grid.Columns["foodName"].HeaderText = "식자재명";
            foodIn_Grid.Columns["foodInQuantity"].HeaderText = "입고수량";
            foodIn_Grid.Columns["foodInPrice"].HeaderText = "입고가격";
            foodIn_Grid.Columns["foodExpiryDatePrice"].HeaderText = "유통기한";
            foodIn_Grid.AutoResizeColumns();
            foodIn_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foodIn_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foodIn_Grid.AllowUserToAddRows = false;
        }

        private void RequestInputData(string foodInput)
        {
            string query = "SELECT foodInDate, foodInPut, foodCode, foodName, foodInQuantity, foodInPrice, foodExpiryDatePrice FROM FoodInputDB WHERE foodInPut = :foodInPut";
            odpConn.ConnectionString = "User Id=fooduser; Password=1111; Data Source=(DESCRIPTION =   (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))   (CONNECT_DATA =     (SERVER = DEDICATED)     (SERVICE_NAME = xe)   ) );";
            odpConn.Open();
            OracleCommand cmd = new OracleCommand(query, odpConn);
            cmd.Parameters.Add(new OracleParameter(":foodInPut", foodInput));

            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            oda.Fill(dt);

            odpConn.Close();

            foodIn_Grid.DataSource = dt;
            foodIn_Grid.Columns["foodInDate"].HeaderText = "입고일자";
            foodIn_Grid.Columns["foodInPut"].HeaderText = "입고처";
            foodIn_Grid.Columns["foodCode"].HeaderText = "식자재번호";
            foodIn_Grid.Columns["foodName"].HeaderText = "식자재명";
            foodIn_Grid.Columns["foodInQuantity"].HeaderText = "입고수량";
            foodIn_Grid.Columns["foodInPrice"].HeaderText = "입고가격";
            foodIn_Grid.Columns["foodExpiryDatePrice"].HeaderText = "유통기한";
            foodIn_Grid.AutoResizeColumns();
            foodIn_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foodIn_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foodIn_Grid.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestInputData();
        }
    }
}

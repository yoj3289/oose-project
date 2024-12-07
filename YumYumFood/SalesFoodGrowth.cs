using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YumYumFood
{
    public partial class SalesFoodGrowth : Form
    {
        List<FoodInfo> recivedRawList;

        public SalesFoodGrowth(List<FoodInfo> recivedRawList)
        {
            this.recivedRawList = recivedRawList;
            InitializeComponent();

            FoodInfo temp = recivedRawList[0];
            lbl_title.Text = temp.GetFoodName() + "의 차액 성장도"; // 타이틀 레이블 초기화
            cb_group.SelectedIndex = 0; // 그룹 콤보박스 초기화
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            ClearPanel();

            string groupStandard = cb_group.SelectedItem.ToString(); // 그룹 기준 get
            
            List<string> labels = Grouping(groupStandard);
            ShowLabelsToPanel(labels);
        }

        private void ClearPanel() // 패널 비우기
        {
            pnl_chart.Controls.Clear();
        }

        private void ShowLabelsToPanel(List<string> labelTexts) // 패널에 레이블 및 화살표 표시
        {
            int padding = 10; // 맨 왼쪽, 맨 오른쪽 패딩
            int arrowPadding = 60; // 화살표와 Label 간 간격
            int currentX = padding; // 현재X (첫 번째 레이블 위치로 초기화)

            foreach (string text in labelTexts)
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label // 내용 레이블 생성
                {
                    Text = text,
                    AutoSize = true,
                    Location = new Point(currentX, 0), // 수직 중앙 정렬
                    Font = new Font("세방고딕 Regular", 16, FontStyle.Regular), // Font 설정
                    TextAlign = ContentAlignment.MiddleCenter // 텍스트 중앙 정렬
                };
                pnl_chart.Controls.Add(label); // 레이블 패널에 추가
                label.Top = (pnl_chart.Height - label.Height) / 2; // 높이 설정

                currentX += label.Width + arrowPadding; // 다음 X 좌표로 이동

                if (labelTexts.IndexOf(text) < labelTexts.Count - 1) // 마지막 Label이 아니라면 화살표 추가
                {
                    System.Windows.Forms.Label arrow = new System.Windows.Forms.Label // 화살표 레이블 생성
                    {
                        Text = "→",
                        AutoSize = true,
                        Location = new Point(currentX, 0), // 수직 중앙 정렬
                        Font = new Font("세방고딕 Regular", 16, FontStyle.Regular), // Font 설정
                        TextAlign = ContentAlignment.MiddleCenter // 텍스트 중앙 정렬
                    };
                    pnl_chart.Controls.Add(arrow);
                    arrow.Top = (pnl_chart.Height - arrow.Height) / 2; // 높이 설정

                    currentX += arrow.Width + arrowPadding; // 다음 X 좌표로 이동
                }
            }

            // 맨 오른쪽 패딩용 더미 패널
            currentX -= arrowPadding;
            Panel spacer = new Panel
            {
                Size = new Size(padding, (pnl_chart.Height - 20) / 2),
                Location = new Point(currentX, 0),
                BackColor = Color.Transparent // 투명하게 처리
            };
            pnl_chart.Controls.Add(spacer);
        }

        private List<string> Grouping(string standard)
        {
            Dictionary<string, FoodInfoRow> groupedData = new Dictionary<string, FoodInfoRow>(); // 중간 저장용 Dictionary
            Dictionary<string, int> groupItemCount = new Dictionary<string, int>(); // 그룹 데이터 개수를 저장할 Dictionary
            int previousDifference = 0; // 이전 그룹과의 차이값을 저장

            foreach (var i in recivedRawList) // 그룹핑 작업
            {
                string key = string.Empty;
                string groupName = null;

                // 그룹 기준에 따라 키 설정 및 그룹 이름 설정
                if (standard == "년")
                {
                    DateTime date = DateTime.Parse(i.GetFoodDate());
                    key = $"{i.GetFoodCode()}_{date.Year}"; // 키에 년 설정
                    groupName = $"{date.Year}년";
                }
                else if (standard == "월")
                {
                    DateTime date = DateTime.Parse(i.GetFoodDate());
                    key = $"{i.GetFoodCode()}_{date.Year}_{date.Month:D2}"; // 키에 년, 월 설정
                    groupName = $"{date.Year}년 {date.Month:D2}월";
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

                    groupItemCount[key]++; // 해당 그룹의 데이터 개수 증가
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
                    // 새 그룹의 데이터 개수 초기화
                    groupItemCount[key] = 1;
                }
            }

            List<string> result = new List<string>(); // 그룹화된 데이터를 문자열로 변환
            var sortedKeys = groupedData.Keys.OrderBy(key => key).ToList(); // 그룹명을 기준으로 정렬하고 키 get
            foreach (var key in sortedKeys)
            {
                FoodInfoRow entry = groupedData[key];

                int difference = entry.GetFoodOutPrice() - entry.GetFoodInPrice(); // 현재 그룹의 차액

                int change = difference - previousDifference; // 전 그룹 대비 차액 차이값
                previousDifference = difference;

                string formattedGroupName = entry.GetFoodGroup();
                string formattedInPrice = $"{difference:N0} 원";
                string formattedCount = $"{groupItemCount[key]:N0} 건"; // 데이터 개수
                string formattedChange = change > 0 ? $"(+{change:N0} 원)" : $"({change:N0} 원)";

                // 최종 문자열 생성
                string groupSummary = $"{formattedGroupName}\n{formattedInPrice}\n{formattedCount}\n{formattedChange}";
                result.Add(groupSummary);
            }

            return result;
        }
    }
}

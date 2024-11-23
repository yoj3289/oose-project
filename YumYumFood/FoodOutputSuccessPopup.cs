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
    public partial class FoodOutputSuccessPopup : Form
    {
        public FoodOutputSuccessPopup()
        {
            InitializeComponent();

            // 폼 속성 설정
            this.FormBorderStyle = FormBorderStyle.FixedDialog;  // 크기 고정
            this.MaximizeBox = false;  // 최대화 버튼 제거
            this.MinimizeBox = false;  // 최소화 버튼 제거
            this.StartPosition = FormStartPosition.CenterParent;  // 부모 폼 중앙에 표시

            // button1 클릭 이벤트 설정
            this.button1.Click += (s, e) => this.Close();
        }
    }
}

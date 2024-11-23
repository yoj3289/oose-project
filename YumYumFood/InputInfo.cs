using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYumFood
{
    public class InputInfo
    {
        private string inputName;
        private string inputDate;
        private int inputPrice;

        public InputInfo(string inputName, string inputDate, int inputPrice)
        {
            this.inputName = inputName;
            this.inputDate = inputDate;
            this.inputPrice = inputPrice;
        }

        public string GetInputName() { return inputName; }
        public string GetInputDate() { return inputDate; }
        public int GetInputPrice() { return inputPrice; }
    }
}

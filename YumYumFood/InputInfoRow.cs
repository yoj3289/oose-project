using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYumFood
{
    public class InputInfoRow
    {
        private string inputName;
        private int inputPrice;
        private string inputGroup;

        public InputInfoRow(string inputName, int inputPrice)
        {
            this.inputName = inputName;
            this.inputPrice = inputPrice;
        }

        public string GetInputName() { return inputName; }
        public int GetInputPrice() { return inputPrice; }
        public string GetInputGroup() { return inputGroup; }

        public void SetInputPrice(int price) { this.inputPrice = price; }
        public void SetInputGroup(string group) { this.inputGroup = group; }
    }
}

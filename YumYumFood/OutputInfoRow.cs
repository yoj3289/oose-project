using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYumFood
{
    public class OutputInfoRow
    {
        private string outputName;
        private int outputPrice;
        private string outputGroup;

        public OutputInfoRow(string outputName, int outputPrice)
        {
            this.outputName = outputName;
            this.outputPrice = outputPrice;
        }

        public string GetOutputName() { return outputName; }
        public int GetOutputPrice() { return outputPrice; }
        public string GetOutputGroup() { return outputGroup; }

        public void SetOutputPrice(int price) { this.outputPrice = price; }
        public void SetOutputGroup(string group) { this.outputGroup = group; }
    }
}

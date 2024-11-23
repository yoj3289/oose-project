using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYumFood
{
    public class OutputInfo
    {
        private string outputName;
        private string outputDate;
        private int outputPrice;

        public OutputInfo(string outputName, string outputDate, int outputPrice)
        {
            this.outputName = outputName;
            this.outputDate = outputDate;
            this.outputPrice = outputPrice;
        }

        public string GetOutputName() { return outputName; }
        public string GetOutputDate() { return outputDate; }
        public int GetOutputPrice() { return outputPrice; }
    }
}

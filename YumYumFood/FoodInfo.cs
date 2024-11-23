using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYumFood
{
    public class FoodInfo
    {
        private string foodCode;
        private string foodName;
        private string foodInOrOut;
        private string foodDate;
        private int foodPrice;

        public FoodInfo(string foodCode, string foodName, string foodInOrOut, string foodDate, int foodPrice) {
            this.foodCode = foodCode;
            this.foodName = foodName;
            this.foodInOrOut = foodInOrOut;
            this.foodDate = foodDate;
            this.foodPrice = foodPrice;
        }
        public string GetFoodCode() { return foodCode; }
        public string GetFoodName() { return foodName; }
        public string GetFoodInOrOut() { return foodInOrOut; }
        public string GetFoodDate() { return foodDate; }
        public int GetFoodPrice() { return foodPrice; }
    }
}

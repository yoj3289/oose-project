using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYumFood
{
    public class FoodInfoRow
    {
        private string foodCode;
        private string foodName;
        private int foodInPrice;
        private int foodOutPrice;
        private int foodDiffrence;
        private string foodGroup;

        public FoodInfoRow(string foodCode, string foodName, int foodInPrice, int foodOutPrice)
        {
            this.foodCode = foodCode;
            this.foodName = foodName;
            this.foodInPrice = foodInPrice;
            this.foodOutPrice = foodOutPrice;
        }
        public string GetFoodCode() { return foodCode; }
        public string GetFoodName() { return foodName; }
        public int GetFoodInPrice() { return foodInPrice; }
        public int GetFoodOutPrice() { return foodOutPrice; }
        public int GetFoodDiffrence() { return foodDiffrence; }
        public string GetFoodGroup() { return foodGroup; }

        public void SetFoodInPrice(int inPrice) { this.foodInPrice = inPrice; }
        public void SetFoodOutPrice(int outPrice) { this.foodOutPrice = outPrice; }
        public void SetFoodDiffrence(int difference) { this.foodDiffrence = difference; }
        public void SetFoodGroup(string group) { this.foodGroup = group; }
    }
}

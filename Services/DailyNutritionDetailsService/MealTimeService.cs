using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DailyNutritionDetailsService
{
    public class MealTimeService
    {
        private int _mealId;

        // ID'yi set eden fonksiyon
        public void SetMealId(int mealId)
        {
            _mealId = mealId;
        }

        // ID'yi get eden fonksiyon
        public int GetMealId()
        {
            return _mealId;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DailyNutritionDetailsDto
{
    public class NutritionSummaryDto
    {
        public int DailyMealTime { get; set; }
        public decimal TotalKcal { get; set; }
        public decimal TotalCarbohydrate { get; set; }
        public decimal TotalProtein { get; set; }
        public decimal TotalFat { get; set; }
    }
}

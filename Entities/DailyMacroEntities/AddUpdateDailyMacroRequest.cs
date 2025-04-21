using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DailyMacroEntities
{
    public class AddUpdateDailyMacroRequest
    {
        public decimal Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }
        public int AppUserId { get; set; }
    }
}

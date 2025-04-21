using Entities.DailyMacroEntities;
using Entities.DailyNutritionDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DailyMacroServices
{
    public interface IDailyMacroService
    {
        Task<bool> AddDailyMacro(AddUpdateDailyMacroRequest dailyMacroRequest);
        Task<bool> UpdateDailyMacro(DailyMacroResponseModel dailyMacroRequest);
        Task<DailyMacroResponseModel> GetDailyMacroByUserId(int  userId);
    }
}

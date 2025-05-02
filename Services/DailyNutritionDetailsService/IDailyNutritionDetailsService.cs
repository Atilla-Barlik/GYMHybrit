using Entities.DailyNutritionDetails;
using Entities.DailyNutritionDetailsDto;
using Entities.DailyNutritionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DailyNutritionDetailsService
{
    public interface IDailyNutritionDetailsService
    {
        Task<List<DailyNutritionDetailsResponseModel>> GetAllDailyNutritiontList();
        Task<DailyNutritionDetailsResponseModel> GetDailyNutritionById(int Id);
        Task<bool> AddDailyNutrition(AddUpdateDailyNutritionDetailsRequest nutrientRequest);
        Task<bool> UpdateDailyNutrition(DailyNutritionDetailsResponseModel nutrientRequest, int id);
        Task<bool> DeleteDailyNutrition(DailyNutritionDetailsResponseModel nutrientRequest);
        Task<List<NutritionSummaryDto>> GetTotalMeal(int UserId);
        Task<List<TotalUsageNutritionDto>> GetTotalUsageNutrition();
        Task<List<DailyNutritionDetailsResponseModel>> GetUserMostUsageNutrients(int UserId);

    }
}

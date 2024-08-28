using Entities.DailyNutritionEntities;
using Entities.NutrientEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DailyNutritionServices
{
    public interface IDailyNutritionService
    {
        Task<List<DailyNutritionResponseModel>> GetAllDailyNutritiontList();
        Task<DailyNutritionResponseModel> GetDailyNutritionById(int Id);
        Task<bool> AddDailyNutrition(AddUpdateDailyNutritionRequest nutrientRequest);
        Task<bool> UpdateDailyNutrition(DailyNutritionResponseModel nutrientRequest, int id);
        Task<bool> DeleteDailyNutrition(DailyNutritionResponseModel nutrientRequest);
        Task<List<DailyNutritionResponseModel>> GetDailyNutritionByName(string name);
        Task<bool> GetDailyNutritionCheck(int id, DateOnly date);
    }
}

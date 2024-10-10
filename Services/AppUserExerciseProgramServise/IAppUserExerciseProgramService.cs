using Entities.AppUserExerciseProgramEntities;
using Entities.DailyNutritionDetails;
using Entities.UserExerciseProgramEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AppUserExerciseProgramServise
{
    public interface IAppUserExerciseProgramService
    {
        Task<bool> AddAppUserExercise(AppUserExerciseProgramResponseModel request);
        Task<List<CombinedExerciseDataResponseModel>> GetAppUserExerciseProgramDetails(int AppUserId);
        Task<bool> DeleteAppUserExerciseProgram(AddUpdateAppUserExerciseProgramRequest appUserExerciseProgramRequest);
        Task<bool> UpdateAppUserExerciseProgram(AddUpdateAppUserExerciseProgramRequest addUpdateAppUserExerciseProgramRequest);
    }
}

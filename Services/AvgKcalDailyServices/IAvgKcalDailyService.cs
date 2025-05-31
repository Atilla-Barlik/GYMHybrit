using Entities.AppUserExerciseProgramEntities;
using Entities.AvgKcalDailyEntities;
using Entities.UserExerciseProgramEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AvgKcalDailyServices
{
    public interface IAvgKcalDailyService
    {
        Task<bool> AddAvgKcalDaily(AddUpdateAvgKcalDailyRequest request);
        Task<List<AvgKcalDailyResponseModel>> GetAppUserExerciseProgramDetails(int AppUserId);
    }
}

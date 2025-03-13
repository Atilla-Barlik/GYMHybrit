using Entities.ExerciseEntities;
using Entities.UserExerciseProgramEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StatisticServices
{
    public interface IStatisticService
    {
        Task<List<ExerciseStatisticsModel>> GetAllExercisesStatistics();
    }
}

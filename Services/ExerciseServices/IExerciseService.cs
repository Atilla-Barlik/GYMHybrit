using Entities.ExerciseEntities;
using Entities.NutrientEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExerciseServices
{
    public interface IExerciseService
    {
        Task<List<ExerciseResponseModel>> GetAllExercises();
    }
}

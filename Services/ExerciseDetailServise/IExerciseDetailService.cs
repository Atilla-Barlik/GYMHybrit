using Entities.ExerciseDetailEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExerciseDetailServise
{
    public interface IExerciseDetailService
    {
        Task<List<ExerciseDetailsResponseModel>> GetExerciseDetailList(int id);
    }
}

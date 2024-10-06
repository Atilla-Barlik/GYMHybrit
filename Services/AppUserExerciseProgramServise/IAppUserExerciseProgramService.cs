using Entities.AppUserExerciseProgramEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AppUserExerciseProgramServise
{
    public interface IAppUserExerciseProgramService
    {
        Task<bool> AddAppUserExercise(AddUpdateAppUserExerciseProgramRequest request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UserExerciseProgramEntities
{
    public class CombinedExerciseDataResponseModel
    {
        public int AppUserExerciseProgramId { get; set; }
        public int ExerciseRepeat { get; set; }
        public int ExerciseSet { get; set; }
        public int ExerciseTotalBurnedKcal { get; set; }
        public int AppUserId { get; set; }
        public int DayNo { get; set; }
        public DateOnly Date { get; set; }
        public ExerciseDetailResponseModel ExerciseDetailDto { get; set; } 
    }
}

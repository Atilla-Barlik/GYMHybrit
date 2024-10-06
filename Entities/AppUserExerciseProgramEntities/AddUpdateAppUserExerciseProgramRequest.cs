using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AppUserExerciseProgramEntities
{
    public class AddUpdateAppUserExerciseProgramRequest
    {
        public int ExerciseRepeat { get; set; }
        public int ExerciseSet { get; set; }
        public int ExerciseTotalBurnedKcal { get; set; }
        public int ExerciseDetailId { get; set; }
        public int AppUserId { get; set; }
        public int DayNo { get; set; }
        public DateOnly Date { get; set; }
    }
}

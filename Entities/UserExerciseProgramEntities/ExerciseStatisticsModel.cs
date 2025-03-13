using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UserExerciseProgramEntities
{
    public class ExerciseStatisticsModel
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string DateFormatted { get; set; }
        public DateOnly Date { get; set; }
        public int ExerciseRepeat { get; set; }
        public int ExerciseSet { get; set; }
        public decimal ExerciseWeight { get; set; }
        public decimal ExerciseTotalBurnedKcal { get; set; }
    }
}

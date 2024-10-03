using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ExerciseDetailEntities
{
    public class ExerciseDetailsResponseModel
    {
        public int ExerciseDetailId { get; set; }
        public string Name { get; set; }
        public int AverageKcal { get; set; }
        public string Difficulty { get; set; }
        public string Equipment { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Gif1 { get; set; }
        public string Gif2 { get; set; }
        public string Gif3 { get; set; }
        public int ExerciseId { get; set; }
    }
}

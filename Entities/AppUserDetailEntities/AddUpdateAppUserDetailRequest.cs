using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AppUserDetailEntities
{
    public class AddUpdateAppUserDetailRequest
    {
        public int AppUserDetailId { get; set; }
        public int Length { get; set; }
        public decimal Weight { get; set; }
        public string BeforeImage { get; set; }
        public string AfterImage { get; set; }
        public int Age { get; set; }
        public bool sex { get; set; }
        public int AppUserId { get; set; }
    }
}

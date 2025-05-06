using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AppUserEntities
{
    public class AddUpdateAppUserRequest
    {
        public string AppUserFirstName { get; set; }
        public string AppUserLastName { get; set; }
        public string AppUserEmail { get; set; }
        public string AppUserPassword { get; set; }

    }
}

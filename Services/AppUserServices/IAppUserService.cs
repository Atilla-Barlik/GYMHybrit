using Entities.AppUserEntities;
using Entities.DailyMacroEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AppUserServices
{
    public interface IAppUserService
    {
        Task<AppUserResponseModel> GetAppUserByUserId(int userId);
        Task<bool> CreateAppUser(AddUpdateAppUserRequest addUpdateAppUserRequest);
    }
}

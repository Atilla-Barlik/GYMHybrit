using Entities.AppUserDetailEntities;
using Entities.DailyNutritionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AppUserDetailServices
{
    public interface IAppUserDetailService
    {
        Task<AddUpdateAppUserDetailRequest> GetAppUserDetailByUserId(int userId);
        Task<bool> UpdateAppUserDetail(AddUpdateAppUserDetailRequest appUserDetailRequest);
        
    }
}

using Entities.AppUserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthServices
{
    public interface IAuthService
    {
        //Task<bool> RegisterAsync(RegisterRequest request);
        Task<int> LoginAsync(LoginRequest request);
    }
}

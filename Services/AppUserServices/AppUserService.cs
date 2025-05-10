using Entities.AppUserEntities;
using Entities.DailyMacroEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AppUserServices
{
    public class AppUserService : IAppUserService
    {
        private string _baseURL = "https://localhost:7149";
        public AppUserResponseModel? AppUserResponseModel { get; set; }

        public async Task<bool> CreateAppUser(AddUpdateAppUserRequest addUpdateAppUserRequest)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AppUser";

                    var serializeContent = JsonConvert.SerializeObject(addUpdateAppUserRequest);

                    var apiResponse = await client.PostAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        return true;

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return returnResponse;
        }

        public async Task<AppUserResponseModel> GetAppUserByUserId(int userId)
        {
            AppUserResponseModel = new AppUserResponseModel();

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AppUser/1";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        AppUserResponseModel = JsonConvert.DeserializeObject<AppUserResponseModel>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return AppUserResponseModel;
        }
    }
}

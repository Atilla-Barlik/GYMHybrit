using Entities.AppUserDetailEntities;
using Entities.AppUserEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AppUserDetailServices
{
    public class AppUserDetailService : IAppUserDetailService
    {
        private string _baseURL = "https://localhost:7149";
        public AddUpdateAppUserDetailRequest? AppUserDetailResponseModel { get; set; }

        //public async Task<bool> CreateAppUserDetail(AppUserDetailResponseModel Response)
        //{
        //    var returnResponse = false;
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            string url = $"{_baseURL}/api/AppUserDetail";


        //            var serializeContent = JsonConvert.SerializeObject(Response);

        //            var apiResponse = await client.PostAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

        //            if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
        //            {

        //                return true;

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }

        //    return returnResponse;
        //}

        public async Task<AddUpdateAppUserDetailRequest> GetAppUserDetailByUserId(int userId)
        {
            AppUserDetailResponseModel = new AddUpdateAppUserDetailRequest();

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AppUserDetail/appUserDetails/{userId}";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        AppUserDetailResponseModel = JsonConvert.DeserializeObject<AddUpdateAppUserDetailRequest>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return AppUserDetailResponseModel;
        }

        public async Task<bool> UpdateAppUserDetail(AddUpdateAppUserDetailRequest appUserDetailRequest)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AppUserDetail";


                    var serializeContent = JsonConvert.SerializeObject(appUserDetailRequest);

                    var apiResponse = await client.PutAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

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
    }
}

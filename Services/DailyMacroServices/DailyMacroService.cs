using Entities.DailyMacroEntities;
using Entities.DailyNutritionEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DailyMacroServices
{
    public class DailyMacroService : IDailyMacroService
    {
        private string _baseURL = "https://localhost:7149";
        public DailyMacroResponseModel? DailyMacroResponseModel { get; set; }
        public async Task<bool> AddDailyMacro(AddUpdateDailyMacroRequest dailyMacroRequest)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyMacro";

                    var serializeContent = JsonConvert.SerializeObject(dailyMacroRequest, Formatting.Indented);

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

        public async Task<DailyMacroResponseModel> GetDailyMacroByUserId(int userId)
        {
            DailyMacroResponseModel = new DailyMacroResponseModel();

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyMacro/latest/1";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        DailyMacroResponseModel = JsonConvert.DeserializeObject<DailyMacroResponseModel>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return DailyMacroResponseModel;
        }

        public async Task<bool> UpdateDailyMacro(DailyMacroResponseModel dailyMacroRequest)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyMacro";


                    var serializeContent = JsonConvert.SerializeObject(dailyMacroRequest);

                    var apiResponse = await client.PutAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
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

using Entities.DailyNutritionEntities;
using Entities.NutrientEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.DailyNutritionServices
{
    public class DailyNutritionService : IDailyNutritionService
    {
        private string _baseURL = "https://localhost:7149";
        public JsonSerializerOptions JsonSerializerOptions;
        private List<DailyNutritionResponseModel>? returnResponse;
        public DailyNutritionResponseModel? returnResponseModel;

        public Task<List<DailyNutritionResponseModel>> GetAllDailyNutritiontList()
        {
            throw new NotImplementedException();
        }

        public async Task<DailyNutritionResponseModel> GetDailyNutritionById(int Id)
        {
            returnResponseModel = new DailyNutritionResponseModel();

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyNutrition/{Id}";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        returnResponseModel = JsonConvert.DeserializeObject<DailyNutritionResponseModel>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return returnResponseModel;
        }

        public async Task<bool> AddDailyNutrition(AddUpdateDailyNutritionRequest nutrientRequest)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyNutrition";

                    var serializeContent = JsonConvert.SerializeObject(nutrientRequest);

                    var apiResponse = await client.PostAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.Created)
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

        public Task<bool> UpdateDailyNutrition(DailyNutritionResponseModel nutrientRequest, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDailyNutrition(DailyNutritionResponseModel nutrientRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<DailyNutritionResponseModel>> GetDailyNutritionByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetDailyNutritionCheck(int id, DateOnly date)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyNutritionCheck/1/2024-08-28";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        //returnResponseModel = JsonConvert.DeserializeObject<DailyNutritionResponseModel>(response);
                        if(response.Contains("true"))
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

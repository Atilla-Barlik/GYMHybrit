using Entities.DailyNutritionEntities;
using Entities.NutrientEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DailyNutritionResponseModel? dailyNutritionId;

        

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

        public async Task<bool> UpdateDailyNutrition(DailyNutritionResponseModel nutrientRequest, int id)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyNutrition";


                    var serializeContent = JsonConvert.SerializeObject(nutrientRequest);

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
    

        public Task<bool> DeleteDailyNutrition(DailyNutritionResponseModel nutrientRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<DailyNutritionResponseModel>> GetDailyNutritionByName(string name)
        {
            throw new NotImplementedException();
        }

        /*
         Gönderilen tarih ve kullanıcı id'sine göre databe üzerinde bu verilere göre bir kayıt olup olmadığını kontrol ediyor eğer var ise ilgili objeyi burada
        modelleyerek 1 değerini gönderiyor. Eğer yoksa 0 gönderip ilgili code bölgesinde yeni bir veri girdisi oluşturuyor.
         */

        public async Task<int> GetDailyNutritionCheck(int id)
        {
            DateTime dateTime = DateTime.Now;
            DateOnly date = DateOnly.FromDateTime(dateTime);
            var returnResponse = false;
            var response = "0";
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyNutritionCheck/1";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        
                        response = await apiResponse.Content.ReadAsStringAsync();
                        returnResponseModel = JsonConvert.DeserializeObject<DailyNutritionResponseModel>(response);
                        dailyNutritionId = new DailyNutritionResponseModel
                        {
                            DailyNutritionID = returnResponseModel.DailyNutritionID,
                            AppUserId = returnResponseModel.AppUserId,
                            DailyNutritionStatus = returnResponseModel.DailyNutritionStatus,
                            DailyNutritionTotalCarbohydrate = 0,
                            DailyNutritionTotalFat = 0,
                            DailyNutritionTotalKcal = 0,
                            DailyNutritionTotalProtein = 0,
                            Date = date
                        };
                        return 1;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return 0;
        }

        public DailyNutritionResponseModel dailyNutrition
        {
            set { dailyNutritionId = value; }
            get => dailyNutritionId;
        }
    }
}

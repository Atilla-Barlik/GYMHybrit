using Entities.NutrientEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.NutrientServices
{
	public class NutrientService : INutrientService
	{
		private string _baseURL = "https://localhost:7137";
		public JsonSerializerOptions JsonSerializerOptions;
		private List<NutrientResponseModel>? returnResponse;
		private readonly HttpClient httpClient;
		public NutrientResponseModel? returnResponseModel;


		public async Task<List<NutrientResponseModel>> GetAllNutrientList()
		{
			returnResponse = new List<NutrientResponseModel>();
			try
			{
				using (var client = new HttpClient())
				{
					string url = $"{_baseURL}/api/nutrients?pageNumber=1&pageSize=50";
					var apiResponse = await client.GetAsync(url);

					if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
					{

						var response = await apiResponse.Content.ReadAsStringAsync();

						returnResponse = JsonConvert.DeserializeObject
							<List<NutrientResponseModel>>(response);

					}
				}
			}
			catch (Exception ex)
			{
				string msg = ex.Message;
			}

			return returnResponse;
			//return await client.GetFromJsonAsync<NutrientResponseModel[]>("https://localhost:7137/api/nutrients/1");
		}

		public async Task<NutrientResponseModel> GetNutrientDetailById(int Id)
		{

			returnResponseModel = new NutrientResponseModel();

			try
			{
				using (var client = new HttpClient())
				{
					string url = $"https://localhost:7149/api/Nutrient/{Id}";
					var apiResponse = await client.GetAsync(url);

					if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
					{

						var response = await apiResponse.Content.ReadAsStringAsync();

                        returnResponseModel = JsonConvert.DeserializeObject<NutrientResponseModel>(response);

					}
				}
			}
			catch (Exception ex)
			{
				string msg = ex.Message;
			}

			return returnResponseModel;
		}

		public async Task<bool> AddNutrient(AddUpdateNutrientRequest nutrientRequest)
		{
			var returnResponse = false;
			try
			{
				using (var client = new HttpClient())
				{
					string url = $"{_baseURL}/api/nutrients";

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

		public async Task<bool> UpdateNutrient(NutrientResponseModel nutrientRequest, int id)
		{
			var returnResponse = false;
			try
			{
				using (var client = new HttpClient())
				{
					string url = $"{_baseURL}/api/nutrients/{id}";


					var serializeContent = JsonConvert.SerializeObject(nutrientRequest);

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

		public async Task<bool> DeleteNutrient(NutrientResponseModel nutrientRequest)
		{
			var returnResponse = false;
			try
			{
				using (var client = new HttpClient())
				{
					string url = $"{_baseURL}/api/nutrients/{nutrientRequest.Id}";

					var serializeContent = JsonConvert.SerializeObject(nutrientRequest);
					var request = new HttpRequestMessage();
					request.Method = HttpMethod.Delete;
					request.RequestUri = new Uri(url);
					request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json");



					var apiResponse = await client.SendAsync(request);

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
        public async Task<List<NutrientResponseModel>> GetNutrientDetailByName(string name)
        {

            var returnResponse = new List<NutrientResponseModel>();

			try
            {
                using (var client = new HttpClient())
                {
                    string url = $"https://localhost:7149/api/Nutrient/GetNutrientDetailByName/{name}";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

						var response = await apiResponse.Content.ReadAsStringAsync();

						returnResponse = JsonConvert.DeserializeObject
							<List<NutrientResponseModel>>(response);

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

using Entities.DailyNutritionEntities;
using Entities.ExerciseDetailEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExerciseDetailServise
{
    public class ExerciseDetailService : IExerciseDetailService
    {
        private string _baseURL = "https://localhost:7149";
        private List<ExerciseDetailsResponseModel> exerciseDetailsResponseModels;

        public async Task<List<ExerciseDetailsResponseModel>> GetExerciseDetailList(int id)
        {
            exerciseDetailsResponseModels = new List<ExerciseDetailsResponseModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/ExerciseDetailsWithExerciseId?id={id}";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        exerciseDetailsResponseModels = JsonConvert.DeserializeObject<List<ExerciseDetailsResponseModel>>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return exerciseDetailsResponseModels;
        }
    }
}

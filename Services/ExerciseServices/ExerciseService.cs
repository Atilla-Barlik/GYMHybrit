using Entities.ExerciseEntities;
using Entities.NutrientEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExerciseServices
{
    public class ExerciseService : IExerciseService
    {
        private string _baseURL = "https://localhost:7149";
        private List<ExerciseResponseModel> _exerciseList;
        public async Task<List<ExerciseResponseModel>> GetAllExercises()
        {
            _exerciseList = new List<ExerciseResponseModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/Exercises";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        _exerciseList = JsonConvert.DeserializeObject
                            <List<ExerciseResponseModel>>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return _exerciseList;
        }
    }
}

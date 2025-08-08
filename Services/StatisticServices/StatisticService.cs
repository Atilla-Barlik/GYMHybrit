using Entities.ExerciseEntities;
using Entities.UserExerciseProgramEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private string _baseURL = "https://localhost:7149";
        private List<ExerciseStatisticsModel> _exerciseList;
        public async Task<List<ExerciseStatisticsModel>> GetAllExercisesStatistics(int userId)
        {
            _exerciseList = new List<ExerciseStatisticsModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AppUserExerciseStatistics/user/{userId}/statistics";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        _exerciseList = JsonConvert.DeserializeObject
                            <List<ExerciseStatisticsModel>>(response);

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

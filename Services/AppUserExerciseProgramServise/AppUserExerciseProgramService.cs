using Entities.AppUserExerciseProgramEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AppUserExerciseProgramServise
{
    public class AppUserExerciseProgramService : IAppUserExerciseProgramService
    {
        private string _baseURL = "https://localhost:7149";
        //private AddUpdateAppUserExerciseProgramRequest _addRequest;
        public async Task<bool> AddAppUserExercise(AddUpdateAppUserExerciseProgramRequest request)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AppUserExerciseProgram";

                    var serializeContent = JsonConvert.SerializeObject(request);

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
    }
}

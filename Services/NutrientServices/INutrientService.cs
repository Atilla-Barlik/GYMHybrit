using Entities.NutrientEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.NutrientServices
{
	public interface INutrientService
	{
		Task<List<NutrientResponseModel>> GetAllNutrientList();
		Task<NutrientResponseModel> GetNutrientDetailById(int Id);
		Task<bool> AddNutrient(AddUpdateNutrientRequest nutrientRequest);
		Task<bool> UpdateNutrient(NutrientResponseModel nutrientRequest, int id);
		Task<bool> DeleteNutrient(NutrientResponseModel nutrientRequest);
	}
}

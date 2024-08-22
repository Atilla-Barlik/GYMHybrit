using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.NutrientEntities
{
	public class NutrientResponseModel
	{
		public int Id { get; set; }
		public String? Name { get; set; }
		public String? image { get; set; }
		public int kcal { get; set; }
		public double carbonhydrate { get; set; }
		public double protein { get; set; }
		public double fat { get; set; }
		public double sugar { get; set; }
		public double fiber { get; set; }
		public double cholestrol { get; set; }
		public double sodium { get; set; }
		public double potassium { get; set; }
		public double calcium { get; set; }
		public double vitamin_A { get; set; }
		public double vitamin_C { get; set; }
		public double iron { get; set; }
	}
}

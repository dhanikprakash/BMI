using BMI.BusinessLayer.SettingsProvider;
using System.Collections.Generic;
using System.Linq;

namespace BMI.BusinessLayer
{
    public class BMIResponse
    {
        public IList<Response> results = new List<Response>();
        public int TotalRecords { get; set; }
        public long ElapsedMilliseconds { get; set; }
        private readonly List<ICategory> categories;
        public BMIResponse(ICategoryProvider categoryProvider, IList<Response> currentResponse)
        {
            categories = categoryProvider.LoadCategories();
            LoadResponse(currentResponse);
        }
        private void LoadResponse(IList<Response> currentResponse) {
            foreach(var category in categories)
            {
                results.Add(new Response
                {
                    CategoryName = category.Name,
                    PatientCount = currentResponse.Where(x => x.CategoryName == category.Name).FirstOrDefault()?.PatientCount ?? default(int)
                });
            }
        }
        
    }
}

using System.Collections.Generic;

namespace BMI.BusinessLayer.SettingsProvider
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly List<ICategory> categories = new List<ICategory>();
        public CategoryProvider()
        {
            categories.Add(new UnderWeightCategory());
            categories.Add(new NormalWeightCategory());
            categories.Add(new PreObesityCategory());
            categories.Add(new ObesityCategory());
        }
        public List<ICategory> LoadCategories()
        {
            return categories;
        }
    }
}

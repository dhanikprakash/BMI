using System.Collections.Generic;

namespace BMI.BusinessLayer.SettingsProvider
{
    public interface ICategoryProvider
    {
        List<ICategory> LoadCategories(); 
    }
}

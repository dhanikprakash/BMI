using BMI.BusinessLayer.SettingsProvider;
using System.Collections.Generic;

namespace BMI.BusinessLayer.Mappers
{
    public class ResponseMapper : IMapper< BMIResponse, IList<Response>>
    {
        private BMIResponse bmiResponse;
        private readonly ICategoryProvider categoryProvider;
        public ResponseMapper(ICategoryProvider categoryProvider)
        {
            this.categoryProvider = categoryProvider;
        }
        public BMIResponse Map(IList<Response> results)
        {
            return new BMIResponse(categoryProvider, results);
        }
    }
}

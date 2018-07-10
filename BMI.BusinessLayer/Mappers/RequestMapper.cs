using Newtonsoft.Json;

namespace BMI.BusinessLayer.Mappers
{
    public class RequestMapper : IMapper<Patients, string>
    {
        public Patients Map(string jsonRequest)
        {
            return JsonConvert.DeserializeObject<Patients>(jsonRequest);
        }
    }
}

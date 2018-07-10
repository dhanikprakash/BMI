using BMI.BusinessLayer.Mappers;
using BMI.BusinessLayer.SettingsProvider;
using System.Collections.Generic;
using System.Linq;

namespace BMI.BusinessLayer
{
    public class BMICalculator : IBMICalulator
    {
        private readonly List<ICategory> categories;
        private readonly IMapper<Patients, string> RequestMapper;
        private readonly IMapper<BMIResponse, IList<Response>> ResponseMapper;

        public BMICalculator(ICategoryProvider categoryProvider, IMapper<Patients, string> requestMapper, IMapper<BMIResponse, IList<Response>> responseMapper)
        {
            categories = categoryProvider.LoadCategories();
            RequestMapper = requestMapper;
            ResponseMapper = responseMapper;
        }
        private float CalcualteBMI(Patient patient) => patient.Weight / ((patient.Height) * (patient.Height));
        private IList<Response> ProcessPatientData(Patients patientData)
        {
            var bmi = default(float);
            var results = new List<string>();
            foreach (var patient in patientData.patients)
            {
                bmi = CalcualteBMI(patient);
                results.Add(categories.Where(x => x.UpperLimit >= bmi && bmi >= x.Lowerlimit).FirstOrDefault()?.Name);
            }
            return results.GroupBy(x => x).Select(x => new Response { CategoryName = x.Key, PatientCount = x.Count() }).ToList();
        }
        public BMIResponse Calculate(string jsonRequest)
        {

            var patientData = RequestMapper.Map(jsonRequest);
            var results = ProcessPatientData(patientData);
            var response = ResponseMapper.Map(results);
            //For Performance analysis
            response.TotalRecords = patientData.patients.Count();
            //////
            return response;

        }



    }
}

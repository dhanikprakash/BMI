using BMI.BusinessLayer;
using BMI.UI.FileProcessor;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMI.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBMICalulator bmiCalculator;
        private readonly IFileParser fileParser;
        public HomeController(IBMICalulator bmiCalculator, IFileParser fileParser)
        {
            this.bmiCalculator = bmiCalculator;
            this.fileParser = fileParser;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
        {

            var result = fileParser.ParseFile(files.FirstOrDefault());

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var bmiResult = bmiCalculator.Calculate(result);
            stopwatch.Stop();
            bmiResult.ElapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            return Json(JsonConvert.SerializeObject(bmiResult));


        }

    }
}
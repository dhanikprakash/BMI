using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.IO;
using BMI.BusinessLayer.Mappers;
using BMI.BusinessLayer.SettingsProvider;
using System.Diagnostics;

namespace BMI.BusinessLayer.Tests
{
    [TestClass()]
    public class BMICalculatorTests
    {
        private string test01Data;
        private string test02Data;
        private string test03Data;
        private string test04Data;
        private string test05Data;
        private BMICalculator bMICalculator;
        private CategoryProvider categoryProvider;
        [TestInitialize()]
        public void Initialize()
        {
            test01Data = File.ReadAllText(@"TestData/Test01.json", Encoding.UTF8);
            test02Data = File.ReadAllText(@"TestData/Test02.json", Encoding.UTF8);
            test03Data = File.ReadAllText(@"TestData/Test03.json", Encoding.UTF8);
            test04Data = File.ReadAllText(@"TestData/Test04.json", Encoding.UTF8);
            test05Data = File.ReadAllText(@"TestData/Test05.json", Encoding.UTF8);
            categoryProvider = new CategoryProvider();
            var requestMapper = new RequestMapper();
            var responseMapper = new ResponseMapper(categoryProvider);
            bMICalculator = new BMICalculator(categoryProvider, requestMapper, responseMapper);
        }

        [TestMethod()]
        public void bMICalculator_Test01_Should_Return_One_In_All_catagories()
        {

            var catagories = categoryProvider.LoadCategories();
            var response  = bMICalculator.Calculate(test01Data);
            
            Assert.IsNotNull(response);
            foreach(var catagory in catagories)
            {
                Assert.AreEqual(response.results.Where(x => x.CategoryName == catagory.Name)
                                                  .Select(x => x.PatientCount).FirstOrDefault(), 1);
            }
           
        }
        [TestMethod()]
        public void bMICalculator_Test02_Should_Return_One_catagory()
        {
            var catagories = categoryProvider.LoadCategories();
            var response = bMICalculator.Calculate(test02Data);
            Assert.IsNotNull(response);
            foreach (var catagory in catagories)
            {
                if(catagory.Name == "Pre-obesity")
                {
                    Assert.AreEqual(response.results.Where(x => x.CategoryName == catagory.Name)
                                            .Select(x => x.PatientCount).FirstOrDefault(), 2);
                }
                else
                {
                    Assert.AreEqual(response.results.Where(x => x.CategoryName == catagory.Name)
                                           .Select(x => x.PatientCount).FirstOrDefault(), 0);
                }
            }

        }
        [TestMethod()]
        public void bMICalculator_Test03_Should_Return_Muliple_In_All_catagories()
        {

            var catagories = categoryProvider.LoadCategories();
            var response = bMICalculator.Calculate(test03Data);

            Assert.IsNotNull(response);
            foreach (var catagory in catagories)
            {
                Assert.AreEqual(response.results.Where(x => x.CategoryName == catagory.Name)
                                                  .Select(x => x.PatientCount).FirstOrDefault(), 5);
            }

        }
        [TestMethod()]
        public void bMICalculator_Test04_Should_Return_Zero_In_All_catagories()
        {

            var catagories = categoryProvider.LoadCategories();
            var response = bMICalculator.Calculate(test04Data);

            Assert.IsNotNull(response);
            foreach (var catagory in catagories)
            {
                Assert.AreEqual(response.results.Where(x => x.CategoryName == catagory.Name)
                                                  .Select(x => x.PatientCount).FirstOrDefault(), 0);
            }

        }
        [TestMethod()]
        public void bMICalculator_Test05_Performance_over_10000_Records()
        {

            var catagories = categoryProvider.LoadCategories();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var response = bMICalculator.Calculate(test05Data);
            stopwatch.Stop();
             Assert.IsTrue(stopwatch.ElapsedMilliseconds < 500);
            

        }
    }
}
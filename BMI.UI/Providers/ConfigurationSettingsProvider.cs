using System.Configuration;

namespace BMI.UI.Providers
{
    public class ConfigurationSettingsProvider:IConfigurationSettingsProvider
    {
        public string FilePath => ConfigurationManager.AppSettings["FilePath"];

      
    }
}
using BMI.UI.Providers;
using System.IO;
using System.Text;
using System.Web;

namespace BMI.UI.FileProcessor
{
    public class FileParser : IFileParser
    {
        private readonly IConfigurationSettingsProvider configurationSettingsProvider;
        public FileParser(IConfigurationSettingsProvider configurationSettingsProvider)
        {
           this.configurationSettingsProvider = configurationSettingsProvider;
        }
        
        public string ParseFile(HttpPostedFileBase file)
        {
            var tempPath = this.configurationSettingsProvider.FilePath;
            ValidatePath(tempPath);
            string filePath = Path.Combine(tempPath, file.FileName);
            System.IO.File.WriteAllBytes(filePath, ReadData(file.InputStream));
            return System.IO.File.ReadAllText(tempPath + file.FileName, Encoding.UTF8);
            
        }

        private static void ValidatePath(string tempPath)
        {
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }
        }

        private byte[] ReadData(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
using System.Web;

namespace BMI.UI.FileProcessor
{
    public interface IFileParser
    {
        string ParseFile(HttpPostedFileBase file);
    }
}
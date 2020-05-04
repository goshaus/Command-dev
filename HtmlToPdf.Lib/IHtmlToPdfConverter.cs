using HtmlToPdf.Lib.Settings;
using System.IO;

namespace HtmlToPdf.Lib
{
    public interface IHtmlToPdfConverter
    {
        byte[] ConvertToPdfAsArray(HtmlToPdfSettings settings, string htmlString);
        Stream ConvertToPdfAsStream(HtmlToPdfSettings settings, string htmlString);
    }
}

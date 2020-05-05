using HtmlToPdf.Lib.Settings;
using System.IO;

namespace HtmlToPdf.Lib
{
    /// <summary>
    /// Interface for HTML to PDF converter.
    /// </summary>
    public interface IHtmlToPdfConverter
    {
        /// <summary>
        /// Generate pdf from html string with custom settings.
        /// </summary>
        /// <param name="settings">Pdf convertation settings</param>
        /// <param name="htmlString"></param>
        /// <returns>Pdf data is an byte array.</returns>
        byte[] ConvertToPdfAsArray(HtmlToPdfSettings settings, string htmlString);

        /// <summary>
        /// Generate pdf from html string with custom settings.
        /// </summary>
        /// <param name="settings">Pdf convertation settings</param>
        /// <param name="htmlString"></param>
        /// <returns>Pdf data is an memory stream.</returns>
        Stream ConvertToPdfAsStream(HtmlToPdfSettings settings, string htmlString);
    }
}

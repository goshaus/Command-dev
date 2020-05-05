using HtmlToPdf.Lib.Settings;

namespace HtmlToPdf.Web.Models.Convert
{
    public class SettingsViewModel
    {
        public string CustomFileName { get; set; }
        public string Margin { get; set; }
        public PdfStandart Standart { get; set; }
        public PdfPageSize PageSize { get; set; }
        public PdfPageOrientation PageOrientation { get; set; }
        public PdfCompressionLevel CompressionLevel { get; set; }
    }
}
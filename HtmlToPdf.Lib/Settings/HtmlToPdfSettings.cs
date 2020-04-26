namespace HtmlToPdf.Lib.Settings
{
    public class HtmlToPdfSettings
    {
        public string FileName { get; set; }
        public string Margin { get; set; }
        public PdfStandart Standart { get; set; }
        public PdfPageSize PageSize { get; set; }
        public PdfPageOrientation PageOrientation { get; set; }
        public PdfCompressionLevel CompressionLevel { get; set; }
    }
}

namespace HtmlToPdf.Lib.Settings
{
    /// <summary>
    /// This class contains various options used for the html to pdf conversion.
    /// </summary>
    public class HtmlToPdfSettings
    {
        /// <summary>
        /// This property controls the name of the generated pdf document.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Margin of the pdf document.
        /// </summary>
        public string Margin { get; set; }
        /// <summary>
        /// Defines the pdf standard used by the generated pdf document.
        /// </summary>
        public PdfStandart Standart { get; set; }
        /// <summary>
        /// This property controls the size of the generated document pages.
        /// </summary>
        public PdfPageSize PageSize { get; set; }
        /// <summary>
        /// This property controls the page orientation of the generated pdf document pages.
        /// </summary>
        public PdfPageOrientation PageOrientation { get; set; }
        /// <summary>
        /// This property controls the compression level of the generated pdf document.
        /// </summary>
        public PdfCompressionLevel CompressionLevel { get; set; }
    }
}

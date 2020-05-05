namespace HtmlToPdf.Lib.Settings
{
    /// <summary>
    /// The list of pdf standards available.
    /// </summary>
    public enum PdfStandart
    {
        /// <summary>
        /// The generated pdf is in conformance with PDF/A standard which makes the document suitable for long term archiving.
        /// </summary>
        PdfA,
        /// <summary>
        /// The generated PDF is in conformance with PDF/X standard which makes the document suitable for graphics exchange.
        /// </summary>
        PdfX
    }
}

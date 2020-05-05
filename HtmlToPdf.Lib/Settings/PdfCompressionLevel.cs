namespace HtmlToPdf.Lib.Settings
{
    /// <summary>
    /// The pdf document compression level.
    /// </summary>
    public enum PdfCompressionLevel
    {
        /// <summary>
        /// No compression.
        /// </summary>
        NoCompression,
        /// <summary>
        /// Normal compression level.
        /// </summary>
        Normal,
        /// <summary>
        /// Best compression. Produces the smallest pdf document but it takes longer to compress it.
        /// </summary>
        Best
    }
}

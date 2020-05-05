using System;
using System.IO;
using HtmlToPdf.Lib.Settings;
using SelectPdf;

namespace HtmlToPdf.Lib
{
    /// <summary>
    /// Converter used to generate html based pdf file.
    /// </summary>
    public class HtmlToPdfConverter : IHtmlToPdfConverter
    {
        private readonly SelectPdf.HtmlToPdf _internalConverter;
        private const char MarginValuesSeparator = ' ';
        private const int MarginValuesAmount = 4;

        /// <summary>
        /// Initializes an instance of the HtmlToPdfConverter.
        /// </summary>
        public HtmlToPdfConverter()
        {
            _internalConverter = new SelectPdf.HtmlToPdf();
        }

        /// <summary>
        /// Generate pdf from html string with custom settings.
        /// </summary>
        /// <param name="settings">Pdf convertation settings</param>
        /// <param name="htmlString"></param>
        /// <returns>Pdf data is an byte array.</returns>
        public byte[] ConvertToPdfAsArray(HtmlToPdfSettings settings, string htmlString)
        {
            using (var pdfStream = (MemoryStream)ConvertToPdfAsStream(settings, htmlString))
            {
                return pdfStream.ToArray();
            }
        }


        /// <summary>
        /// Generate pdf from html string with custom settings.
        /// </summary>
        /// <param name="settings">Pdf convertation settings</param>
        /// <param name="htmlString"></param>
        /// <returns>Pdf data is an memory stream.</returns>
        public Stream ConvertToPdfAsStream(HtmlToPdfSettings settings, string htmlString)
        {
            if (settings == null)
                throw new ArgumentNullException("settings", "Pdf settings is null");
            if (string.IsNullOrEmpty(htmlString))
                throw new ArgumentNullException("htmlString", "Source html is empty");

            ApplyUserSettings(settings);

            var pdfContainer = _internalConverter.ConvertHtmlString(htmlString);
            var pdfStream = new MemoryStream();

            pdfContainer.Save(pdfStream);

            return pdfStream;
        }

        /// <summary>
        /// Apply user settings to internal converter settings
        /// </summary>
        /// <param name="settings">Pdf convertation settings</param>
        private void ApplyUserSettings(HtmlToPdfSettings settings)
        {
            if (settings.Margin != null)
            {
                var pdfMargin = settings.Margin.Split(MarginValuesSeparator);
                if (pdfMargin.Length != MarginValuesAmount)
                    throw new FormatException("Margin field should contains 4 values");

                _internalConverter.Options.MarginTop = Convert.ToInt32(pdfMargin[0]);
                _internalConverter.Options.MarginRight = Convert.ToInt32(pdfMargin[1]);
                _internalConverter.Options.MarginBottom = Convert.ToInt32(pdfMargin[2]);
                _internalConverter.Options.MarginLeft = Convert.ToInt32(pdfMargin[3]);
            }

            _internalConverter.Options.PdfStandard = (PdfStandard)Enum.Parse(typeof(PdfStandard), settings.Standart.ToString());
            _internalConverter.Options.PdfPageSize = (SelectPdf.PdfPageSize)Enum.Parse(typeof(SelectPdf.PdfPageSize),
                settings.PageSize.ToString());
            _internalConverter.Options.PdfPageOrientation = (SelectPdf.PdfPageOrientation)Enum.Parse(typeof(SelectPdf.PdfPageOrientation),
               settings.PageOrientation.ToString());
            _internalConverter.Options.PdfCompressionLevel = (SelectPdf.PdfCompressionLevel)Enum.Parse(typeof(SelectPdf.PdfCompressionLevel),
               settings.CompressionLevel.ToString());
        }
    }
}

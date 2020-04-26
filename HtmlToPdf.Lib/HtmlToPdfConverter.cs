using System;
using System.IO;
using HtmlToPdf.Lib.Settings;
using SelectPdf;

namespace HtmlToPdf.Lib
{
    public class HtmlToPdfConverter
    {
        private readonly SelectPdf.HtmlToPdf _internalConverter;
        private const char MarginValuesSeparator = ' ';

        public HtmlToPdfConverter()
        {
            _internalConverter = new SelectPdf.HtmlToPdf();
        }

        public byte[] ConvertToPdfAsArray(HtmlToPdfSettings settings, string htmlString)
        {
            using (var pdfStream = (MemoryStream)ConvertToPdfAsStream(settings, htmlString))
            {
                return pdfStream.ToArray();
            }
        }

        public Stream ConvertToPdfAsStream(HtmlToPdfSettings settings, string htmlString)
        {
            ApplyUserSettings(settings);

            var pdfContainer = _internalConverter.ConvertHtmlString(htmlString);
            var pdfStream = new MemoryStream();
            pdfContainer.Save(pdfStream);

            return pdfStream;
        }

        private void ApplyUserSettings(HtmlToPdfSettings settings)
        {
            var pdfMargin = settings.Margin.Split(MarginValuesSeparator);

            _internalConverter.Options.MarginTop = Convert.ToInt32(pdfMargin[0]);
            _internalConverter.Options.MarginRight = Convert.ToInt32(pdfMargin[1]);
            _internalConverter.Options.MarginBottom = Convert.ToInt32(pdfMargin[2]);
            _internalConverter.Options.MarginLeft = Convert.ToInt32(pdfMargin[3]);

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

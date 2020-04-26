using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlToPdf.Lib;
using HtmlToPdf.Lib.Settings;
using Shouldly;
using iTextSharp.text.pdf;

namespace HtmlToPdf.UnitTest
{
    [TestClass]
    public class ConverterTest
    {
        private const string SpecifiedHtmlString = @"<HTML><HEAD><TITLE>Your Title Here</TITLE></HEAD><BODY BGCOLOR=""FFFFFF""><CENTER>
                </CENTER><HR><a href=""#"">Link Name</a>is a link to another nifty site<H1>This is a Header</H1>
                <H2>This is a Medium Header</H2>Send me mail at <a href=""#"">support@yourcompany.com</a>.
                <P> This is a new paragraph!<P> <B>This is a new paragraph!</B><BR> <B><I>This is a new sentence without a paragraph break,
                in bold italics.</I></B><HR></BODY></HTML>";


        [TestMethod]
        public void ShouldConvertToPortraitPdf()
        {
            var converter = new HtmlToPdfConverter();
            var settings = new HtmlToPdfSettings()
            {
                CompressionLevel = PdfCompressionLevel.NoCompression,
                Margin = "25 25 25 25",
                PageOrientation = PdfPageOrientation.Portrait,
                PageSize = PdfPageSize.A3,
                Standart = PdfStandart.PdfA
            };

            var pdfFile = converter.ConvertToPdfAsArray(settings, SpecifiedHtmlString);

            var pdfReader = new PdfReader(pdfFile);
            var firstPdfPage = pdfReader.GetPageSize(1);
            firstPdfPage.Width.ShouldBeLessThanOrEqualTo(firstPdfPage.Height);
        }

        [TestMethod]
        public void ShouldConvertToLandscapePdf()
        {
            var converter = new HtmlToPdfConverter();
            var settings = new HtmlToPdfSettings()
            {
                CompressionLevel = PdfCompressionLevel.NoCompression,
                Margin = "25 25 25 25",
                PageOrientation = PdfPageOrientation.Landscape,
                PageSize = PdfPageSize.A3,
                Standart = PdfStandart.PdfA
            };

            var pdfFile = converter.ConvertToPdfAsArray(settings, SpecifiedHtmlString);

            var pdfReader = new PdfReader(pdfFile);
            var firstPdfPage = pdfReader.GetPageSize(1);
            firstPdfPage.Width.ShouldBeGreaterThanOrEqualTo(firstPdfPage.Height);
        }

        [TestMethod]
        public void ShouldConvertToA3Pdf()
        {
            var converter = new HtmlToPdfConverter();
            var settings = new HtmlToPdfSettings()
            {
                CompressionLevel = PdfCompressionLevel.NoCompression,
                Margin = "25 25 25 25",
                PageOrientation = PdfPageOrientation.Portrait,
                PageSize = PdfPageSize.A3,
                Standart = PdfStandart.PdfA
            };

            var pdfFile = converter.ConvertToPdfAsArray(settings, SpecifiedHtmlString);

            var pdfReader = new PdfReader(pdfFile);
            var firstPdfPage = pdfReader.GetPageSize(1);
            firstPdfPage.Width.ShouldBe(842);
            firstPdfPage.Height.ShouldBe(1190);
        }

        [TestMethod]
        public void ShouldConvertToB4Pdf()
        {
            var converter = new HtmlToPdfConverter();
            var settings = new HtmlToPdfSettings()
            {
                CompressionLevel = PdfCompressionLevel.NoCompression,
                Margin = "25 25 25 25",
                PageOrientation = PdfPageOrientation.Portrait,
                PageSize = PdfPageSize.B4,
                Standart = PdfStandart.PdfA
            };

            var pdfFile = converter.ConvertToPdfAsArray(settings, SpecifiedHtmlString);

            var pdfReader = new PdfReader(pdfFile);
            var firstPdfPage = pdfReader.GetPageSize(1);
            firstPdfPage.Width.ShouldBe(2953);
            firstPdfPage.Height.ShouldBe(4169);
        }
    }
}

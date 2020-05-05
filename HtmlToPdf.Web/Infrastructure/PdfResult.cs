using System;
using System.IO;
using System.Web.Mvc;
using HtmlToPdf.Lib;
using HtmlToPdf.Lib.Settings;

namespace HtmlToPdf.Web.Infrastructure
{
    public class PdfResult : PartialViewResult
    {
        private readonly IHtmlToPdfConverter _converter;
        private readonly HtmlToPdfSettings _settings;
        private readonly Stream _htmlFileSource;

        public PdfResult(IHtmlToPdfConverter converter, Stream htmlFile, HtmlToPdfSettings settings, string viewName) : base()
        {
            ViewName = viewName;
            _converter = converter;
            _settings = settings;
            _htmlFileSource = htmlFile;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            if (string.IsNullOrEmpty(ViewName))
                throw new ArgumentNullException("ViewName");

            ViewData = context.Controller.ViewData;
            TempData = context.Controller.TempData;

            ViewEngineResult viewEngineResult = null;
            if (View == null)
            {
                viewEngineResult = FindView(context);
                View = viewEngineResult.View;
            }

            if (viewEngineResult != null)
                viewEngineResult.ViewEngine.ReleaseView(context, View);

            var streamReader = new StreamReader(_htmlFileSource);
            var htmlString = streamReader.ReadToEnd();

            var pdfSource = _converter.ConvertToPdfAsArray(_settings, htmlString);

            FileContentResult result = new FileContentResult(pdfSource, "application/pdf")
            {
                FileDownloadName = _settings.FileName
            };
            result.ExecuteResult(context);
        }
    }
}
using HtmlToPdf.Lib;
using HtmlToPdf.Lib.Settings;
using HtmlToPdf.Web.Models.Convert;
using System.Web.Mvc;
using System;
using HtmlToPdf.Web.Infrastructure;

namespace HtmlToPdf.Web.Controllers
{
    public class ConvertController : Controller
    {
        private const int MaxFileSize = 4000000; //4MB
        private readonly IHtmlToPdfConverter _converter;

        public ConvertController(IHtmlToPdfConverter converter)
        {
            _converter = converter;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(PopulateViewModel());
        }

        [HttpPost]
        public ActionResult Index(ConvertViewModel model)
        {
            if (model.HtmlFile.ContentLength > MaxFileSize)
                throw new ApplicationException($"Invalid file size (max {MaxFileSize} Mb)");

            try
            {
                var settings = MapToConverterSettings(model.Settings, model.HtmlFile.FileName);

                return new PdfResult(_converter, model.HtmlFile.InputStream, settings, "Index");
            }
            catch (Exception e)
            {
                return View("Error", null, e.Message);
            }
        }

        private ConvertViewModel PopulateViewModel()
        {
            return new ConvertViewModel()
            {
                Settings = new SettingsViewModel()
                {
                    CompressionLevel = PdfCompressionLevel.Normal,
                    PageOrientation = PdfPageOrientation.Portrait,
                    PageSize = PdfPageSize.A4,
                    Standart = PdfStandart.PdfA
                }
            };
        }

        private HtmlToPdfSettings MapToConverterSettings(SettingsViewModel model, string defaultFileName)
        {
            return new HtmlToPdfSettings()
            {
                FileName = string.IsNullOrWhiteSpace(model.CustomFileName) ? $"{ Guid.NewGuid() }.pdf" : model.CustomFileName,
                CompressionLevel = model.CompressionLevel,
                Margin = model.Margin,
                PageOrientation = model.PageOrientation,
                PageSize = model.PageSize,
                Standart = model.Standart
            };
        }
    }
}
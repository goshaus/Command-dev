using HtmlToPdf.Lib;
using HtmlToPdf.Lib.Settings;
using HtmlToPdf.Web.Infrastructure;
using HtmlToPdf.Web.Models.Convert;
using System.Web;
using System.Web.Mvc;

namespace HtmlToPdf.Web.Controllers
{
    public class ConvertController : Controller
    {
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
            return null;
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
    }
}
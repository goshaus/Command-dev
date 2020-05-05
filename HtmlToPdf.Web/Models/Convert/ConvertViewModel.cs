using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HtmlToPdf.Web.Models.Convert
{
    public class ConvertViewModel
    {
        [Required, FileExtensions(Extensions = "html",
             ErrorMessage = "Please specify .html file")]
        public HttpPostedFileBase HtmlFile { get; set; }
        public SettingsViewModel Settings { get; set; }
    }
}